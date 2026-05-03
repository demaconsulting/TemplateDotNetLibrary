# xUnit Verification

This document provides the verification evidence for the xUnit OTS software item. Requirements
for this OTS item are defined in the xUnit OTS Software Requirements document.

## Required Functionality

xUnit v3 (xunit.v3 and xunit.runner.visualstudio) is the unit-testing framework used by the
project. It discovers and runs all test methods and writes TRX result files that feed into coverage
reporting and requirements traceability. Passing tests confirm the framework is functioning
correctly.

## Verification Approach

xUnit is verified by self-validation evidence from the CI pipeline. Each scenario names a specific
test method that xUnit must discover, execute, and record in a TRX result file. A passing pipeline
run for all scenarios constitutes evidence that both requirements are satisfied.

## Test Scenarios

### Demo_DemoMethod_DefaultPrefix_ReturnsGreeting

**Scenario**: xUnit discovers and runs this test; the test verifies that DemoMethod returns the
expected greeting using the default prefix.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_DemoMethod_CustomPrefix_ReturnsGreeting

**Scenario**: xUnit discovers and runs this test; the test verifies that DemoMethod returns the
expected greeting using a custom prefix.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_DemoMethod_NullInput_ThrowsArgumentNullException

**Scenario**: xUnit discovers and runs this test; the test verifies that DemoMethod rejects a null
argument with ArgumentNullException.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_DemoMethod_EmptyInput_ThrowsArgumentException

**Scenario**: xUnit discovers and runs this test; the test verifies that DemoMethod rejects an
empty string argument with ArgumentException.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_Constructor_NullPrefix_ThrowsArgumentNullException

**Scenario**: xUnit discovers and runs this test; the test verifies that the constructor rejects a
null prefix with ArgumentNullException.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_Constructor_EmptyPrefix_ThrowsArgumentException

**Scenario**: xUnit discovers and runs this test; the test verifies that the constructor rejects an
empty string prefix with ArgumentException.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_DefaultPrefix_Read_IsHello

**Scenario**: xUnit discovers and runs this test; the test verifies that the DefaultPrefix constant
has the value "Hello".

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_Prefix_WithCustomConstruction_ReturnsCustomPrefix

**Scenario**: xUnit discovers and runs this test; the test verifies that the Prefix property
returns the value supplied at construction.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

### Demo_DefaultConstructor_WithNoArgs_SetsDefaultPrefix

**Scenario**: xUnit discovers and runs this test; the test verifies that the default constructor
sets Prefix to the DefaultPrefix constant.

**Expected**: xUnit executes the test, the test passes, and the result appears in the TRX output.

**Requirement coverage**: `Template-OTS-xUnit-Execute`, `Template-OTS-xUnit-Report`.

## Requirements Coverage

- **`Template-OTS-xUnit-Execute`**: Demo_DemoMethod_DefaultPrefix_ReturnsGreeting,
  Demo_DemoMethod_CustomPrefix_ReturnsGreeting,
  Demo_DemoMethod_NullInput_ThrowsArgumentNullException,
  Demo_DemoMethod_EmptyInput_ThrowsArgumentException,
  Demo_Constructor_NullPrefix_ThrowsArgumentNullException,
  Demo_Constructor_EmptyPrefix_ThrowsArgumentException, Demo_DefaultPrefix_Read_IsHello,
  Demo_Prefix_WithCustomConstruction_ReturnsCustomPrefix,
  Demo_DefaultConstructor_WithNoArgs_SetsDefaultPrefix
- **`Template-OTS-xUnit-Report`**: Demo_DemoMethod_DefaultPrefix_ReturnsGreeting,
  Demo_DemoMethod_CustomPrefix_ReturnsGreeting,
  Demo_DemoMethod_NullInput_ThrowsArgumentNullException,
  Demo_DemoMethod_EmptyInput_ThrowsArgumentException,
  Demo_Constructor_NullPrefix_ThrowsArgumentNullException,
  Demo_Constructor_EmptyPrefix_ThrowsArgumentException, Demo_DefaultPrefix_Read_IsHello,
  Demo_Prefix_WithCustomConstruction_ReturnsCustomPrefix,
  Demo_DefaultConstructor_WithNoArgs_SetsDefaultPrefix
