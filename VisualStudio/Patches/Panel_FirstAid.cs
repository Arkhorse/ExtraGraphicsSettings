namespace ExtraGraphicsSettings
{
    [HarmonyPatch(typeof(Panel_FirstAid), nameof(Panel_FirstAid.Enable))]
    public static class Panel_FirstAid_Enable
    {
        private static bool initialized { get; set; } = false;

        public static void Prefix(Panel_FirstAid __instance)
        {
            if (!Settings.Instance.EnableStatusBarPercents) return;
            else
            {
                if (initialized) return;
                else
                {
                    initialized = true;

                    StatusBarUtils.CenterStutusLabel(__instance.m_ColdStatusLabel);
                    StatusBarUtils.CenterStutusLabel(__instance.m_FatigueStatusLabel);
                    StatusBarUtils.CenterStutusLabel(__instance.m_ThirstStatusLabel);
                    StatusBarUtils.CenterStutusLabel(__instance.m_HungerStatusLabel);

                    StatusBarUtils.ActivateAndMovePercentLabel(__instance.m_ColdPercentLabel);
                    StatusBarUtils.ActivateAndMovePercentLabel(__instance.m_FatiguePercentLabel);
                    StatusBarUtils.ActivateAndMovePercentLabel(__instance.m_ThirstPercentLabel);
                    StatusBarUtils.ActivateAndMovePercentLabel(__instance.m_HungerPercentLabel);

                    StatusBarUtils.ActivateAndMoveConditionLabel(__instance.m_LabelConditionPercent);
                }
            }
        }
    }

    [HarmonyPatch(typeof(WellFed), nameof(WellFed.Update))]
    public static class WellFed_Update
    {
        private static Vector3 WellFedOffset { get; } = new Vector3(22, 0);
        private static bool WellFedActive { get; set; } = false;
        private static Transform LabelTransform { get; set; } = InterfaceManager.GetPanel<Panel_FirstAid>().m_LabelConditionPercent.transform;

        public static void Postfix(WellFed __instance)
        {
            if (!Settings.Instance.EnableStatusBarPercents) return;
            else
            {
                bool NewActive = __instance.HasWellFed() && __instance.m_MaxConditionBonusPercent > 0f;

                if (NewActive == WellFedActive) return;
                else
                {
                    float MoveDirection = NewActive ? +1 : -1;
                    LabelTransform.localPosition += MoveDirection * WellFedOffset;

                    WellFedActive = NewActive;
                }
            }
        }
    }
}
