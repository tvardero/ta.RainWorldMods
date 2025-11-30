namespace tvardero.DearDevTools.Services;

public class GameStateService
{
    public bool IsInGame => false;

    public bool IsInArenaGame => false;

    public bool IsInExpeditionGame => false;

    public bool IsInCampaignGame => false;

    public bool IsInPauseMenu => false;

    public bool IsInMainMenu => true;

    public bool IsInRwSettings => false;
}