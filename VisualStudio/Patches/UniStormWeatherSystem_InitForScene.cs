namespace GameConfigurationManager
{
    [HarmonyPatch(typeof(UniStormWeatherSystem), nameof(UniStormWeatherSystem.InitializeForScene))]
    internal class UniStormWeatherSystem_InitForScene
    {
        public static void Postfix(UniStormWeatherSystem __instance)
        {
            if (!Settings.Instance.Vignette)
            {
                foreach (WeatherStatesData eachWeatherStateConfig in __instance.m_WeatherStateConfigs)
                {
                    if (eachWeatherStateConfig == null)
                    {
                        continue;
                    }
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_DawnColors,       "vignette");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_MorningColors,    "vignette");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_MiddayColors,     "vignette");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_AfternoonColors,  "vignette");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_DuskColors,       "vignette");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_NightColors,      "vignette");
                }
            }

            if (!Settings.Instance.Chromatic)
            {
                foreach (WeatherStatesData eachWeatherStateConfig in __instance.m_WeatherStateConfigs)
                {
                    if (eachWeatherStateConfig == null)
                    {
                        continue;
                    }
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_DawnColors,       "chromatic");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_MorningColors,    "chromatic");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_MiddayColors,     "chromatic");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_AfternoonColors,  "chromatic");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_DuskColors,       "chromatic");
                    TODStateUtils.ChangeTODStateData(eachWeatherStateConfig.m_NightColors,      "chromatic");
                }
            }

            GodraysUpdater.UpdateGodraysColor();
        }
    }
}
