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
