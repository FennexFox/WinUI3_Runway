# Codex Runway for Windows

Codex Runway is a Windows desktop app project that estimates whether the
current usage pace is safe and shows **Personal Workspace** and
**Business Workspace** separately.

The project is also a practice vehicle for:

- understanding C# / .NET project structure
- building a Windows app with WinUI 3
- separating `App / Core / Tests`
- separating business logic from UI
- designing code that is easy to test

---

## Project Goals

The app is meant to answer these questions:

- Can I keep using this workspace safely right now?
- Given the remaining usage budget, what pace is still safe?
- Which workspace, Personal or Business, has more runway left?

The initial version focuses on entering the state of two workspaces and
showing a simple runway calculation from that input.

---

## Current Stage

The repository is still in the **initial structure setup** stage.

Completed so far:

- created the WinUI 3 app project
- split the solution into separate projects
- set up the `App`, `Core`, and `Tests` projects
- added initial domain files
- drafted the basic `PacingCalculator` flow
- added initial calculator-focused unit tests

Still in progress:

- refining the core domain model
- defining the calculation rules and status thresholds
- connecting the WinUI input screen to the Core layer
- fleshing out the Personal / Business comparison screen

At this stage, the priority is **getting the structure right before
trying to fully finish the app**.

---

## Current Implementation Snapshot

The current Core layer already has this calculation flow:

- `WorkspaceSnapshot` input
- `PacingCalculator.Calculate(...)` computation
- `WorkspacePacingResult` output

The current tests in `Runway.Tests` cover these basic rules:

- `Safe / Warning / Critical` classification from remaining percentage
- `Unknown` when the reset time has already passed
- safe usage per hour calculation

The WinUI side is still only a basic window shell. Input forms and
result binding will be connected in a later step.

---

## Workflow Documents

This repository currently uses a lightweight workflow that emphasizes
clear structure and calculation validation over heavy automation.

- [DEVELOPMENT_WORKFLOW.md](./DEVELOPMENT_WORKFLOW.md): how work is
  split across `feature`, `bug`, `investigation`, and `release`
- [CALCULATION_VALIDATION.md](./CALCULATION_VALIDATION.md): the
  validation rules to follow when changing runway calculations
- [UI_REVIEW.md](./UI_REVIEW.md): the review criteria for WinUI and
  Core integration work

---

## Solution Structure

```text
WinUI3_Runway.slnx
├─ Runway.App        # WinUI 3 app (UI, entry point)
├─ Runway.Core       # domain models and calculation logic
└─ Runway.Tests      # unit tests
```
