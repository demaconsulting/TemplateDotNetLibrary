# Demo Unit Verification Design

<!-- TODO: This is an example verification design section for the Demo class. Replace with your own unit verification. -->

This document describes the unit-level verification strategy for the `Demo` class.

## Verification Strategy

The `Demo` unit is verified through unit tests that exercise each public method and constructor
in isolation. Because `Demo` has no external dependencies beyond the .NET base class library, no
mocking or stubbing is required. Tests supply controlled inputs and assert on returned values and
thrown exception types.

Unit tests reside in `DemoTests.cs` within the `DemaConsulting.TemplateDotNetLibrary.Tests`
project.

## Test Environment

- **Framework**: xUnit v3 running under the .NET SDK
- **Execution**: `dotnet test` invoked by `build.ps1` and the CI pipeline
- **Mocking**: None required; `Demo` has no injectable dependencies
- **Isolation**: Each test method constructs its own `Demo` instance; no shared state between tests

## Unit-Level Test Scenarios

### Template-Demo-Greeting: DemoMethod Default Prefix Returns Greeting

**Test**: `Demo_DemoMethod_DefaultPrefix_ReturnsGreeting`

Constructs a `Demo` using the default constructor and calls `DemoMethod("World")`. Asserts the
return value is exactly `"Hello, World!"`. Verifies the core greeting format `"{prefix}, {name}!"`
under the default prefix `"Hello"`.

### Template-Demo-Greeting: DemoMethod Custom Prefix Returns Greeting

**Test**: `Demo_DemoMethod_CustomPrefix_ReturnsGreeting`

Constructs a `Demo` with custom prefix `"Hi"` and calls `DemoMethod("Alice")`. Asserts the return
value is exactly `"Hi, Alice!"`. Verifies that a non-default prefix is correctly combined with the
caller-supplied name in the `"{prefix}, {name}!"` format.

### Template-Demo-Prefix: Prefix With Custom Construction Returns Custom Prefix

**Test**: `Demo_Prefix_WithCustomConstruction_ReturnsCustomPrefix`

Constructs a `Demo` with prefix `"Greetings"` and reads the `Prefix` property. Asserts the
property value exactly matches the string passed at construction. Verifies that the `Prefix`
property exposes the configured prefix correctly.

### Template-Demo-Prefix: Default Constructor Sets Default Prefix

**Test**: `Demo_DefaultConstructor_WithNoArgs_SetsDefaultPrefix`

Constructs a `Demo` using the default constructor and reads the `Prefix` property. Asserts the
property value equals `Demo.DefaultPrefix`. Verifies that the default constructor stores the
expected prefix constant.

### Template-Demo-Prefix: DefaultPrefix Constant Is Hello

**Test**: `Demo_DefaultPrefix_IsHello`

Reads the `Demo.DefaultPrefix` constant directly and asserts its value is `"Hello"`. Verifies
that the constant has not silently changed, protecting callers who depend on the default greeting
string.

### Template-Demo-Validation: DemoMethod Null Input Throws ArgumentNullException

**Test**: `Demo_DemoMethod_NullInput_ThrowsArgumentNullException`

Constructs a `Demo` with the default constructor and calls `DemoMethod(null)`. Asserts that
`ArgumentNullException` (not the base `ArgumentException`) is thrown. Verifies that the unit
explicitly rejects `null` with the precise exception subtype.

### Template-Demo-Validation: DemoMethod Empty Input Throws ArgumentException

**Test**: `Demo_DemoMethod_EmptyInput_ThrowsArgumentException`

Constructs a `Demo` with the default constructor and calls `DemoMethod(string.Empty)`. Asserts
that `ArgumentException` (not `ArgumentNullException`) is thrown. This is the empty-string
boundary condition — distinct from the null case.

### Template-Demo-Validation: Constructor Null Prefix Throws ArgumentNullException

**Test**: `Demo_Constructor_NullPrefix_ThrowsArgumentNullException`

Attempts to construct a `Demo` with a `null` prefix argument. Asserts that
`ArgumentNullException` (not the base `ArgumentException`) is thrown. Verifies that the
custom-prefix constructor explicitly rejects `null`.

### Template-Demo-Validation: Constructor Empty Prefix Throws ArgumentException

**Test**: `Demo_Constructor_EmptyPrefix_ThrowsArgumentException`

Attempts to construct a `Demo` with `string.Empty` as the prefix. Asserts that
`ArgumentException` (not `ArgumentNullException`) is thrown. This is the empty-string boundary
condition for the constructor — distinct from the null case.

## Requirements Coverage

| Requirement ID           | Test Scenario(s)                                           |
|--------------------------|------------------------------------------------------------|
| Template-Demo-Greeting   | DemoMethod Default Prefix Returns Greeting                 |
| Template-Demo-Greeting   | DemoMethod Custom Prefix Returns Greeting                  |
| Template-Demo-Prefix     | Prefix With Custom Construction Returns Custom Prefix      |
| Template-Demo-Prefix     | Default Constructor Sets Default Prefix                    |
| Template-Demo-Prefix     | DefaultPrefix Constant Is Hello                            |
| Template-Demo-Validation | DemoMethod Null Input Throws ArgumentNullException         |
| Template-Demo-Validation | DemoMethod Empty Input Throws ArgumentException            |
| Template-Demo-Validation | Constructor Null Prefix Throws ArgumentNullException       |
| Template-Demo-Validation | Constructor Empty Prefix Throws ArgumentException          |
