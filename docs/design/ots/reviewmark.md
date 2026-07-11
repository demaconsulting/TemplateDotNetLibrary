## ReviewMark

### Purpose

DemaConsulting.ReviewMark is used to manage file-review status enforcement. It was chosen because
it turns the informal practice of "review before merge" into an enforceable, structured process:
review-sets, review evidence, and review currency are all tracked and machine-checkable rather
than relying on manual sign-off.

### Features Used

- Review-plan generation (`--plan`) from `.reviewmark.yaml` review-set definitions
- Review-report generation (`--report`) documenting review coverage and currency against the
  evidence store
- Evidence-index scanning (`--index`) of PDF review evidence into an `index.json` catalogue
- Enforcement mode (`--enforce`), which exits non-zero when files in a review-set are not current
- Elaboration mode (`--elaborate`), which prints a review-set's ID, fingerprint, and file list for
  agent consumption
- Lint mode (`--lint`), which validates `.reviewmark.yaml` for structural and semantic issues
- Working-directory override (`--dir`)

### Integration Pattern

ReviewMark is invoked as a `dotnet tool` from three places: `lint.ps1` runs
`dotnet reviewmark --lint` as an early-detection configuration check, and
`.github/workflows/build.yaml` runs ReviewMark to generate
`docs/code_review_plan/generated/plan.md` and `docs/code_review_report/generated/report.md`, and
to enforce review currency against the evidence store published on the repository's `reviews`
branch. It is a stateless CLI invocation — each run reads `.reviewmark.yaml` and the evidence
source, produces its output or exit code, and exits; there is no initialization, configuration
object, or disposal step.
