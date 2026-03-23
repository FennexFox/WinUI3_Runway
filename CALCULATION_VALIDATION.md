# Calculation Validation

This document defines how to validate changes to runway calculations in
`Runway.Core`.

The current flow is:

- input: `WorkspaceSnapshot`
- calculator: `PacingCalculator`
- output: `WorkspacePacingResult`

## Current Inputs and Outputs

### Input

`WorkspaceSnapshot` currently includes:

- `Workspace`
- `RemainingPercent`
- `CapturedAt`
- `ResetAt`

### Output

`WorkspacePacingResult` currently exposes:

- `Workspace`
- `Status`
- `HoursUntilReset`
- `SafeUsagePerHour`
- `SummaryMessage`

## Core Rules That Must Stay Validated

- If `ResetAt` is later than the current time, remaining hours should be
  calculated.
- If remaining hours are positive, safe usage per hour should be
  calculated.
- High remaining percentage should map to `Safe`.
- Threshold-range remaining percentage should map to `Warning`.
- Very low remaining percentage should map to `Critical`.
- A reset time in the past should map to `Unknown`.

The current tested thresholds are:

- `<= 10`: `Critical`
- `<= 30`: `Warning`
- otherwise: `Safe`

If the thresholds change, the tests and docs should change with them.

## Evidence Required for Calculation Changes

A PR or issue that changes calculation behavior should include at least:

- the input snapshot being assumed
- the expected status
- how the safe-per-hour calculation changes
- why the boundary behavior is correct

Prefer leaving examples in a concrete format like this:

```text
Workspace: Personal
RemainingPercent: 30
Now: 2026-01-01 12:00
ResetAt: 2026-01-01 20:00
Expected Status: Warning
Expected SafeUsagePerHour: 3.75
```

## Minimum Test Scenarios

These scenarios should remain covered whenever the calculator changes:

- `Safe` at a high remaining percentage
- `Warning` at the boundary
- `Critical` at a low remaining percentage
- `Unknown` when the reset time is already in the past

If the change is broader, also consider adding coverage for:

- fractional percentages
- very short time remaining
- assumptions behind Personal and Business comparison display
- summary message wording changes

## Things to Avoid

- Do not duplicate calculation rules in UI code-behind.
- Do not change thresholds or status mapping without tests.
- Do not leave README out of sync with the real calculation behavior.
