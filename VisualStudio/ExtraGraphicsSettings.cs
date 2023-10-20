using ExtraGraphicsSettings.Utilities;

namespace ExtraGraphicsSettings
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            base.OnSceneWasInitialized(buildIndex, sceneName);

            if (SceneUtilities.IsScenePlayable(sceneName))
            {
                if (GameManager.GetUniStorm())
                {
                    //TODO: Convert this to json data
                    Settings.DefaultGodraysColour = GameManager.GetUniStorm().GetActiveTODState().m_GodrayColor;
                    Settings.OnConfirmLoad();
                }
            }
        }
    }
}
