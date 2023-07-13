namespace ExtraGraphicsSettings
{
    public class StatusBarUtils
    {
        private static Vector3 containerOffset { get; }         = new Vector3(10, 5);
        private static Vector3 statusLabelOffset { get; }       = new Vector3(-72, -8);
        private static Vector3 conditionLabelOffset { get; }    = new Vector3(72, -10.5f);
        public static void CenterStutusLabel(UILabel label)
        {
            if (label == null) return;

            label.alignment = NGUIText.Alignment.Center;
            label.transform.localPosition += new Vector3(-label.width / 2, 0) + containerOffset;
        }

        public static void ActivateAndMovePercentLabel(UILabel label)
        {
            if (label == null) return;

            label.alignment = NGUIText.Alignment.Left;
            label.transform.localPosition += statusLabelOffset + containerOffset;
            label.fontSize = Settings.Instance.PercentLabelFontSize;

            label.enabled = true;
            NGUITools.SetActive(label.gameObject, true);
        }

        public static void ActivateAndMoveConditionLabel(UILabel label)
        {
            if (label == null) return;

            label.pivot = UIWidget.Pivot.Left;
            label.gameObject.transform.localPosition += conditionLabelOffset;

            label.enabled = true;
            NGUITools.SetActive(label.gameObject, true);
        }
    }
}
