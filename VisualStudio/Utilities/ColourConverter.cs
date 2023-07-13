namespace ExtraGraphicsSettings
{
    public class ColourConverter
    {
        public static Color GetGodraysColourFromSettings(GodraysColours setting)
        {
            Color color = Color.white;

            switch (setting)
            {
                case GodraysColours.blue:
                    color = Color.blue;
                    break;
                case GodraysColours.cyan:
                    color = Color.cyan;
                    break;
                case GodraysColours.gray:
                    color = Color.gray;
                    break;
                case GodraysColours.green:
                    color = Color.green;
                    break;
                case GodraysColours.grey:
                    color = Color.grey;
                    break;
                case GodraysColours.magenta:
                    color = Color.magenta;
                    break;
                case GodraysColours.red:
                    color = Color.red;
                    break;
                case GodraysColours.white:
                    color = Color.white;
                    break;
                case GodraysColours.yellow:
                    color = Color.yellow;
                    break;
                default:
                    color = Color.magenta;
                    break;
            }
            return color;
        }

        public static Color GetGodraysColourFromSettings(int red, int green, int blue)
        {
            Vector4 CustomColor = new Vector3(red, green, blue);
            return CustomColor;
        }

        public static Color GetGodraysColourFromSettings()
        {
            Vector4 color = new Vector3(Settings.Instance.GodraysColorRed, Settings.Instance.GodraysColorGreen, Settings.Instance.GodraysColorBlue);
            return color;
        }
    }
}
