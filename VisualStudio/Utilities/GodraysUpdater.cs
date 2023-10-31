namespace ExtraGraphicsSettings
{
    internal class GodraysUpdater
    {
        /// <summary>
        /// Used to update the Godrays color
        /// </summary>
        public static void UpdateGodraysColor()
        {
            if (GameManager.GetUniStorm() == null) return;

            UniStormWeatherSystem unistorm = GameManager.GetUniStorm();
            Color GodraysColor = Settings.Instance.GodraysColor;

            if (Settings.Instance.GodraysNightAurora)
            {
                GodraysColor = GameManager.GetAuroraManager().GetAuroraColour();
            }

            foreach (WeatherStatesData eachWeatherStateConfig in unistorm.m_WeatherStateConfigs)
            {
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_DawnColors,         color: GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_MorningColors,      color: GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_MiddayColors,       color: GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_AfternoonColors,    color: GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_DuskColors,         color: GodraysColor);
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_NightColors,        color: GodraysColor);
            }
        }
    }
}
