namespace ExtraGraphicsSettings
{
    public class TODStateUtils
    {
        /// <summary>
        /// Changes TODStateData based on the setting name
        /// </summary>
        /// <param name="data">TODStateData referenced in the calling function</param>
        /// <param name="setting">The setting name</param>
        public static void ChangeTODStateData(TODStateData data, string setting)
        {
            switch (setting)
            {
                case ("vignette"):
                    data.m_VignettingIntensity = 0;
                    break;
                case ("chromatic"):
                    data.m_VignettingChromaticAberration = 0;
                    break;
                case ("godray"):
                    data.m_GodrayColor = new Color(0f, 0f, 0f);
                    break;
            }
        }

        /// <summary>
        /// Used to update the Godrays color.
        /// </summary>
        /// <param name="data">TODStateData used to update this. Should always come from UniStormWeatherSystem</param>
        /// <param name="color">The RGB color to change the Godrays to</param>
        public static void ChangeTODGodrays(TODStateData data, Color color)
        {
            data.m_GodrayColor = color;
        }
    }
}
