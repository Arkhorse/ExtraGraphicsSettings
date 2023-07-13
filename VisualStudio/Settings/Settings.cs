namespace ExtraGraphicsSettings
{
    public class Settings : JsonModSettings
    {
        /// <summary>
        /// Allows first load settings code
        /// </summary>
        private static bool IsFirstLoad { get; set; } = true;
        /// <summary>
        /// This is the thing you must call to get the current settings
        /// </summary>
        internal static Settings Instance { get; } = new();
        /// <summary>
        /// Simple storage for the godrays colour
        /// </summary>
        internal static Color GodraysColor { get; set; } = Color.magenta;

        internal static Color DefaultGodraysColour { get; set; } = new(0, 0, 0, 0);

        #region General
        [Section("General")]

        [Name("Enable Vignette")]
        [Description("Disable this if you DONT want Vignette")]
        public bool Vignette = true;

        [Name("Enable Chromatic Abberration")]
        [Description("Disable this if you DONT want Chromatic Abberration")]
        public bool Chromatic = true;
        #endregion
        #region Godrays
        [Section("Godrays")]

        [Name("Enable Godrays")]
        [Description("Select Off if you dont want Godrays")]
        public GodraysPresets Godrays = GodraysPresets.On;
        #endregion
        #region Godrays Presets
        [Name("Presets")]
        [Choice(new string[] { "red", "green", "blue", "yellow", "cyan", "magenta" })]
        public GodraysColours GodraysColorPreset = GodraysColours.magenta;
        #endregion
        #region Godrays RGBa Selector
        [Name("Red")]
        [Slider(0, 255)]
        public int GodraysColorRed      = 0;
        [Name("Blue")]
        [Slider(0, 255)]
        public int GodraysColorBlue     = 0;
        [Name("Green")]
        [Slider(0, 255)]
        public int GodraysColorGreen    = 0;
        [Name("Alpha")]
        [Slider(0, 255)]
        public int GodraysColorAlpha    = 255;
        #endregion
        #region Status Bar Percent
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

        // Always at the end
        [Name("Enable Debug")]
        [Description("If enabled, mod will dump alot of info to the MelonLoader log")]
        public bool DebugEnabled = false;

        private void FirstLoad()
        {
            Logger.Log($"First Load");

            SetFieldVisible(nameof(GodraysColorPreset), false);
            SetFieldVisible(nameof(GodraysColorRed), false);
            SetFieldVisible(nameof(GodraysColorBlue), false);
            SetFieldVisible(nameof(GodraysColorGreen), false);

            SetFieldVisible(nameof(PercentLabelFontSize), false);
            SetFieldVisible(nameof(FreeLook_MaxYaw), false);
            SetFieldVisible(nameof(FreeLook_MaxPitch), false);

            SetFieldVisible(nameof(CrosshairModificationAlpha), false);
            SetFieldVisible(nameof(CrosshairModificationStone), false);
            SetFieldVisible(nameof(CrosshairModificationRifle), false);
            SetFieldVisible(nameof(CrosshairModificationBow), false);

            IsFirstLoad = false;
        }

        private void Refresh()
        {
            SetFieldVisible(nameof(GodraysColorPreset),             Instance.Godrays == GodraysPresets.Presets);
            SetFieldVisible(nameof(GodraysColorRed),                Instance.Godrays == GodraysPresets.Custom);
            SetFieldVisible(nameof(GodraysColorBlue),               Instance.Godrays == GodraysPresets.Custom);
            SetFieldVisible(nameof(GodraysColorGreen),              Instance.Godrays == GodraysPresets.Custom);

            SetFieldVisible(nameof(PercentLabelFontSize),           Instance.EnableStatusBarPercents);
            SetFieldVisible(nameof(EnableFreeLook),                 Instance.EnableFreeLook);
            SetFieldVisible(nameof(FreeLook_MaxYaw),                Instance.EnableFreeLook);
            SetFieldVisible(nameof(FreeLook_MaxPitch),              Instance.EnableFreeLook);

            SetFieldVisible(nameof(CrosshairModificationAlpha),     Instance.EnableCrosshairModification);
            SetFieldVisible(nameof(CrosshairModificationStone),     Instance.EnableCrosshairModification);
            SetFieldVisible(nameof(CrosshairModificationRifle),     Instance.EnableCrosshairModification);
            SetFieldVisible(nameof(CrosshairModificationBow),       Instance.EnableCrosshairModification);
        }
        
        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
        {
            // Only use enables here since thats the only time visibility should change
            if ( field.Name == nameof(Instance.Godrays)
                || field.Name == nameof(Instance.EnableStatusBarPercents) 
                || field.Name == nameof(Instance.EnableCrosshairModification))
            {
                Instance.Refresh();
            }
            base.OnChange(field, oldValue, newValue);
        }

        protected override void OnConfirm()
        {
            if ( DefaultGodraysColour != new Color(0,0,0,0) )
            {
                GodraysColor = Instance.Godrays switch
                {
                    GodraysPresets.On => DefaultGodraysColour,
                    GodraysPresets.Off => Color.clear,
                    GodraysPresets.Presets => ColourConverter.GetGodraysColourFromSettings(Instance.GodraysColorPreset),
                    GodraysPresets.Custom => ColourConverter.GetGodraysColourFromSettings(),
                    _ => DefaultGodraysColour
                };
                GodraysUpdater.UpdateGodraysColor();
            }
            
            base.OnConfirm();
        }

        internal static void OnLoad()
        {
            Instance.AddToModSettings(BuildInfo.GUIName);
            if (IsFirstLoad) Instance.FirstLoad();
            else Instance.Refresh();
        }
    }
}