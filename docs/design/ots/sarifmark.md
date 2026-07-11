## SarifMark

### Purpose

DemaConsulting.SarifMark is used to convert CodeQL SARIF scan results into a human-readable
markdown report. It was chosen because it lets the pipeline surface static-analysis findings as
part of the standard build-artifact documentation set, alongside SonarMark's cloud-hosted quality
data, rather than requiring reviewers to open the SARIF file separately.

### Features Used

- SARIF-file reading of CodeQL code-scanning output
- Markdown report generation summarizing SARIF findings
- Enforcement mode, which returns a non-zero exit code when the SARIF input contains reported
  issues

### Integration Pattern

SarifMark is invoked as a `dotnet tool` (`dotnet sarifmark`) from `.github/workflows/build.yaml`
after the CodeQL scanning step, both to generate `docs/code_quality/generated/codeql-quality.md`
and to enforce a clean result. It is a stateless CLI invocation — each run reads a SARIF file,
writes its markdown report or returns an exit code, and exits; there is no initialization,
configuration object, or disposal step.
