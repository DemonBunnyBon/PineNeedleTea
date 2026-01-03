
namespace PineNeedleTeaMod
{
	public class Implementation : MelonMod
	{

        private static AssetBundle? assetBundle;

        internal static AssetBundle TeaTexturesBundle
        {
            get => assetBundle ?? throw new System.NullReferenceException(nameof(assetBundle));
        }
        public override void OnInitializeMelon()
		{
            assetBundle = PineNeedleTeaMod.Utilities.LoadFromStream("PineNeedleTea.pineteaassets");
            Settings.instance.AddToModSettings("Pine Needle Tea");
        }

    }
}