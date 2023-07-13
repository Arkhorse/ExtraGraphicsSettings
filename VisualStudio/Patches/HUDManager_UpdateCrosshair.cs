namespace ExtraGraphicsSettings
{
    // [CachedScanResults(RefRangeStart = 336992, RefRangeEnd = 336993, XrefRangeStart = 336876, XrefRangeEnd = 336992, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
    [HarmonyPatch(typeof(HUDManager), nameof(HUDManager.UpdateCrosshair), new Type[] { typeof(Panel_HUD) })]
    public class HUDManager_UpdateCrosshair
    {
        public static void Postfix()
        {
            if ( !Settings.Instance.EnableCrosshairModification || (!Settings.Instance.CrosshairModificationStone && !Settings.Instance.CrosshairModificationRifle && !Settings.Instance.CrosshairModificationBow) ) return;
            if (GameManager.GetPlayerManagerComponent().PlayerIsZooming())
            {
                GearItem HeldItem   = GameManager.GetPlayerManagerComponent().m_ItemInHands;
                StoneItem stoneItem = HeldItem.m_StoneItem;
                GunItem gunItem     = HeldItem.m_GunItem;
                BowItem bowItem     = HeldItem.m_BowItem;
                
                // Original mod did this all in one check. This could be problematic in the future as well as making logging harder
                // Spreading this out also permits easy adding should it be needed in the future
                if (stoneItem)
                {
                    if (Settings.Instance.CrosshairModificationStone)
                    {
                        EnableCrosshair();
                    }
                }
                if (gunItem)
                {
                    if (Settings.Instance.CrosshairModificationRifle)
                    {
                        EnableCrosshair();
                    }
                }
                if (bowItem)
                {
                    if (Settings.Instance.CrosshairModificationBow)
                    {
                        EnableCrosshair();
                    }
                }
            }
        }

        private static void EnableCrosshair()
        {
            Il2Cpp.Utils.SetActive(InterfaceManager.GetPanel<Panel_HUD>().m_Sprite_Crosshair.gameObject, true);
            InterfaceManager.GetPanel<Panel_HUD>().m_Sprite_Crosshair.alpha = Settings.Instance.CrosshairModificationAlpha;
        }
    }
}
