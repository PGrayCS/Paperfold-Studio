<<<<<<< master
# Paperfold Studio

Paperfold Studio is an idle-clicker game built with Unity. This repository contains the project structure and C# scripts to get started.

## Requirements
- Unity 2022.3 or newer
- Steamworks SDK (for achievements and cloud)
- itch.io Butler CLI (for uploads)

## Project Structure
- `Assets/` – game code and assets
- `Assets/Scenes/Main.unity` – sample scene wiring the scripts together
- `ProjectSettings/` – minimal Unity project settings

## Building the Game
1. Open the project with Unity.
2. Open `Assets/Scenes/Main.unity` and press Play to test the game.
3. Configure the Steam AppID in `SteamIntegration.cs` and place your `steam_appid.txt` in the root folder if you plan to use Steam features.
4. Build for Windows or macOS via `File -> Build Settings`.
5. Use the included scripts or Butler CLI to upload to itch.io or Steam.

### Steam Setup
- Install the Steamworks SDK and copy the `Plugins` folder into `Assets/Plugins`.
- Set up achievements and cloud saves in the Steam dashboard.

### itch.io Uploads
- Install Butler from <https://itch.io/docs/butler/install>.
- Use `ItchIOUploader.cs` or the command line: `butler push Build/ youruser/paperfoldstudio:windows`.

## Adding Content
- **Origami Sets:** Edit `ProgressionSystem.cs` and add new entries to the `origamiSets` list.
- **Skills:** Modify `SkillTree` inside `ProgressionSystem.cs` to define new skills and upgrades.
- **Gallery Assets:** Place art in `Assets/Addressables` and mark them as Addressable via Unity's Addressables system.

## Project Version
This project was initialized for Unity 2022.3.0f1. Adjust `ProjectSettings/ProjectVersion.txt` if you open with a different version.
=======
"Paperfold-Studio" 
>>>>>>> main
