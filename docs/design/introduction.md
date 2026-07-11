# Introduction

This document provides the detailed design for the Template DotNet Library, a .NET library
demonstrating best practices for DEMA Consulting DotNet Libraries.

## Purpose

The purpose of this document is to serve as the design entry point and provide detailed design
specifications for the Template DotNet Library system. This documentation enables formal code
review by providing implementation specifications, supports compliance auditing by maintaining
clear traceability from requirements through design to code, aids maintenance by documenting
system structure and interactions, and ensures quality assurance through detailed technical
specifications.

This document is intended for:

- Software developers implementing and maintaining the system
- Code reviewers validating implementation against design
- Compliance auditors tracing requirements through design to implementation
- Quality assurance teams validating system behavior

## Scope

This document covers the detailed design of the Template DotNet Library system and its constituent
software items, specifically:

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
- **SysML2Tools** — architecture model lint and diagram rendering tool
- **VersionMark** — tool-version documentation tool
- **WeasyPrint** — HTML-to-PDF conversion tool
- **xUnit** — unit-testing framework

Version applicability: This design applies to all versions of the Template DotNet Library.

The following topics are explicitly excluded from this design documentation:

- External library internals and third-party OTS components
- Build pipeline configuration and CI/CD processes
- Deployment, packaging, and distribution mechanisms
- Infrastructure and hosting environment details
- Test projects and test infrastructure

## Software Structure

The software structure is modeled in SysML2 under `docs/sysml2/` and rendered to the
diagram below by SysML2Tools as part of the build pipeline. AI agents should query the
SysML2 model directly (see the `sysml2tools-query` skill) rather than parsing this
diagram or the prose below.

![Software Structure](SoftwareStructureView.svg)

This template demonstrates a minimal system structure with no subsystems — it contains only the
`Demo` unit directly under the system level. In more complex implementations, subsystems would
organize related units and provide architectural boundaries with well-defined interfaces and
responsibilities.

## Folder Layout

The source code folder structure mirrors the software structure organization, with file paths
and descriptions as follows:

```text
src/DemaConsulting.TemplateDotNetLibrary/
└── Demo.cs                     — Demonstration greeting class implementing template functionality
```

This flat folder structure reflects the single-unit nature of this template system. As the system
grows with additional subsystems and units, the folder structure will expand to mirror the
software architecture with subsystem-specific folders containing their respective units.

## Document Conventions

Throughout this document:

- Class names, method names, property names, and file names appear in `monospace` font.
- The word **shall** denotes a design constraint that the implementation must satisfy.
- Section headings within each unit chapter follow a consistent structure: overview, data model,
  methods/algorithms, and interactions with other units.
- Text tables are used in preference to diagrams, which may not render in all PDF viewers.

## Companion Artifact Structure

Each software item has corresponding artifacts in parallel directory trees:

- Requirements: `docs/reqstream/{system}/.../{item}.yaml` (kebab-case)
- Design docs: `docs/design/{system}/.../{item}.md` (kebab-case)
- Verification design: `docs/verification/{system}/.../{item}.md` (kebab-case)
- Source code: `src/{System}/.../{Item}.cs` (PascalCase for C#)
- Tests: `test/{System}.Tests/.../{Item}Tests.cs` (PascalCase for C#)
- SysML2 model: `docs/sysml2/model/{system}/.../{item}.sysml` (kebab-case)
- Review-sets: defined in `.reviewmark.yaml`

## References

- Template DotNet Library User Guide — the compiled User Guide document for this repository.
- Template DotNet Library Repository — the TemplateDotNetLibrary source repository hosted on
  GitHub.
