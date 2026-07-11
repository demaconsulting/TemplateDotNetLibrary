## ReqStream

### Purpose

DemaConsulting.ReqStream is used to enforce that every requirement in `requirements.yaml` is
linked to passing test evidence. It was chosen because it provides both structural linting of
requirements files and enforcement-mode traceability checking, making incomplete or unproven
requirements a build-breaking condition rather than a manual review task.

### Features Used

- Requirements-file loading and parsing (`requirements.yaml` and its `includes`)
- Trace-matrix generation linking requirements to TRX test-result evidence
- Requirements report and justifications document export to markdown
- Tag-based requirement filtering
- Enforcement mode (`--enforce`), which exits non-zero when any requirement lacks test evidence
- Lint mode (`--lint`), which checks requirements YAML files for structural and semantic issues

### Integration Pattern

ReqStream is invoked as a `dotnet tool` from two places: `lint.ps1` runs
`dotnet reqstream --lint --requirements requirements.yaml` as an early-detection lint gate, and
`.github/workflows/build.yaml` runs `dotnet reqstream --enforce` with all accumulated TRX
test-evidence files to generate `requirements.md`, `justifications.md`, and `trace_matrix.md`.
It is a stateless CLI invocation — each run reads `requirements.yaml` and TRX files, writes its
reports, and exits; there is no initialization, configuration object, or disposal step.
