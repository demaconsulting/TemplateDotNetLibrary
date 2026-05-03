# System Design

This document provides the system-level design for the Template DotNet Library.

## System Architecture

The Template DotNet Library is a minimal .NET library template demonstrating DEMA Consulting
best practices. The system consists of:

- **Demo Unit**: Simple greeting functionality demonstrating library patterns

## External Interfaces

### Dependencies

**Runtime Dependencies:**

- **.NET Runtime**: Provides core framework functionality

**Build and Quality Tooling:**

- **xUnit v3**: Unit testing framework for verification
- **ReqStream**: Requirements traceability enforcement
- **ReviewMark**: File review management
- **BuildMark/VersionMark**: Build and version documentation
- **SonarMark/SarifMark**: Quality analysis integration

### Public API

The system exposes:

- **Demo()**: Default constructor; initializes the instance with the default prefix `"Hello"`
- **Demo(string prefix)**: Custom-prefix constructor; initializes the instance with the specified
  prefix. Throws `ArgumentNullException` if `prefix` is null; throws `ArgumentException` if
  `prefix` is an empty string.
- **Demo.Prefix**: Read-only property that returns the greeting prefix configured at construction
- **Demo.DemoMethod(string name)**: Returns a greeting string in the format `{prefix}, {name}!`.
  Throws `ArgumentNullException` if `name` is null; throws `ArgumentException` if `name` is an
  empty string.
- Package metadata and documentation for NuGet distribution

## Data Flow

**Construction path:**

1. **Input**: Constructor parameter `prefix` (optional; defaults to `"Hello"` when using `Demo()`)
2. **Validation**: `Demo(string prefix)` rejects null with `ArgumentNullException`; rejects empty
   string with `ArgumentException`
3. **Storage**: Valid prefix stored for use in subsequent greeting calls

**Method-call path:**

1. **Input**: Method parameter `name` (required, non-empty string)
2. **Validation**: `DemoMethod` rejects null with `ArgumentNullException`; rejects empty string
   with `ArgumentException`
3. **Processing**: Simple string formatting combining stored prefix and supplied name
4. **Output**: Formatted greeting string in the format `{prefix}, {name}!`

## System Constraints

- **Simplicity**: Minimal functionality to serve as template
- **Compliance**: All functionality must be traceable to requirements
- **Quality**: Zero warnings, full test coverage, complete documentation
- **Portability**: Compatible across supported .NET platforms

## Platform Support

The library targets the following frameworks, enabling broad compatibility across modern .NET
runtimes and legacy environments:

| Target Framework   | Runtime / Environment                             |
|--------------------|---------------------------------------------------|
| `netstandard2.0`   | .NET Standard 2.0 (implemented by .NET FX 4.8.1+) |
| `net8.0`           | .NET 8 LTS                                        |
| `net9.0`           | .NET 9                                            |
| `net10.0`          | .NET 10                                           |

The library is supported on the following operating systems:

- **Windows** — primary developer and CI platform
- **Linux** — CI/CD and containerized environments
- **macOS** — developer workstations using Apple platforms

Portability is achieved by restricting the implementation exclusively to Base Class Library (BCL)
APIs available across all target frameworks. No platform-specific native interop, OS-specific
APIs, or framework-version-specific features are used.

## Integration Patterns

- **NuGet Packaging**: Standard .NET library packaging and distribution
- **CI/CD Integration**: Automated build, test, and quality validation
- **Requirements Traceability**: All features linked to passing tests
- **Review Management**: Systematic file review using ReviewMark patterns
