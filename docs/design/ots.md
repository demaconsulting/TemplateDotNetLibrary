# OTS Integration Design

This document describes the overall Off-The-Shelf (OTS) integration strategy for the Template
DotNet Library repository.

## Overview

The Template DotNet Library itself has zero runtime NuGet dependencies — the `Demo` unit is
implemented exclusively against the .NET Base Class Library. All OTS items listed below are
build-time and quality-pipeline tools, not runtime library dependencies. Each OTS item provides one
stage of the documentation, requirements-traceability, testing, and quality-reporting pipeline
invoked by `build.ps1`, `lint.ps1`, and the `.github/workflows/build.yaml` CI workflow. None of
these tools are linked into, or shipped with, the compiled NuGet package.

## OTS Items

| OTS Item    | Purpose                                                              |
|-------------|----------------------------------------------------------------------|
| BuildMark   | Generates build-notes documentation from GitHub Actions metadata     |
| FileAssert  | Validates generated documents (HTML/PDF) against acceptance criteria |
| Pandoc      | Converts Markdown documentation to HTML                              |
| ReqStream   | Enforces requirements-to-test traceability                           |
| ReviewMark  | Enforces file review coverage and currency                           |
| SarifMark   | Converts CodeQL SARIF results into a markdown report                 |
| SonarMark   | Generates a SonarCloud quality report                                |
| VersionMark | Captures and publishes tool-version information                      |
| WeasyPrint  | Converts HTML documentation to PDF                                   |
| xUnit       | Discovers and executes unit and integration tests                    |

Each item's individual design document (`docs/design/ots/{ots-name}.md`) records its Purpose,
Features Used, and Integration Pattern. Each item's requirements and verification evidence are
recorded in `docs/reqstream/ots/{ots-name}.yaml` and `docs/verification/ots/{ots-name}.md`
respectively.
