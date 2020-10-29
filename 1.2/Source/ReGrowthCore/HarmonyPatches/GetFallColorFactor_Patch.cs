using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ReGrowthCore
{
	[StaticConstructorOnStartup]
	internal static class HarmonyInit
	{
		static HarmonyInit()
		{
			new Harmony("Helixien.ReGrowthCore").PatchAll();

            Harmony harmony = new Harmony("rimworld.erdelf.debug");
            harmony.Patch(AccessTools.Method(typeof(TickManager), nameof(TickManager.DoSingleTick)), postfix: new HarmonyMethod(typeof(HarmonyInit), nameof(Postfix)));


            terrains = new TerrainDef[]
                       {
                           RGDefOf.RG_Lava
                       };
        }

        
        [TweakValue("Custom", 0f, 0.25f)]
        private static float WaterTimeMult = 0.1f;

        public static void Postfix()
        {
            foreach (TerrainDef terrainDef in terrains)
            {
                terrainDef.waterDepthMaterial.SetFloat("_GameSeconds", Find.TickManager.TicksGame * WaterTimeMult);
            }
        }

        static TerrainDef[] terrains;

        [TweakValue("Custom", 0f, 2f)]
        private static float WaterDepthIntensity;

        public static void WaterDepthIntensity_Changed()
        {
            foreach (TerrainDef def in terrains)
                def.waterDepthMaterial.SetFloat("_WaterDepthIntensity", WaterDepthIntensity);
        }

        [TweakValue("Custom", 0f, 2f)]
        private static float WaterRippleIntensity;

        public static void WaterRippleIntensity_Changed()
        {
            foreach (TerrainDef def in terrains)
                def.waterDepthMaterial.SetFloat("_WaterRippleDensity", WaterRippleIntensity);
        }

        [TweakValue("Custom", 0f, 1f)]
        private static float ColorR;
        [TweakValue("Custom", 0f, 1f)]
        private static float ColorG;
        [TweakValue("Custom", 0f, 1f)]
        private static float ColorB;
        [TweakValue("Custom", 0f, 1f)]
        private static float ColorA;

        public static void ColorR_Changed()
        {
            foreach (TerrainDef def in terrains)
                def.waterDepthMaterial.SetVector("_Color", new Vector4(ColorR, ColorG, ColorB, ColorA));
        }
        public static void ColorG_Changed()
        {
            foreach (TerrainDef def in terrains)
                def.waterDepthMaterial.SetVector("_Color", new Color(ColorR, ColorG, ColorB, ColorA));
        }
        public static void ColorB_Changed()
        {
            foreach (TerrainDef def in terrains)
                def.waterDepthMaterial.SetVector("_Color", new Color(ColorR, ColorG, ColorB, ColorA));
        }
        public static void ColorA_Changed()
        {
            foreach (TerrainDef def in terrains)
                def.waterDepthMaterial.SetVector("_Color", new Color(ColorR, ColorG, ColorB, ColorA));
        }
    }

    [HarmonyPatch(typeof(PlantFallColors), "GetFallColorFactor")]
    public static class GetFallColorFactor
    {
        public static float fallColorFactor = 0f;
        public static void Postfix(ref float __result)
        {
            fallColorFactor = __result;
        }
    }
}
