# OTS Verification Evidence

This document describes the overall Off-The-Shelf (OTS) verification strategy for the Template
DotNet Library repository.

## Overview

Every OTS item used to build and verify this repository is verified through a combination of
self-validation CLI flags (where the tool provides a `--validate` or equivalent self-test mode)
and pipeline-evidence-based verification (where a passing CI pipeline run, having produced and
validated the expected output at each stage, constitutes proof that the tool executed correctly).
Each item's individual verification document (`docs/verification/ots/{ots-name}.md`) records the
detailed approach and named test scenarios.

## OTS Items

| OTS Item    | Verification Approach                                                       |
|-------------|-----------------------------------------------------------------------------|
| BuildMark   | Self-validation CLI suite plus pipeline evidence via build-notes document   |
| FileAssert  | Self-validation CLI suite plus transitive evidence from document assertions |
| Pandoc      | Pipeline evidence: FileAssert assertions on each generated HTML document    |
| ReqStream   | Self-validation CLI suite plus pipeline evidence via --enforce traceability |
| ReviewMark  | Self-validation CLI suite plus pipeline evidence via review plan/report     |
| SarifMark   | Self-validation CLI suite plus pipeline evidence via SARIF markdown report  |
| SonarMark   | Self-validation CLI suite plus pipeline evidence via SonarCloud report      |
| VersionMark | Self-validation CLI suite plus pipeline evidence via version data           |
| WeasyPrint  | Pipeline evidence: FileAssert assertions on each generated PDF document     |
| xUnit       | Self-validation via discovery, execution, and TRX reporting of tests        |
