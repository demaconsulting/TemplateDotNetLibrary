## VersionMark

### Purpose

DemaConsulting.VersionMark is used to capture and publish version metadata for each `dotnet tool`
used in the pipeline. It was chosen because pinned build-tool versions must be visible in the
release artifacts for compliance auditing, without hand-maintaining a versions list that would go
stale as tools are updated.

### Features Used

- Version capture (`--capture`) of tool-version JSON files per CI job
- Version publishing (`--publish`) combining captured JSON files into a versions markdown report
- Lint mode (`--lint`), which validates the `.versionmark.yaml` configuration for structural and
  semantic errors

### Integration Pattern

VersionMark is invoked as a `dotnet tool` from three places: `lint.ps1` runs
`dotnet versionmark --lint` as an early-detection configuration check; each CI job in
`.github/workflows/build.yaml` runs `dotnet versionmark --capture` to record the versions of tools
used in that job; and the build-docs job runs `dotnet versionmark --publish` to produce
`docs/build_notes/generated/versions.md`, included in the Build Notes document. It is a stateless
CLI invocation — each run reads its configuration/input files, writes its output, and exits; there
is no initialization, long-lived configuration object, or disposal step.
