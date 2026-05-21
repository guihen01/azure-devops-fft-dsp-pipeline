# Azure DevOps FFT DSP Pipeline

Azure DevOps CI/CD pipeline for a .NET 8 C# DSP/FFT application using a custom FFT NuGet package and automatic PNG spectrum generation.

---

## Technologies

- C#
- .NET 8
- Azure DevOps
- YAML Pipelines
- FFTlib
- ScottPlot

---

## Features

- FFT / DFT signal processing
- DSP (Power Spectral Density) calculation
- Automatic PNG graph generation
- Azure DevOps CI/CD pipeline
- Artifact publishing

---

## Generated PNG Files

- `fft-sinus.png`
- `fft-gaussian.png`

---

## Pipeline Workflow

```text
GitHub
   ↓
Azure DevOps Pipeline
   ↓
dotnet restore
   ↓
dotnet build
   ↓
Run FFT DSP application
   ↓
Generate PNG FFT graphs
   ↓
Publish Artifacts
```

---

## Run Locally

```bash
dotnet restore
dotnet run --project src/ConsoleTest
```

---

## NuGet Package

FFTlib:

https://www.nuget.org/packages/FFTlib/

---

## Future Improvements

- Azure Blob Storage integration
- Azure Static Website hosting
- Docker support
