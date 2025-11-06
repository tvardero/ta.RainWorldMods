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
   - `Rain World/BepInEx/core/BepInEx.dll` - BepInEx mod loader
   - `Rain World/BepInEx/utils/PUBLIC-Assembly-CSharp.dll` - RainWorld API
   - `Rain World/BepInEx/plugins/HOOKS-Assembly-CSharp.dll` - RainWorld modding hooks
   - `Rain World/RainWorld_Data/Managed/UnityEngine.dll` - UnityEngine
   - `Rain World/RainWorld_Data/Managed/UnityEngine.CoreModule.dll` - UnityEngine
3. Run `dotnet build`