# System Design

This document provides the system-level design for the Template DotNet Library.

![Template DotNet Library Structure](TemplateDotNetLibraryView.svg)

## Architecture

The Template DotNet Library is a minimal .NET library template demonstrating DEMA Consulting
best practices. The system consists of:

- **Demo Unit**: Simple greeting functionality demonstrating library patterns

There are no subsystems and no relationships between software items beyond the system exposing
the `Demo` unit directly through its public API; see _Demo Unit Design_ for the unit's internal
collaboration (none — `Demo` is a self-contained leaf class).

## External Interfaces

The system exposes the following public API to external consumers:

- **Demo()**: Default constructor; initializes the instance with the default prefix `"Hello"`
- **Demo(string prefix)**: Custom-prefix constructor; initializes the instance with the specified
  prefix. Throws `ArgumentNullException` if `prefix` is null; throws `ArgumentException` if
  `prefix` is an empty string.
- **Demo.Prefix**: Read-only property that returns the greeting prefix configured at construction
- **Demo.DemoMethod(string name)**: Returns a greeting string in the format `{prefix}, {name}!`.
  Throws `ArgumentNullException` if `name` is null; throws `ArgumentException` if `name` is an
  empty string.

| Interface                      | Direction        | Format                        | Constraints                  |
|--------------------------------|------------------|-------------------------------|------------------------------|
| `Demo()`                       | Inbound          | Constructor call              | None; always succeeds        |
| `Demo(string prefix)`          | Inbound          | Constructor call              | `prefix` non-null, non-empty |
| `Demo.Prefix`                  | Outbound         | `string` property read        | None; always succeeds        |
| `Demo.DemoMethod(string name)` | Inbound/Outbound | Method call / `string` return | `name` non-null, non-empty   |

## Dependencies

The Template DotNet Library has zero runtime NuGet dependencies — it is implemented exclusively
against the .NET Base Class Library. The following OTS items are used for building and verifying
this system (not consumed at runtime); see _OTS Integration Design_ (`docs/design/ots.md`) and
each item's dedicated design document for details:

- **BuildMark** — generates build-notes documentation; see _BuildMark Design_
- **FileAssert** — validates generated documents against acceptance criteria; see
  _FileAssert Design_
- **Pandoc** — converts Markdown documentation to HTML; see _Pandoc Design_
- **ReqStream** — enforces requirements-to-test traceability; see _ReqStream Design_
- **ReviewMark** — enforces file review coverage and currency; see _ReviewMark Design_
- **SarifMark** — converts CodeQL SARIF results to markdown; see _SarifMark Design_
- **SonarMark** — generates SonarCloud quality reports; see _SonarMark Design_
- **VersionMark** — captures and publishes tool-version information; see _VersionMark Design_
- **WeasyPrint** — converts HTML documentation to PDF; see _WeasyPrint Design_
- **xUnit** — executes unit and integration tests; see _xUnit Design_

## Risk Control Measures

N/A - Template DotNet Library is a demonstration template with no safety-critical functionality
requiring risk control measures (IEC 62304 §5.3.3).

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

## Design Constraints

- **Simplicity**: Minimal functionality to serve as template
- **Compliance**: All functionality must be traceable to requirements
- **Quality**: Zero warnings, full test coverage, complete documentation
- **Portability**: Compatible across supported .NET platforms

### Platform Support

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

### Integration Patterns

- **NuGet Packaging**: Standard .NET library packaging and distribution
- **CI/CD Integration**: Automated build, test, and quality validation
- **Requirements Traceability**: All features linked to passing tests
- **Review Management**: Systematic file review using ReviewMark patterns
