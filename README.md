# XR Developer - Practical Task

A Unity-based virtual reality application focused on guided injection interactions within immersive environments. This project demonstrates how to implement realistic medical simulation scenarios using OpenXR input systems, featuring injection targets, training managers, and character controllers designed for VR experiences.

## Project Overview

This project provides a practical framework for building VR-injection interaction systems using Unity and the OpenXR API. It combines modular script components for managing injection targets, training workflows, and character behavior to create interactive guided tasks suitable for medical or training simulations. The codebase leverages Unity's Input System and OpenXR standards to ensure cross-platform compatibility across VR headsets.

## Features

- **Injection Target Management** - Interactive injection points with visual feedback and state tracking
- **Training Manager** - Orchestrates guided training sessions with progress tracking
- **Character Controller** - Customizable avatar movement and interaction logic
- **OpenXR Integration** - Cross-platform VR input handling via the Unity Input System
- **Modular Architecture** - Separate scripts for targets, training flow, and character behavior
- **Visual Feedback** - Real-time indicators for injection status and task progression

## Tech Stack

| Component | Technology |
|-----------|------------|
| Engine | Unity (C#) |
| Input System | Unity Input System Package |
| VR Framework | OpenXR |
| Scripting | C# (.NET Standard) |
| Asset Handling | Unity Asset Bundles & Textures |

## Installation

Set up the development environment with the required dependencies:

1. **Clone the repository**
   ```bash
   git clone https://github.com/rohit892004/XR-Developer---Practical-Task---Guided_VR_injection_interaction.git
   cd XR-Developer---Practical-Task---Guided_VR_injection_interaction
   ```

2. **Install Unity Hub and Editor**
   Ensure you have the latest LTS version of Unity installed with the **OpenXR Plugin** enabled.

3. **Add required packages**
   The project references these packages in its `.vscode/launch.json` and `.vscode/settings.json`:
   - Unity Input System (`com.unity.inputsystem`)
   - OpenXR SDK (bundled with Unity)

4. **Launch the editor**
   Open the project in Unity Editor and navigate to the `Assets` folder where the main scripts reside.

## Usage

### Running the Application

After installation, open the project in Unity Editor. The main interface will display the OpenXR tutorial and sample controller demonstration under `Assets/Samples/OpenXR Plugin/1.16.1/Controller/`.

### Core Components

- **Injection Targets** – Placeable objects that define injection points within the scene. Each target tracks its state (available, in-use, completed) and provides visual feedback through Unity's UIElements.
- **Training Manager** – Coordinates multi-step injection procedures, manages player progress, and triggers completion events.
- **Character Controller** – Handles movement, interaction, and animation for the simulated subject during training sessions.

### Example Workflow

```csharp
// Initialize the training session
var trainer = new InjectionTrainingManager();
trainer.Initialize(sceneReference);

// Place an injection target in the scene
InjectionTarget target = Instantiate(InjectionTargetPrefab, targetPosition);
target.SetActive(true);

// Start the guided training sequence
trainer.StartSession(target, "MedicalInjectionTask");
```

## Configuration

The project uses several configuration approaches:

- **Scene References** – Pass a reference object to the `InjectionTrainingManager` to anchor targets and track progress.
- **Unity Input Settings** – Configure OpenXR device profiles in *Edit → Project Settings → XR Plug-in Management*.
- **Character Controller Parameters** – Adjust movement speed, gravity, and animation curves in the `FixedXRCharacterController.cs` script.

No environment variables or command-line arguments are required for standard operation. All settings are managed through the code's internal state and Unity's inspector.

## Project Structure

```
XR-Developer---Practical-Task---Guided_VR_injection_interaction/
├── Assets/
│   ├── TutorialInfo/
│   │   └── Readme.cs          # ScriptableObject defining UI sections
│   ├── Scripts/
│   │   ├── AnimateHandOnInput.cs      # Hand gesture animation handler
│   │   ├── FixedXRCharacterController.cs  # Character movement controller
│   │   ├── InjectionTarget.cs         # Injection point definition
│   │   ├── InjectionTrainingManager.cs # Training workflow orchestrator
│   │   ├── PanelActive.cs            # UI panel management
│   │   ├── SyringeMedicine.cs        # Syringe/tool inventory
│   │   ├── SyringeNeedle.cs          # Needle attachment logic
│   │   └── SyringeTrigger.cs         # Trigger mechanism for injections
│   ├── Samples/
│   │   └── OpenXR Plugin/
│   │       └── 1.16.1/Controller/     # Sample controller demo
│   └── TextMeshPro/
│       └── Examples & Extras/
│           └── Benchmark01_UGUI.cs   # Performance benchmarking
├── .vscode/
│   ├── extensions.json             # Development extensions
│   ├── launch.json                 # Launch configurations
│   └── settings.json               # Editor settings
└── .gitattributes                  # File filtering rules
```

## Contributing

Contributions are welcome! Please follow these guidelines:

- **Code Standards** – Maintain consistent C# naming conventions and Unity coding practices. All new scripts should extend existing patterns found in `Assets/Scripts/`.
- **Documentation** – Update the `Readme.cs` ScriptableObject sections when adding new UI elements or functionality.
- **Testing** – Add unit tests for critical paths (injection logic, training flow) using Unity's Test Framework.
- **Issue Reporting** – Report bugs or request features via the Unity Forum or open PRs against the `main` branch.

For questions or collaboration opportunities, review the existing `Assets/TutorialInfo/Readme.asset` for current feature listings and align new contributions accordingly.

---

*This project is licensed under the MIT License (see LICENSE file for details).*
