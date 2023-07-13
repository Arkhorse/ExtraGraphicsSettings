namespace ExtraGraphicsSettings
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName.Contains("SANDBOX"))
            {
                if (!GameManager.GetUniStorm())
                {
                    Logger.LogWarning("Game is not loaded yet or user has yet to load a save", Color.yellow);
                    return;
                }
                Settings.DefaultGodraysColour = GameManager.GetUniStorm().GetActiveTODState().m_GodrayColor;
            }
            base.OnSceneWasLoaded(buildIndex, sceneName);
        }
    }
}
