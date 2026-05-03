---
name: Verification Documentation
description: Follow these standards when creating software verification design documentation.
globs: ["docs/verification/**/*.md"]
---

# Required Standards

Read these standards first before applying this standard:

- **`technical-documentation.md`** - General technical documentation standards
- **`software-items.md`** - Software categorization (System/Subsystem/Unit/OTS)

# Core Principles

Verification design is the bridge between requirements and tests - it documents HOW
requirements will be verified, enabling reviewers to confirm test completeness without
reading implementation code.

# Required Structure and Documents

Organize under `docs/verification/` mirroring the software item hierarchy:

```text
docs/verification/
├── introduction.md              # Verification overview
├── {system-name}/               # System-level verification folder (one per system)
│   ├── {system-name}.md         # System-level verification design
│   ├── {subsystem-name}/        # Subsystem (kebab-case); may nest recursively
│   │   ├── {subsystem-name}.md  # Subsystem verification design
│   │   ├── {child-subsystem}/   # Child subsystem (same structure as parent)
│   │   └── {unit-name}.md       # Unit-level verification design documents
│   └── {unit-name}.md           # Top-level unit verification documents (if not in subsystem)
└── ots/                         # OTS items (one verification file per OTS item)
    └── {ots-name}.md            # Verification evidence for each OTS item
```

## introduction.md (MANDATORY)

Follow the standard `introduction.md` format from `technical-documentation.md`. Scope
covers all software items including OTS items (via self-validation if appropriate).

Include a Companion Artifact Structure note so agents and reviewers can navigate from any
artifact to all related files:

```text
In-house items have parallel artifacts in:
- Requirements: `docs/reqstream/{system}/.../{item}.yaml` (kebab-case)
- Design: `docs/design/{system}/.../{item}.md` (kebab-case)
- Verification: `docs/verification/{system}/.../{item}.md` (kebab-case)
- Source: `src/{System}/.../{Item}.{ext}` (cased per language)
- Tests: `test/{System}.Tests/.../{Item}Tests.{ext}` (cased per language)

OTS items have parallel artifacts in:
- Requirements: `docs/reqstream/ots/{ots-name}.yaml` (kebab-case)
- Verification: `docs/verification/ots/{ots-name}.md` (kebab-case)
- Tests: `test/{OtsName}.Tests/...` (cased per language, if required)

Review-sets: defined in `.reviewmark.yaml`
```

If the verification design references external documents (standards, specifications), include
a `## References` section in `introduction.md` only - do not add one to any other verification file.

## System Verification Design (MANDATORY)

For each system, create a kebab-case folder and `{system-name}.md` covering:

- System verification strategy and overall test approach
- Test environments and configuration required
- External interface simulation and test-harness design
- End-to-end and integration test scenarios covering system requirements
- Acceptance criteria and pass/fail conditions at the system boundary
- Coverage mapping of system requirements to system-level test scenarios

## Subsystem Verification Design (MANDATORY)

For each subsystem, create a kebab-case folder and `{subsystem-name}.md` covering:

- Subsystem verification strategy and integration test approach
- Dependencies that must be mocked or stubbed at the subsystem boundary
- Integration test scenarios covering subsystem requirements
- Coverage mapping of subsystem requirements to subsystem-level test scenarios

## Unit Verification Design (MANDATORY)

For each unit, create `{unit-name}.md` covering:

- Verification approach for each unit requirement
- Named test scenarios including boundary conditions, error paths, and normal-operation cases
- Which dependencies are mocked and how they are configured
- Coverage mapping of every unit requirement to at least one named test scenario

## OTS Verification Evidence (when OTS items are used)

For each OTS item, create `docs/verification/ots/{ots-name}.md` covering:

- The OTS item's required functionality (reference `docs/reqstream/ots/{ots-name}.yaml`)
- Verification of each requirement (using self-validation evidence if appropriate)
- Coverage mapping of OTS requirements to test scenarios

# Writing Guidelines

- **Test Coverage**: Map every requirement to at least one named test scenario so
  reviewers can verify completeness without reading test code
- **Scenario Clarity**: Name each scenario clearly - "Valid input returns parsed result" not "Test 1"
- **Boundary Conditions**: Call out boundary values, error inputs, and edge cases explicitly
- **Isolation Strategy**: Describe what is mocked or stubbed and why at each level
- **Traceability**: Link to requirements where applicable using ReqStream patterns
- **Verbal Cross-References**: Reference other documents by name - do not use markdown
  hyperlinks, which break in compiled PDFs

Mermaid diagrams may supplement text descriptions where test flow benefits from visual
representation, but must not replace text content.

# Quality Checks

Before submitting verification documentation, verify:

- [ ] Every requirement at each level is mapped to at least one named test scenario
- [ ] System verification documents cover end-to-end and integration scenarios
- [ ] Subsystem verification documents identify mocked boundaries and integration scenarios
- [ ] Unit verification documents identify individual scenarios including boundary and error paths
- [ ] Subsystem documentation folders use kebab-case names mirroring the source subsystem structure
- [ ] All documents follow technical documentation formatting standards
- [ ] Content is current with requirements and test implementation
- [ ] Every OTS item has `docs/verification/ots/{ots-name}.md` with requirement coverage
- [ ] Documents are integrated into ReviewMark review-sets for formal review
