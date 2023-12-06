using ExtraGraphicsSettings.Utilities;

namespace ExtraGraphicsSettings
{
    [HarmonyPatch(typeof(GodrayManager), nameof(GodrayManager.Update))]
    public class GodrayManager_Update
    {
        public static void Postfix(GodrayManager __instance)
        {
            if (!__instance.m_Initialized) return;

            Settings.DefaultGodraysColour = GameManager.GetUniStorm().GetActiveTODState().m_GodrayColor;

            if (SceneUtilities.IsSceneMenu())
            {
                __instance.StopRays();
            }
            else if (Settings.Instance.Godrays != GodraysPresets.Off && (GameManager.GetUniStorm().IsNight() && !Settings.Instance.GodraysNight ) )
            {
                __instance.StartRays();
            }
            else
            {
                __instance.StopRays();
            }
        }
    }
    [HarmonyPatch(typeof(GodrayManager), nameof(GodrayManager.GodRayObject.Update))]
    public class GodrayManager_GodRayObject_Update
    {
        public static void Postfix(GodrayManager __instance)
        {
            if (Settings.Instance.Godrays != GodraysPresets.Off)
            {
                __instance.m_PropBlock.SetColor(__instance.m_TintID, GodraysUpdater.GetGodraysColor());
            }
        }
    }
}
