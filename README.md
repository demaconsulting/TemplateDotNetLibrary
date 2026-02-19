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
- **Multi-Platform Support**: Builds and runs on Windows and Linux
- **Multi-Runtime Support**: Targets .NET 8, 9, and 10
- **MSTest V4**: Modern unit testing with MSTest framework version 4
- **Comprehensive CI/CD**: GitHub Actions workflows with quality checks and builds
- **Documentation Generation**: Automated build notes, user guide, code quality reports,
  requirements, justifications, and trace matrix

## Installation

Install the library using the .NET CLI:

```bash
dotnet add package TemplateDotNetLibrary
```

## Usage

```csharp
using TemplateDotNetLibrary;

var demo = new DemoClass();
var result = demo.DemoMethod("World");
```

## Documentation

Generated documentation includes:

- **Build Notes**: Release information and changes
- **User Guide**: Comprehensive usage documentation
- **Code Quality Report**: CodeQL and SonarCloud analysis results
- **Requirements**: Functional and non-functional requirements
- **Requirements Justifications**: Detailed requirement rationale
- **Trace Matrix**: Requirements to test traceability

## License

Copyright (c) DEMA Consulting. Licensed under the MIT License. See [LICENSE][link-license] for details.

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
