# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ITF Pattern Training is a Blazor WebAssembly (client-side only, no backend) Progressive Web App for ITF Taekwon-Do competition training and scoring. It is deployed as a static site on GitHub Pages.

## Build & Development Commands

```bash
# Build
dotnet build ITFPatternTraining.csproj

# Publish (as deployed to GitHub Pages)
dotnet publish ./ITFPatternTraining.csproj -c:Release -p:GHPages=true -o dist/Web --nologo

# Required workload for WASM builds (run once per machine)
dotnet workload install wasm-tools
```

There are no automated tests in this project.

## Architecture

### Tech Stack
- **Framework:** .NET 10, Blazor WebAssembly
- **UI Library:** Radzen Blazor v10
- **Deployment:** GitHub Pages (`gh-pages` branch), automated via `.github/workflows/dotnet.yml` on push to `main`

### Core Files
- **`ITFPatterns.cs`** — All domain logic: pattern lists by belt/Dan rank, `RoundScore` (deduction-based scoring from 10.0 in 0.2 steps), `SelectedPattern`, and `SparringRoundScore` (point + warning tracking)
- **`Sparring.cs`** — Sparring scoring state/logic
- **`Program.cs`** — App entry point; registers singleton state services

### State Management
State is held in singleton services registered in `Program.cs` and injected into pages:
- `PatternSelectorState` — selected patterns, rank
- `ScoreToolState` — pattern scoring rounds/scores for two competitors
- `SparringScoreToolState` — sparring scores with undo stack

### Pages
| Route | File | Purpose |
|---|---|---|
| `/`, `/PatternPicker` | `Pages/PatternPicker.razor` | Random pattern selector; supports rank, multi-round, World Championship mode |
| `/ScoringTool` | `Pages/ScoringTool.razor` | Deduction-based pattern scoring for two competitors (Hong/Chong) |
| `/SparringScoringTool` | `Pages/SparringScoringTool.razor` | Point + warning sparring scoring, mobile/landscape optimized |

### UI Patterns
- Radzen components are used throughout (`RadzenButton`, `RadzenStack`, `RadzenSelectBar`, etc.)
- Responsive layout: `RadzenSelectBar` for larger screens, `RadzenDropDown` for mobile
- Haptic feedback via JavaScript interop (`navigator.vibrate()`)
- Each page has a paired `.razor.css` for scoped styles
