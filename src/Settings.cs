using ModSettings;

namespace PineNeedleTeaMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Pine Needle Settings")]

        [Name("Pine Needle Spawn Chance")]
        [Description("Adjust the chance for pine needles to spawn under trees.")]
        [Slider(0f,25f,51)]
        public float NeedleChance = 10.5f;

        [Name("Pine Needle Tea Vitamin C Amount")]
        [Description("Adjust the amount of Vitamin C Pine Needle Tea gives. [Requires scene reload or transition]")]
        [Slider(0,35,30)]
        public int VitaminC = 30;

        [Name("Needle Drying Time")]
        [Description("Adjust how many hours are needed for needles to fully dry before they can be prepared. [Requires scene reload or transition]")]
        [Choice("12", "24", "48")]
        public int hoursdry = 1;

        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. (Confirm and scene reload/transition required.)")]
        public bool ResetSettings = false;

        protected override void OnConfirm()
        {
            ApplyReset();
            instance.ResetSettings = false;
            base.OnConfirm();
            base.RefreshGUI();
        }

        public static void ApplyReset()
        {
            if(instance.ResetSettings==true)
            {
                instance.hoursdry = 1;
                instance.VitaminC = 30;
                instance.NeedleChance = 10.5f;
                instance.ResetSettings = false;
            }
        }
    }


}
