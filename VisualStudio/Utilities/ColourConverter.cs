namespace GameConfigurationManager
{
    /// <summary>
    /// A class containing useful processing functions to convert things to RGBa Color
    /// </summary>
    public class ColourConverter
    {
        /// <summary>
        /// Used to convert the GodraysColours Enum to the Unity Color Enum
        /// </summary>
        /// <param name="setting">GodraysColours Enum setting from the Settings Instance</param>
        /// <returns>Processed Color</returns>
        /// <remarks>This is needed since ModSettings does not support the Color type at this time (2023/07/13)</remarks>
        public static Color GetGodraysColourFromSettings(GodraysColours setting)
        {
            Color color = Color.white;

            color = setting switch
            {
                GodraysColours.blue         => Color.blue,
                GodraysColours.cyan         => Color.cyan,
                GodraysColours.gray         => Color.gray,
                GodraysColours.green        => Color.green,
                GodraysColours.grey         => Color.grey,
                GodraysColours.magenta      => Color.magenta,
                GodraysColours.red          => Color.red,
                GodraysColours.white        => Color.white,
                GodraysColours.yellow       => Color.yellow,
                _ => Settings.DefaultGodraysColour,
            };
            return color;
        }
        /// <summary>
        /// Used to convert 4 float's to a RGBa1 Color
        /// </summary>
        /// <param name="red">Red part of RGBa</param>
        /// <param name="green">Green part of RGBa</param>
        /// <param name="blue">Blue part of RGBa</param>
        /// <param name="alpha">Alpha part of RGBa</param>
        /// <returns>Processed Color</returns>
        public static Color GetGodraysColourFromSettings(float red, float green, float blue, float alpha)
        {
            Vector4 CustomColor = new Vector4(red, green, blue, alpha);
            return CustomColor;
        }
        /// <summary>
        /// Used to convert the Godrays Custom creator to a proper RGBa1 Color
        /// </summary>
        /// <returns>Processed Color</returns>
        public static Color GetGodraysColourFromSettings()
        {
            Vector4 color = GetGodraysColourFromSettings(Settings.Instance.GodraysColorRed, Settings.Instance.GodraysColorGreen, Settings.Instance.GodraysColorBlue, Settings.Instance.GodraysColorAlpha);
            return color;
        }
    }
}
