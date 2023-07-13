namespace ExtraGraphicsSettings
{
    public class ExtraGraphicsSettings : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
#if DEBUG
            Logger.Log($"Mod has loaded with version: {BuildInfo.Version}");
#endif
        }
    }
}
