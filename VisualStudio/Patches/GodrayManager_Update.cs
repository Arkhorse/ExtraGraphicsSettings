namespace ExtraGraphicsSettings
{
    [HarmonyPatch(typeof(GodrayManager), nameof(GodrayManager.Update))]
    public class GodrayManager_Update
    {
        public static void Postfix(GodrayManager __instance)
        {
            if (!__instance.m_Initialized) return;

            Settings.DefaultGodraysColour = GameManager.GetUniStorm().GetActiveTODState().m_GodrayColor;

            if (Settings.Instance.Godrays != GodraysPresets.Off)
            {
                __instance.StartRays();
            }
            else
            {
                __instance.StopRays();
            }
        }
    }
}
