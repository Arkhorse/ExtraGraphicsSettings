namespace ExtraGraphicsSettings
{
    [HarmonyPatch(typeof(GodrayManager), nameof(GodrayManager.Update))]
    public class GodrayManager_Update
    {
        public static void Postfix(GodrayManager __instance)
        {
            bool FirstStart = true;
            if (!FirstStart || !__instance.m_Initialized) return;

            Settings.DefaultGodraysColour = GameManager.GetUniStorm().GetActiveTODState().m_GodrayColor;

            FirstStart = false;
        }
    }
}
