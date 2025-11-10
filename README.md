# ta.RainWorldMods

## Build

Prerequsites:

- .NET SDK version 9.0 or newer installed
- RainWorld installed
- Knowledge of modern C# (version 11+)
- Knowledge of nullable reference types
- Knowledge of RainWorld modding

Steps:

1. Go to the RainWorld installation folder
2. Copy following `.dll` files from RainWorld folder to `dll/` folder in repository:
    - From `Rain World/BepInEx/core/`: `0Harmony.dll`, `BepInEx.dll`, `Mono.Cecil.dll`, `MonoMod.Utils.dll`
    - From `Rain World/BepInEx/plugins/`: `HOOKS-Assembly-CSharp.dll`
    - From `Rain World/BepInEx/utils/`: `PUBLIC-Assembly-CSharp.dll`
    - From `Rain World/RainWorld_Data/Managed/`: `Assembly-CSharp-firstpass.dll`, `GoKit.dll`, `Rewired_Core.dll`, `UnityEngine.dll`, `UnityEngine.CoreModule.dll`, `UnityEngine.InputLegacyModule.dll`, `UnityEngine.InputLegacyModule.dll`
3. Run `dotnet build`

## Packaging mod (producing mod zip file)

Requires that you have copied all `.dll` files from RainWorld installation folder to `dll/` folder in repository. See [build](#build) section for details.

Prerequsites:

- "Git Bash" or any other terminal with Linux commands installed (f.e. WSL)
- "Make" installed and available from Git Bash

Steps:

1. Run Git Bash or any other terminal with Linux commands
2. Run `make publish-first-mod`
3. Mod is at `/dist/ta.FirstMod`
