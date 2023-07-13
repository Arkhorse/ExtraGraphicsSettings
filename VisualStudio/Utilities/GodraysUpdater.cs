namespace ExtraGraphicsSettings
{
    internal class GodraysUpdater
    {
        /// <summary>
        /// Used to update the Godrays color
        /// </summary>
        public static void UpdateGodraysColor()
        {
            UniStormWeatherSystem unistorm = GameManager.GetUniStorm();

            if (Settings.Instance.Godrays == GodraysPresets.On)
            {
                Settings.GodraysColor = Color.magenta;
            }
            else if (Settings.Instance.Godrays == GodraysPresets.Off)
            {
                Settings.GodraysColor = new Color(0f, 0f, 0f);
            }
            else if (Settings.Instance.Godrays == GodraysPresets.Custom)
            {
                Settings.GodraysColor = new Color(Settings.Instance.GodraysColorRed, Settings.Instance.GodraysColorGreen, Settings.Instance.GodraysColorBlue);
            }

            foreach (WeatherStatesData eachWeatherStateConfig in unistorm.m_WeatherStateConfigs)
            {
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_DawnColors,         color: Settings.GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_MorningColors,      color: Settings.GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_MiddayColors,       color: Settings.GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_AfternoonColors,    color: Settings.GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_DuskColors,         color: Settings.GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_NightColors,        color: Settings.GodraysColor);
            }
        }
    }
}
