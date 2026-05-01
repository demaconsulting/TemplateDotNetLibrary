# Template DotNet Library

[![GitHub forks][badge-forks]][link-forks]
[![GitHub stars][badge-stars]][link-stars]
[![GitHub contributors][badge-contributors]][link-contributors]
[![License][badge-license]][link-license]
[![Build][badge-build]][link-build]
[![Quality Gate][badge-quality]][link-quality]
[![Security][badge-security]][link-security]
[![NuGet][badge-nuget]][link-nuget]

DEMA Consulting template project for DotNet Libraries, demonstrating best practices for building reusable .NET libraries.

## Features

This template demonstrates:

- **Simple Library Structure**: Demo class with example methods
- **Multi-Platform Support**: Builds and runs on Windows, Linux, and macOS
- **Multi-Runtime Support**: Targets .NET Standard 2.0, .NET 8, 9, and 10
- **xUnit v3**: Modern unit testing with xUnit framework version 3
- **Comprehensive CI/CD**: GitHub Actions workflows with quality checks and builds
- **Linting Enforcement**: markdownlint, cspell, and yamllint enforced on every CI run
- **Continuous Compliance**: Compliance evidence generated automatically on every CI run, following
  the [Continuous Compliance][link-continuous-compliance] methodology
- **SonarCloud Integration**: Quality gate and security analysis on every build
- **Documentation Generation**: Automated build notes, user guide, code quality reports,
  requirements, justifications, and trace matrix
- **Requirements Traceability**: Requirements linked to passing tests with auto-generated trace matrix

## Installation

Install the library using the .NET CLI:

```bash
dotnet add package TemplateDotNetLibrary
```

## Usage

```csharp
using TemplateDotNetLibrary;

var demo = new Demo();
var result = demo.DemoMethod("World"); // result = "Hello, World!"
```

## Documentation

Generated documentation includes:

- **Build Notes**: Release information and changes
- **User Guide**: Comprehensive usage documentation
- **Code Quality Report**: CodeQL and SonarCloud analysis results
- **Requirements**: Functional and non-functional requirements
- **Requirements Justifications**: Detailed requirement rationale
- **Trace Matrix**: Requirements to test traceability

## Contributing

Contributions are welcome. See [CONTRIBUTING.md][link-contributing] for development setup, coding
standards, and the pull request process.

## License

Copyright (c) DEMA Consulting. Licensed under the MIT License. See [LICENSE][link-license] for details.

By contributing to this project, you agree that your contributions will be licensed under the MIT License.

<!-- Badge References -->
[badge-forks]: https://img.shields.io/github/forks/demaconsulting/TemplateDotNetLibrary?style=plastic
[badge-stars]: https://img.shields.io/github/stars/demaconsulting/TemplateDotNetLibrary?style=plastic
[badge-contributors]: https://img.shields.io/github/contributors/demaconsulting/TemplateDotNetLibrary?style=plastic
[badge-license]: https://img.shields.io/github/license/demaconsulting/TemplateDotNetLibrary?style=plastic
[badge-build]: https://img.shields.io/github/actions/workflow/status/demaconsulting/TemplateDotNetLibrary/build_on_push.yaml?style=plastic
[badge-quality]: https://sonarcloud.io/api/project_badges/measure?project=demaconsulting_TemplateDotNetLibrary&metric=alert_status
[badge-security]: https://sonarcloud.io/api/project_badges/measure?project=demaconsulting_TemplateDotNetLibrary&metric=security_rating
[badge-nuget]: https://img.shields.io/nuget/v/TemplateDotNetLibrary?style=plastic

<!-- Link References -->
[link-forks]: https://github.com/demaconsulting/TemplateDotNetLibrary/network/members
[link-stars]: https://github.com/demaconsulting/TemplateDotNetLibrary/stargazers
[link-contributors]: https://github.com/demaconsulting/TemplateDotNetLibrary/graphs/contributors
[link-license]: https://github.com/demaconsulting/TemplateDotNetLibrary/blob/main/LICENSE
[link-build]: https://github.com/demaconsulting/TemplateDotNetLibrary/actions/workflows/build_on_push.yaml
[link-quality]: https://sonarcloud.io/dashboard?id=demaconsulting_TemplateDotNetLibrary
[link-security]: https://sonarcloud.io/dashboard?id=demaconsulting_TemplateDotNetLibrary
[link-nuget]: https://www.nuget.org/packages/TemplateDotNetLibrary
[link-continuous-compliance]: https://github.com/demaconsulting/ContinuousCompliance
[link-contributing]: https://github.com/demaconsulting/TemplateDotNetLibrary/blob/main/CONTRIBUTING.md
