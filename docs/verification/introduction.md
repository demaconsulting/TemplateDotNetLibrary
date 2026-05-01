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

This verification documentation covers the same software items as the design documentation. It
does not cover test infrastructure, build pipeline configuration, or third-party OTS components.

Version applicability: This verification design applies to all versions of the Template DotNet
Library.

The following topics are explicitly excluded from this verification documentation:

- OTS component verification (xUnit, ReqStream, ReviewMark, and other third-party tools)
- Build pipeline and CI/CD process testing
- Infrastructure and hosting environment testing

## Companion Artifact Structure

Each software item in the structure below has corresponding artifacts in parallel directory trees:

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

## References

<!-- TODO: Fill in for your project -->

- [Template DotNet Library User Guide][user-guide]
- [Template DotNet Library Repository][repo]

[user-guide]: ../user_guide/introduction.md
[repo]: https://github.com/demaconsulting/TemplateDotNetLibrary
