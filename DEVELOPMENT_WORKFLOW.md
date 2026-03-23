# Development Workflow

This document defines how WinUI3_Runway work should be tracked and what
kind of validation is expected for each category.

At the current stage, the priority is not complex process automation.
The priority is making these flows explicit and separate:

- Core calculation rule design
- UI and Core integration
- architectural boundary decisions
- keeping changes backed by testable evidence

## Core Principles

- Keep calculation logic in `Runway.Core`.
- Keep WinUI screens focused on displaying Core results rather than
  reimplementing calculations.
- Pair behavior changes with tests whenever possible.
- Update README and workflow docs when they drift from the actual
  structure.

## Choosing the Right Issue Type

### Feature request

Use this when the work is about:

- adding a new user-facing capability
- improving the input flow, comparison screen, or result presentation
- introducing a new UX flow built on top of the calculation results

A good feature request should include:

- the user problem being solved
- the expected behavior
- the affected area
- clear non-goals or scope limits

### Bug report

Use this when:

- a calculation result is incorrect
- WinUI behavior breaks in a reproducible way
- input and output wiring is wrong

A good bug report should include:

- reproducible steps
- expected and actual results
- the related screen or calculation area
- any available evidence

### Investigation

Use this when the next step is to decide what is true before making a
change:

- when a design decision is still unresolved
- when a calculation rule is ambiguous
- when structural boundaries need review
- when ownership between UI and Core needs to be settled

The point of an investigation is to track a question that does not yet
have a settled answer.

### Release checklist

Use this when:

- preparing a release tag
- collecting README, test, and manual validation status in one place

At this stage, explicit release notes and validation evidence matter
more than heavyweight release automation.

## Area Labels

Use these default areas in issues and discussions:

- `core-calculation`: runway rules and domain models
- `ui`: WinUI screens, inputs, and displayed state
- `app-shell`: app startup, window shell, and project wiring
- `testing`: test code and validation infrastructure
- `docs`: README and workflow documents
- `repo-meta`: build, templates, and repository assets

## Done Criteria

### Core Calculation Changes

- The input and output rules should be described.
- Related tests should be added or updated.
- Boundary cases and exceptional cases should be called out.

### UI Changes

- Explain which Core results are shown and how they are presented.
- Do not duplicate calculation logic in the UI layer.
- Leave at least one manual verification flow.

### Documentation or Process Changes

- Do not leave contradictions with README or related workflow docs.
- Keep issue templates aligned with the actual repository state.

## PR Preparation Notes

PRs should include:

- what changed
- why it was needed
- whether the change affects calculation rules, UI ownership, or
  architectural decisions
- what tests or manual checks were performed
