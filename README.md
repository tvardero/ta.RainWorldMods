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

Steps:
1. Run `dotnet ./src/ta.FirstMod/ publish --output dist/ta.FirstMod/src` for ta.FirstMod. Other mods are similar.
2. Create `dist/ta.FirstMod` folder
3. From `dist/ta.FirstMod/src` folder copy following files to `dist/ta.FirstMod`:
   - `modinfo.json` -> `modinfo.json`
   - `thumbnail.png` -> `thumbnail.png`
   - `workshopdata.json` -> `workshopdata.json` (only required for Steam workshop publishing)
   - `ta.FirstMod.dll` -> `plugin/ta.FirstMod.dll`
   - `ta.FirstMod.pdb` -> `plugin/ta.FirstMod.pdb`
4. Zip `dist/ta.FirstMod` folder - this is your mod zip file.
