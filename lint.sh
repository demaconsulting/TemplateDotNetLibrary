#!/bin/bash

# Comprehensive Linting Script
#
# PURPOSE:
# - Run ALL lint checks when executed (no options or modes)
# - Output lint failures directly for agent parsing
# - NO command-line arguments, pretty printing, or colorization
# - Agents execute this script to identify files needing fixes

lint_error=0

# Install npm dependencies
npm install --silent || lint_error=1

# Create Python virtual environment (for yamllint)
if [ ! -d ".venv" ]; then
  python -m venv .venv || lint_error=1
fi

# Activate Python virtual environment
source .venv/bin/activate || lint_error=1

# Install Python tools
pip install -r pip-requirements.txt --quiet --disable-pip-version-check || lint_error=1

# Run spell check
npx cspell --no-progress --no-color --quiet "**/*.{md,yaml,yml,json,cs,cpp,hpp,h,txt}" || lint_error=1

# Run markdownlint check
npx markdownlint-cli2 "**/*.md" || lint_error=1

# Run yamllint check
yamllint . || lint_error=1

# Run .NET formatting check (verifies no changes are needed)
dotnet format --verify-no-changes || lint_error=1

exit $lint_error
