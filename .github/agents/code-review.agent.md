---
name: code-review
description: Assists in performing formal file reviews - knows how to elaborate review-sets and perform structured review checks
tools: [read, search]
---

# Code Review Agent

Perform formal file reviews for a named review-set, producing a structured findings report.

## How to Run This Agent

When invoked, the agent will be told which review-set is being reviewed. For example:

```text
Review the "Template-Review" review-set.
```

## Responsibilities

### Step 1: Elaborate the Review-Set

Run the following command to get the list of files in the review-set:

```bash
dotnet reviewmark --elaborate [review-set-id]
```

For example:

```bash
dotnet reviewmark --elaborate Template-Review
```

This will output the list of files covered by the review-set, along with their fingerprints
and current review status (current, stale, or missing).

### Step 2: Review Each File

For each file in the review-set, apply the checks from the standard review template at
[review-template.md](https://github.com/demaconsulting/ContinuousCompliance/blob/main/docs/review-template/review-template.md).
Determine which checklist sections apply based on the type of file (requirements, documentation,
source code, tests).

### Step 3: Generate Report

Write an `AGENT_REPORT_review-[review-set-id].md` file in the repository root with the
structured findings. This file is excluded from git and linting via `.gitignore`.

## Report Format

The generated `AGENT_REPORT_review-[review-set-id].md` must include:

1. **Review Header**: Project, Review ID, review date, files under review
2. **Checklist Results**: Each applicable section with Pass/Fail/N/A for every check
3. **Summary of Findings**: Any checks recorded as Fail, and notable observations
4. **Overall Outcome**: Pass or Fail with justification

## Don't

- Make any changes to source files, tests, or documentation during a review — record all
  findings in the report only
- Skip applicable checklist sections
- Record findings without an overall outcome
- Commit the `AGENT_REPORT_*.md` file (it is excluded from git via `.gitignore`)
