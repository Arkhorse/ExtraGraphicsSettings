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

            foreach (WeatherStatesData eachWeatherStateConfig in unistorm.m_WeatherStateConfigs)
            {
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_DawnColors,         color: GetGodraysColor());
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_MorningColors,      color: GetGodraysColor());
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_MiddayColors,       color: GetGodraysColor());
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_AfternoonColors,    color: GetGodraysColor());
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_DuskColors,         color: GetGodraysColor());
                TODStateUtils.ChangeTODGodrays(eachWeatherStateConfig.m_NightColors,        color: GetGodraysColor());
            }
        }

        public static Color GetGodraysColor()
        {
            Color GodraysColor = new(1,1,1,0);
            if (GameManager.GetUniStorm() != null)
            {
                UniStormWeatherSystem unistorm = GameManager.GetUniStorm();
                GodraysColor = Settings.Instance.GodraysColor;

                if (Settings.Instance.GodraysNightAurora)
                {
                    GodraysColor = GameManager.GetAuroraManager().GetAuroraColour();
                }

                GodraysColor.a = (Settings.Instance.Godrays == GodraysPresets.Custom) ? Settings.Instance.GodraysColorAlpha : 1;
            }

            return GodraysColor;
        }
    }
}
