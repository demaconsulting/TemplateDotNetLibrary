#!/usr/bin/env bash
# Build and test Template DotNet Library

set -e  # Exit on error

echo "🔧 Building Template DotNet Library..."
dotnet build --configuration Release

echo "🧪 Running unit tests..."
dotnet test --configuration Release

echo "✨ Build and tests completed successfully!"
