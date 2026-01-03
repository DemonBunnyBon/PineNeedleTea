using UnityEngine;
using Il2Cpp;
using MelonLoader;
using UnityEngine.AddressableAssets;





namespace PineNeedleTeaMod
{
    internal static class Utilities
    {
        public static Il2CppSystem.Collections.Generic.List<FoodItem.Nutrient> MakeVitaminC(int amount = 10)
        {
            FoodItem.Nutrient vitc = new FoodItem.Nutrient();
            vitc.m_Amount = amount;
            vitc.m_Nutrient = new Il2CppTLD.Gameplay.AssetReferenceNutrientDefinition("13a8bda1e12982e428b7551cc01b01df");
            Il2CppSystem.Collections.Generic.List<FoodItem.Nutrient> list = new Il2CppSystem.Collections.Generic.List<FoodItem.Nutrient>();
            list.Add(vitc);
            return list;
        }

        public static Material LiquidMaterial()
        {
            Texture2D LiquidTexture = Implementation.TeaTexturesBundle.LoadAsset<Texture2D>("T_PineTea_Cooking");
            Material LiquidMaterial = new Material(GearItem.LoadGearItemPrefab("GEAR_CoffeeCup").gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList[0]);
            LiquidMaterial.SetTexture("_Main_texture2", LiquidTexture);
            return LiquidMaterial;
        }
        
        
        public static GameObject Needles = Addressables.LoadAssetAsync<GameObject>("GEAR_PineNeedle").WaitForCompletion();


        public static AssetBundle LoadFromStream(string name)
        {
            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                MemoryStream? memory = new((int)stream.Length);
                stream!.CopyTo(memory);

                Il2CppSystem.IO.MemoryStream memoryStream = new Il2CppSystem.IO.MemoryStream(memory.ToArray());
                
                AssetBundle loadFromMemoryInternal = AssetBundle.LoadFromStream(memoryStream);
                return loadFromMemoryInternal;
            };
        }


    }






}


