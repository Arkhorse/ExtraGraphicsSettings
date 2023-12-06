using GameConfigurationManager.Utilities.Enums;

namespace GameConfigurationManager
{
    public class Settings : JsonModSettings
    {
        /// <summary>
        /// This is the thing you must call to get the current settings
        /// </summary>
        internal static Settings Instance { get; } = new();
        /// <summary>
        /// Simple storage for the godrays colour
        /// </summary>
        internal Color GodraysColor { get; set; }

        internal static Color DefaultGodraysColour { get; set; }

        #region General
        [Section("General")]

        [Name("Enable Vignette")]
        [Description("Disable this if you DONT want Vignette")]
        public bool Vignette = true;
        [Name("Enable Chromatic Abberration")]
        [Description("Disable this if you DONT want Chromatic Abberration")]
        public bool Chromatic = true;
        [Name("Enable Debug")]
        [Description("If enabled, mod will dump alot of info to the MelonLoader log")]
        public bool DebugEnabled = false;

        #endregion
        #region Status Bar Percent

        [Section("Status Bar Percents")]

        [Name("Enable Status Bar Percents")]
        [Description("Adds a percent under the circle")]
        public bool EnableStatusBarPercents = false;
        [Name("Percent Label Font Size")]
        [Description("Sets the size of the text")]
        [Slider(10, 30)]
        public int PercentLabelFontSize = 14;

        #endregion
        #region Free Look In Cars

        [Section("Free Look In Cars")]

        [Name("Enable")]
        [Description("Free look allows you to look all around you")]
        public bool EnableFreeLook = false;
        [Name("Max/Min Yaw")]
        [Description("180 is not possible as it locks your camera")]
        [Slider(90, 175)]
        public int FreeLook_MaxYaw      = 175;
        [Name("Max/Min Pitch")]
        [Slider(0, 90)]
        public int FreeLook_MaxPitch    = 90;

        #endregion
        #region Weapon Crosshair

        [Section("Weapon Crosshair")]

        [Name("Enable Weapon Crosshair Options")]
        public bool EnableCrosshairModification = false;

        [Name("Crosshair Alpha")]
        [Description("Decrease to make the crosshair less visible. Increase to make it more visible")]
        [Slider(0f, 1f, numberOfSteps:20)]
        public float CrosshairModificationAlpha = 1f;

        [Name("Stone Crosshair")]
        public bool CrosshairModificationStone = false;
        [Name("Rifle Crosshair")]
        public bool CrosshairModificationRifle = false;
        [Name("Bow Crosshair")]
        public bool CrosshairModificationBow = false;
        #endregion
        #region Godrays

        [Section("Godrays")]

        [Name("Godrays")]
        [Description("Select Off if you dont want Godrays")]
        public GodraysPresets Godrays = GodraysPresets.On;

        [Name("Allow at night")]
        public bool GodraysNight = false;

        [Name("Use Aurora Color")]
        public bool GodraysNightAurora = false;

        #endregion
        #region Godrays Presets

        [Name("Presets")]
        public GodraysColours GodraysColorPreset = GodraysColours.magenta;

        #endregion
        #region Godrays RGBa Selector

        [Name("Red")]
        [Slider(0f, 1f)]
        public float GodraysColorRed = 1;
        [Name("Blue")]
        [Slider(0f, 1f)]
        public float GodraysColorBlue = 1;
        [Name("Green")]
        [Slider(0f, 1f)]
        public float GodraysColorGreen = 1;
        [Name("Alpha")]
        [Slider(0f, 1f)]
        public float GodraysColorAlpha = 1;

        #endregion

        public void HandleGodraysSettings()
        {
            SetFieldVisible(nameof(GodraysNightAurora), Instance.GodraysNight);

            SetFieldVisible(nameof(GodraysColorPreset), Instance.Godrays == GodraysPresets.Presets);

            SetFieldVisible(nameof(GodraysColorRed),    Instance.Godrays == GodraysPresets.Custom);
            SetFieldVisible(nameof(GodraysColorBlue),   Instance.Godrays == GodraysPresets.Custom);
            SetFieldVisible(nameof(GodraysColorGreen),  Instance.Godrays == GodraysPresets.Custom);
            SetFieldVisible(nameof(GodraysColorAlpha),  Instance.Godrays == GodraysPresets.Custom);
        }

        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
        {
            HandleGodraysSettings();
            base.OnChange(field, oldValue, newValue);
        }

        protected override void OnConfirm()
        {
            OnConfirmLoad();
            base.OnConfirm();
        }

        public void OnConfirmLoad()
        {
            if (GameManager.GetUniStorm() == null) return;

            Instance.GodraysColor = Instance.Godrays switch
            {
                GodraysPresets.On       => DefaultGodraysColour,
                GodraysPresets.Off      => Color.clear,
                GodraysPresets.Presets  => ColourConverter.GetGodraysColourFromSettings(Instance.GodraysColorPreset),
                GodraysPresets.Custom   => ColourConverter.GetGodraysColourFromSettings(),
                _                       => DefaultGodraysColour
            };

            GodraysUpdater.UpdateGodraysColor();
        }



        internal static void OnLoad()
        {
            Instance.AddToModSettings(BuildInfo.GUIName);
            Instance.HandleGodraysSettings();
        }
    }
}