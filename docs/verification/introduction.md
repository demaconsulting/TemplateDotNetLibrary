# Introduction

This document provides the verification design for the Template DotNet Library, a .NET library
demonstrating best practices for DEMA Consulting DotNet Libraries.

## Purpose

The purpose of this document is to serve as the verification design entry point and document how
requirements will be tested across all software items in the Template DotNet Library system. This
documentation enables formal review by mapping every requirement to named test scenarios, supports
compliance auditing by providing clear traceability from requirements through verification design
to tests, and ensures test completeness can be assessed without reading implementation code.

This document is intended for:

- Software developers implementing and maintaining tests
- Code reviewers validating test completeness against requirements
- Compliance auditors tracing requirements through verification design to tests
- Quality assurance teams validating test coverage and scenario adequacy

## Scope

This document covers the verification design for the Template DotNet Library system and its
constituent software items, specifically:

- **TemplateDotNetLibrary (System)** — The complete .NET library template system
- **Demo (Unit)** — Demonstration greeting class providing example functionality

The following OTS items are also covered:

- **BuildMark** — build-notes documentation tool
- **FileAssert** — document assertion tool
- **Pandoc** — Markdown-to-HTML conversion tool
- **ReqStream** — requirements traceability tool
- **ReviewMark** — file review enforcement tool
- **SarifMark** — SARIF report conversion tool
- **SonarMark** — SonarCloud quality report tool
- **VersionMark** — tool-version documentation tool
- **WeasyPrint** — HTML-to-PDF conversion tool
- **xUnit** — unit-testing framework

This verification documentation covers the same software items as the design documentation.

Version applicability: This verification design applies to all versions of the Template DotNet
Library.

The following topics are explicitly excluded from this verification documentation:

- Build pipeline and CI/CD process testing
- Infrastructure and hosting environment testing

## Companion Artifact Structure

Each software item in the structure below has corresponding artifacts in parallel directory trees:

```text
TemplateDotNetLibrary (System)
└── Demo (Unit)

OTS Items
├── BuildMark
├── FileAssert
├── Pandoc
├── ReqStream
├── ReviewMark
├── SarifMark
├── SonarMark
├── VersionMark
├── WeasyPrint
└── xUnit
```

In-house items have artifacts in these parallel locations:

- Requirements: `docs/reqstream/{system}/.../{item}.yaml` (kebab-case)
- Design docs: `docs/design/{system}/.../{item}.md` (kebab-case)
- Verification design: `docs/verification/{system}/.../{item}.md` (kebab-case)
- Source code: `src/{System}/.../{Item}.cs` (PascalCase for C#)
- Tests: `test/{System}.Tests/.../{Item}Tests.cs` (PascalCase for C#)

OTS items have parallel artifacts in:

- Requirements: `docs/reqstream/ots/{ots-name}.yaml` (kebab-case)
- Verification: `docs/verification/ots/{ots-name}.md` (kebab-case)

Review-sets: defined in `.reviewmark.yaml`

## References

- [REF-1] Template DotNet Library User Guide (<https://github.com/demaconsulting/TemplateDotNetLibrary/blob/main/docs/user_guide/introduction.md>)
- [REF-2] Template DotNet Library Repository (<https://github.com/demaconsulting/TemplateDotNetLibrary>)
