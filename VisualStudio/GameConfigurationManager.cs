using GameConfigurationManager.Utilities;
using GameConfigurationManager.Utilities.Exceptions;

namespace GameConfigurationManager
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        //public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        //{
        //    base.OnSceneWasInitialized(buildIndex, sceneName);

        //    if (SceneUtilities.IsSceneEmpty(sceneName) || SceneUtilities.IsSceneBoot(sceneName)) return;

        //    try
        //    {
        //        if (GameManager.GetUniStorm() == null) return;
        //    }
        //    catch { }

        //    try
        //    {
        //        if (SceneUtilities.IsScenePlayable(sceneName))
        //        {
        //            //TODO: Convert this to json data
        //            if (Settings.DefaultGodraysColour == new Color(0, 0, 0)) Settings.DefaultGodraysColour = GameManager.GetUniStorm().GetActiveTODState().m_GodrayColor;
        //            Settings.Instance.OnConfirmLoad();
        //        }
        //    }
        //    catch { }
        //}

        //public override void OnLateUpdate()
        //{
        //    if (!SceneUtilities.IsSceneBase()) return;

        //    try
        //    {
        //        if (GameManager.GetUniStorm() == null) return;
        //    }
        //    catch { }

        //    try
        //    {
        //        if (GameManager.GetUniStorm() != null)
        //        {

        //        }
        //    }
        //    catch //(Exception e)
        //    {
        //        //throw new BadMemeException($"Unistorm is not available. This is OK on game start. Reason {e.Message}");
        //    }
        //}
    }
}
