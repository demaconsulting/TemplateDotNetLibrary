# System Verification Design

This document describes the system-level verification strategy for the Template DotNet Library.

## Verification Strategy

The Template DotNet Library system is verified through system-level integration tests that
exercise the library as a whole from the perspective of a consumer. Tests instantiate the library
using its public API and assert on observable outputs, without relying on knowledge of internal
implementation details. No mocking or stubbing is required at the system level — the entire
integrated system is exercised as it would be used by a real caller.

System tests reside in `TemplateDotNetLibraryTests.cs` within the
`DemaConsulting.TemplateDotNetLibrary.Tests` project.

## Test Environment

- **Framework**: xUnit v3 running under the .NET SDK
- **Execution**: `dotnet test` invoked by `build.ps1` and the CI pipeline
- **Dependencies**: No external services, databases, or network access required
- **Isolation**: Each test method constructs its own `Demo` instance; no shared state between tests

## External Interface Simulation

The system has no external interfaces requiring simulation. It is a pure in-process .NET library
with no I/O, network calls, or platform services. System tests call the public API directly
with controlled inputs and verify returned values and thrown exceptions.

## System-Level Test Scenarios

### Integration: Provides Expected Functionality

**Test**: `TemplateDotNetLibrary_SystemIntegration_DefaultConstruction_ReturnsExpectedGreeting`

Exercises end-to-end system behavior: constructs a `Demo` instance using the default constructor
and calls `DemoMethod` with a valid name. Asserts that the system produces the expected greeting
string `"Hello, System!"`, confirming that all components integrate correctly under default
configuration.

### Customization: Handles Configuration Properly

**Test**: `TemplateDotNetLibrary_SystemCustomization_CustomPrefix_ReturnsExpectedGreeting`

Verifies that the system correctly propagates a custom prefix supplied at construction time.
Constructs a `Demo` instance with prefix `"Welcome"`, calls `DemoMethod` with a valid name, and
asserts the result is `"Welcome, Integration!"`. Confirms that the configuration path through all
integrated components functions as expected.

### Validation: DemoMethod Null Input Throws ArgumentNullException

**Test**: `TemplateDotNetLibrary_SystemValidation_DemoMethodNullInput_ThrowsArgumentNullException`

Verifies that the system rejects a `null` argument to `DemoMethod` with `ArgumentNullException`.
Constructs a `Demo` instance with the default constructor and passes `null` to `DemoMethod`.
Confirms that the system boundary enforces the null-rejection contract.

### Validation: DemoMethod Empty Input Throws ArgumentException

**Test**: `TemplateDotNetLibrary_SystemValidation_DemoMethodEmptyInput_ThrowsArgumentException`

Verifies that the system rejects an empty-string argument to `DemoMethod` with `ArgumentException`.
Constructs a `Demo` instance with the default constructor and passes `string.Empty` to `DemoMethod`.
Confirms that the system boundary enforces the empty-string rejection contract.

### Validation: Constructor Null Prefix Throws ArgumentNullException

**Test**: `TemplateDotNetLibrary_SystemValidation_ConstructorNullPrefix_ThrowsArgumentNullException`

Verifies that the system rejects a `null` prefix argument at construction time with
`ArgumentNullException`. Attempts to construct a `Demo` instance with `null` as the prefix.
Confirms that the system boundary prevents invalid configuration from being established.

### Validation: Constructor Empty Prefix Throws ArgumentException

**Test**: `TemplateDotNetLibrary_SystemValidation_ConstructorEmptyPrefix_ThrowsArgumentException`

Verifies that the system rejects an empty-string prefix argument at construction time with
`ArgumentException`. Attempts to construct a `Demo` instance with `string.Empty` as the prefix.
Confirms that the system boundary prevents empty-string configuration from being established.

### Integration: Exposes Configured Prefix

**Test**: `TemplateDotNetLibrary_SystemIntegration_CustomPrefix_ExposesPrefix`

Verifies that the `Prefix` property exposes the prefix supplied at construction time. Constructs
a `Demo` instance with a custom prefix and reads the `Prefix` property. Confirms the system's
public API correctly surfaces the configured prefix to callers.

## Acceptance Criteria

A system-level test run passes when all seven scenarios above pass without error or exception beyond
those explicitly asserted. Any unexpected exception, wrong exception type, or wrong return value
constitutes a failure.

## Requirements Coverage

| Requirement ID                           | Test Scenario(s)                                                 |
|------------------------------------------|------------------------------------------------------------------|
| Template-Lib-Greeting                    | Integration: Provides Expected Functionality                     |
| Template-Lib-Greeting                    | Customization: Handles Configuration Properly                    |
| Template-Lib-GreetingFormat              | Integration: Provides Expected Functionality                     |
| Template-Lib-GreetingFormat              | Customization: Handles Configuration Properly                    |
| Template-Lib-DefaultPrefix               | Integration: Provides Expected Functionality                     |
| Template-Lib-CustomPrefix                | Customization: Handles Configuration Properly                    |
| Template-Lib-Prefix                      | Integration: Exposes Configured Prefix                           |
| Template-Lib-ValidationNull-DemoMethod   | Validation: DemoMethod Null Input Throws ArgumentNullException   |
| Template-Lib-ValidationNull-Constructor  | Validation: Constructor Null Prefix Throws ArgumentNullException |
| Template-Lib-ValidationEmpty-DemoMethod  | Validation: DemoMethod Empty Input Throws ArgumentException      |
| Template-Lib-ValidationEmpty-Constructor | Validation: Constructor Empty Prefix Throws ArgumentException    |
