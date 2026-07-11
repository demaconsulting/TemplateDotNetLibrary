## SonarMark

### Purpose

DemaConsulting.SonarMark is used to retrieve quality-gate and metrics data from SonarCloud and
render it as a markdown report. It was chosen because it lets the pipeline include SonarCloud's
quality-gate status, issues, and hot-spots directly in the release artifact documentation set,
next to SarifMark's CodeQL report.

### Features Used

- Quality-gate status retrieval from the SonarCloud API
- Issues retrieval from the SonarCloud API
- Hot-spots retrieval from the SonarCloud API
- Markdown report generation combining quality-gate, issues, and hot-spots data

### Integration Pattern

SonarMark is invoked as a `dotnet tool` (`dotnet sonarmark`) from `.github/workflows/build.yaml`
after the SonarCloud analysis step, to generate `docs/code_quality/generated/sonar-quality.md`.
It is a stateless CLI invocation — each run queries the live SonarCloud API, writes its markdown
report, and exits; there is no initialization, configuration object, or disposal step beyond the
project key and authentication token supplied on each invocation.
