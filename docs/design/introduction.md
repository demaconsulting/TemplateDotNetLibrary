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

Version applicability: This design applies to all versions of the Template DotNet Library.

The following topics are explicitly excluded from this design documentation:

- External library internals and third-party OTS components
- Build pipeline configuration and CI/CD processes
- Deployment, packaging, and distribution mechanisms
- Infrastructure and hosting environment details

## Software Structure

The following tree diagram shows how the Template DotNet Library software items are organized
across System, Subsystem, and Unit levels according to software-items classification standards:

```text
TemplateDotNetLibrary (System)
└── Demo (Unit)
```

This template demonstrates a minimal system structure with no subsystems — it contains only the
`Demo` unit directly under the system level. In more complex implementations, subsystems would
organize related units and provide architectural boundaries with well-defined interfaces and
responsibilities.

## Companion Artifact Structure

Each software item has corresponding artifacts in parallel directory trees:

```text
TemplateDotNetLibrary (System)
└── Demo (Unit)
```

Each software item has artifacts in these parallel locations:

- Requirements: `docs/reqstream/{system}/.../{item}.yaml` (kebab-case)
- Design docs: `docs/design/{system}/.../{item}.md` (kebab-case)
- Verification design: `docs/verification/{system}/.../{item}.md` (kebab-case)
- Source code: `src/{System}/.../{Item}.cs` (PascalCase for C#)
- Tests: `test/{System}.Tests/.../{Item}Tests.cs` (PascalCase for C#)
- Review-sets: defined in `.reviewmark.yaml`

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

## References

- [REF-1] Template DotNet Library User Guide
- [REF-2] Template DotNet Library Repository (<https://github.com/demaconsulting/TemplateDotNetLibrary>)
