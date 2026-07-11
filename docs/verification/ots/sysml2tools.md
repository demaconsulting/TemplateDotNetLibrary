# SysML2Tools Verification

This document provides the verification evidence for the `SysML2Tools` OTS software item.

## Required Functionality

DemaConsulting.SysML2Tools validates the SysML2 architecture model under `docs/sysml2/` for
syntax and reference errors, and renders each view declared in
`docs/sysml2/views/design-views.sysml` to an SVG diagram embedded in the design documentation.
Both behaviors run in the same CI pipeline that produces the compiled Design document, so a
successful pipeline run is evidence that SysML2Tools executed without error.

## Verification Approach

SysML2Tools is verified by two complementary layers of evidence. First, the CI pipeline runs
`dotnet sysml2tools --validate --results artifacts/sysml2tools-self-validation.trx`, which
exercises the tool's built-in self-test suite against known-good and known-bad model fixtures
and writes a TRX file consumed by `reqstream --enforce`.

Second, `lint.ps1` runs `dotnet sysml2tools lint 'docs/sysml2/**/*.sysml'` against the actual
Template DotNet Library model and fails the build on any syntax or reference error. The build-docs
job runs `dotnet sysml2tools render` to produce one SVG file per declared view under
`docs/design/generated/`. FileAssert then directly asserts that each declared view's SVG file
exists and is well-formed XML with an `<svg>` root element (`SysML2Tools_SoftwareStructureViewSvg`,
`SysML2Tools_TemplateDotNetLibraryViewSvg`), before Pandoc compiles `docs/design/*.md`, which embed
those SVG files by filename. A CI build failure at any of these steps is evidence that SysML2Tools
did not produce the required model validation or diagrams against the real model.

## Test Scenarios

### SysML2Tools_LintSelfTest

**Scenario**: SysML2Tools is invoked with `--validate`, which exercises `lint` against a known-good
and a known-bad model fixture as part of its built-in self-test suite.

**Expected**: Exits 0 with no reported syntax or reference errors for the valid fixture, and
correctly reports an error for the invalid fixture.

**Requirement coverage**: `Template-OTS-SysML2Tools-Lint`.

### SysML2Tools_RenderSvgSelfTest

**Scenario**: SysML2Tools is invoked with `--validate`, which exercises `render --format svg`
against a known-good model fixture as part of its built-in self-test suite.

**Expected**: Exits 0 and produces a non-empty SVG file for the fixture's declared view.

**Requirement coverage**: `Template-OTS-SysML2Tools-Render`.

### SysML2Tools_SoftwareStructureViewSvg

**Scenario**: The build-docs CI job runs `dotnet sysml2tools render` against the real Template
DotNet Library model, then FileAssert checks the resulting file at
`docs/design/generated/SoftwareStructureView.svg`.

**Expected**: Exactly one file exists at that path, and it is well-formed XML with a root element
named `svg`.

**Requirement coverage**: `Template-OTS-SysML2Tools-Render`.

### SysML2Tools_TemplateDotNetLibraryViewSvg

**Scenario**: The build-docs CI job runs `dotnet sysml2tools render` against the real Template
DotNet Library model, then FileAssert checks the resulting file at
`docs/design/generated/TemplateDotNetLibraryView.svg`.

**Expected**: Exactly one file exists at that path, and it is well-formed XML with a root element
named `svg`.

**Requirement coverage**: `Template-OTS-SysML2Tools-Render`.

## Requirements Coverage

- **`Template-OTS-SysML2Tools-Lint`**: SysML2Tools_LintSelfTest
- **`Template-OTS-SysML2Tools-Render`**: SysML2Tools_RenderSvgSelfTest,
  SysML2Tools_SoftwareStructureViewSvg, SysML2Tools_TemplateDotNetLibraryViewSvg
