namespace ExtraGraphicsSettings
{
    [HarmonyPatch(typeof(PlayerInVehicle), nameof(PlayerInVehicle.EnterVehicle))]
    internal class PlayerInVehicle_EnterVehicle
    {
        private static void Postfix(PlayerInVehicle __instance)
        {
            if (Settings.Instance.EnableFreeLook)
            {
                __instance.m_YawLimitDegrees = new Vector2(-Settings.Instance.FreeLook_MaxYaw, Settings.Instance.FreeLook_MaxYaw);
                __instance.m_PitchLimitDegrees = new Vector2(-Settings.Instance.FreeLook_MaxPitch, Settings.Instance.FreeLook_MaxPitch);
            }
        }
    }
}
