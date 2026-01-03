
namespace PineNeedleTeaMod
{

    [HarmonyPatch(typeof(RadialObjectSpawner), nameof(RadialObjectSpawner.GetNextPrefabToSpawn))]
    internal class AddNeedleSpawns
    {
        private static void Postfix(RadialObjectSpawner __instance, ref GameObject __result)
        {

            if (__instance != null && __instance.name.Contains("RadialSpawn_sticks") && Utilities.Needles != null)
            {
               if (Utils.RollChance(Settings.instance.NeedleChance))
                {
                    __result = Utilities.Needles;
                }
            }
        }
    }
    
    [HarmonyPatch(typeof(GearItem),nameof(GearItem.Awake))]
    internal class ChangeTeaProperties
    {
        private static void Postfix(GearItem __instance)
        {
            if (__instance.name.Contains("GEAR_PineNeedleTea"))
            {
                FoodItem f = __instance.gameObject.GetComponent<FoodItem>();
                if (f != null)
                {
                    f.m_HeatedWhenCooked = true;
                    f.m_Nutrients = Utilities.MakeVitaminC(Settings.instance.VitaminC);
                }
                Cookable c = __instance.gameObject.GetComponent<Cookable>();
                if (c != null)
                {
                    c.m_CookingPotMaterialsList = new Material[1] { Utilities.LiquidMaterial() };
                }
                FreezingBuff fb = __instance.gameObject.AddComponent<FreezingBuff>();
                fb.m_DurationHours = 0.5f;
                fb.m_InitialPercentDecrease = 10f;
                fb.m_RateOfIncreaseScale = 1; 
            }
            if (__instance.name.Contains("GEAR_PineNeedlePrepared"))
            {
                Cookable c = __instance.gameObject.GetComponent<Cookable>();
                if (c != null)
                {
                    __instance.gameObject.GetComponent<Cookable>().m_CookingPotMaterialsList = new Material[1] { Utilities.LiquidMaterial() };
                }
            }
            if (__instance.name.Contains("GEAR_PineNeedle") && !__instance.name.Contains("GEAR_PineNeedlePrepared"))
            {
                EvolveItem e = __instance.gameObject.GetComponent<EvolveItem>();
                if (e != null)
                {
                    switch(Settings.instance.hoursdry)
                    {
                        case 0:
                            e.m_TimeToEvolveGameDays = 0.5f;
                            break;

                        case 1:
                            e.m_TimeToEvolveGameDays = 1;
                            break;

                        case 2:
                            e.m_TimeToEvolveGameDays = 2;
                            break;

                    }
                }

            }
        }
    }


}

