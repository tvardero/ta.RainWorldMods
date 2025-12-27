using Menu;
using MoreSlugcats;
using RWCustom;

namespace tvardero.DearDevTools.Services;

public class GameStateService : IDisposable
{
    public GameStateService()
    {
        On.ProcessManager.PostSwitchMainProcess += PostSwitchProcess;
        RefreshValuesFromGame();
    }

    public bool IsInGame { get; private set; }

    public bool IsInSleepOrDeathMenu { get; private set; }

    public bool IsInMainMenu { get; private set; }

    public MainLoopProcess? CurrentProcess { get; private set; }

    /// <inheritdoc />
    public void Dispose()
    {
        On.ProcessManager.PostSwitchMainProcess -= PostSwitchProcess;
        GC.SuppressFinalize(this);
    }

    public void RefreshValuesFromGame()
    {
        RainWorld? rw = Custom.rainWorld;
        CurrentProcess = rw.processManager.currentMainLoop;

        IsInGame = CurrentProcess is RainWorldGame;
        IsInSleepOrDeathMenu = CurrentProcess is SleepAndDeathScreen or GhostEncounterScreen;
        IsInMainMenu = CurrentProcess is MainMenu or SlugcatSelectMenu or Menu.RegionSelectMenu or MultiplayerMenu or FastTravelScreen
                                      or InputOptionsMenu or ModdingMenu or OptionsMenu or BackgroundOptionsMenu or ExpeditionMenu or CollectionsMenu;
    }

    private void PostSwitchProcess(On.ProcessManager.orig_PostSwitchMainProcess orig, ProcessManager self, ProcessManager.ProcessID id)
    {
        orig(self, id);
        RefreshValuesFromGame();
    }
}