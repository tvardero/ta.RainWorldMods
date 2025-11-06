# ta.RainWorldMods

## Build

Prerequsites:
- .NET SDK version 9.0 or newer
- RainWorld installed
- Knowledge of modern C# (version 11+)
- Knowledge of nullable reference types
- Knowledge of RainWorld modding

Steps:
1. Go to the RainWorld installation folder
2. Copy following `.dll` files from RainWorld folder to `dll/` folder in repository:
   - `Rain World/BepInEx/core/BepInEx.dll`
   - `Rain World/BepInEx/utils/PUBLIC-Assembly-CSharp.dll`
   - `Rain World/BepInEx/plugins/HOOKS-Assembly-CSharp.dll`
   - `Rain World/RainWorld_Data/Managed/UnityEngine.dll`
   - `Rain World/RainWorld_Data/Managed/UnityEngine.CoreModule.dll`
3. Run `dotnet build`