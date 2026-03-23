# UI Review Guide

This document defines the review criteria for WinUI work in
`Runway.App`.

The app currently has only a basic window shell, and the real input form
and result binding will be added later. Because of that, the main review
question right now is not "Does the screen look finished?" but "Is the
boundary with Core correct?"

## Core Principles

- Perform calculations in `Runway.Core`.
- Use the UI to collect inputs and display results.
- Do not duplicate the same calculation across XAML, code-behind, and
  ViewModel layers.

## Review Points

### Input Flow

- Can Personal and Business workspaces be entered separately?
- Can the remaining percentage and reset time be entered clearly?
- Is user guidance needed for invalid input?

### Result Display

- Is `Status` presented in a way users can understand?
- Are `HoursUntilReset` and `SafeUsagePerHour` easy to distinguish?
- Can the results for both workspaces be compared side by side?

### Responsibility Split

- Does the UI avoid recalculating status mapping?
- Are Core model names and UI labels still aligned enough to follow?
- Does the screen design avoid forcing unnecessary distortion into Core
  type contracts?

### Manual Verification

Any UI-focused PR should leave at least one manual verification flow.

Example:

1. Launch the app.
2. Enter Personal and Business values.
3. Trigger the calculation or refresh the result.
4. Confirm the expected status and summary text.

## Recommended Direction for the Current Stage

- Start by completing a single screen that captures and compares both
  workspaces.
- Prioritize input -> calculation -> display wiring over visual polish.
- Prefer user-facing language in the UI instead of exposing raw Core
  type names directly.
