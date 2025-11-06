using System;
using System.Security;
using System.Security.Permissions;
using BepInEx;
using JetBrains.Annotations;
using UnityEngine;

#pragma warning disable CS0618

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace ta.FirstMod;

[BepInPlugin("ta.FirstMod", "ta.FirstMod", "1.0.0")]
public class FirstMod : BaseUnityPlugin
{
    private bool _initialized;

    [UsedImplicitly]
    private void OnEnable()
    {
        On.RainWorld.OnModsInit += RainWorldOnOnModsInit;
    }

    private void PlayerOnUpdate(On.Player.orig_Update orig, Player self, bool eu)
    {
        orig(self, eu); //Always call original code, either before or after your code, depending on what you need to achieve

        self.slugcatStats.runspeedFac += 0.01f;
        Debug.Log($"Player {self.playerState.playerNumber} feels like zooming.");
        Debug.Log($"Player {self.playerState.playerNumber}'s run speed: {self.slugcatStats.runspeedFac}");
    }

    private void RainWorldOnOnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);
        if (_initialized) return;

        try
        {
            _initialized = true;

            //Your hooks go here
            On.Player.Update += PlayerOnUpdate;
        }
        catch (Exception ex) { Logger.LogError(ex); }
    }
}
