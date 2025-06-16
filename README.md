# Paperfold Studio

Paperfold Studio is an idle-clicker game. This repository contains the original Unity project and a lightweight browser port located in the `Web/` folder.

## Playing in the Browser

Open `Web/index.html` in any modern browser. The web version implements folding, assistants, origami set progression, skills, prestige and saving/loading using `localStorage`.

## Unity Project Requirements

- Unity 2022.3 or newer
- Steamworks SDK (optional for achievements and cloud)
- itch.io Butler CLI (for uploads)

## Project Structure

- `Assets/` – game code and assets
- `Assets/Scenes/Main.unity` – sample scene
- `ProjectSettings/` – Unity project settings
- `Web/` – standalone browser implementation

## Building the Unity Game

1. Open the project with Unity.
2. Open `Assets/Scenes/Main.unity` and press Play to test.
3. Configure the Steam AppID in `SteamIntegration.cs` if you plan to use Steam features.
4. Build for Windows, macOS or WebGL via **File → Build Settings**.
5. Use the included scripts or Butler CLI to upload to itch.io or Steam.

### Steam Setup

- Install the Steamworks SDK and copy the `Plugins` folder into `Assets/Plugins`.
- Set up achievements and cloud saves in the Steam dashboard.

### itch.io Uploads

- Install Butler from <https://itch.io/docs/butler/install>.
- Use `ItchIOUploader.cs` or the command line: `butler push Build/ youruser/paperfoldstudio:windows`.

## Adding Content

- **Origami Sets:** Edit `ProgressionSystem.cs` or modify `Web/game.js` to add new sets.
- **Skills:** Adjust `SkillTree.cs` or the browser code to define new upgrades.
- **Gallery Assets:** Place art in `Assets/Addressables` and mark them as addressable via Unity's Addressables system.

## Project Version

This project was initialized for Unity 2022.3.0f1. Adjust `ProjectSettings/ProjectVersion.txt` if you open with a different version.
