﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ReGrowthCore
{
    class ReGrowthSettings : ModSettings
    {
        public enum DarknessLevel
        {
            Vanilla,
            Light,
            Realistic,
            Extreme
        }

        public DarknessLevel currentLevel = DarknessLevel.Vanilla;

        public bool SpawnLeaves = true;

        //public static bool ColdFog = true;
        //
        //public static bool IceLayer = true;
        //
        //public static bool RainWaterPuddles = true;
        //
        //public static bool RainCleanWaterPuddles = false;
        //
        //public static int FogVelocity = 12;
        //
        //public static int FogTemp = 0;
        //
        //public static int PuddleChance = 20;


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref SpawnLeaves, "SpawnLeaves", true);
            Scribe_Values.Look(ref currentLevel, "currentLevel", DarknessLevel.Vanilla);

            //Scribe_Values.Look(ref ColdFog, "ColdFog", true);
            //Scribe_Values.Look(ref IceLayer, "IceLayer", true);
            //Scribe_Values.Look(ref RainWaterPuddles, "RainWaterPuddles", true);
            //Scribe_Values.Look(ref RainCleanWaterPuddles, "RainCleanWaterPuddles", true);
            //Scribe_Values.Look(ref FogVelocity, "FogVelocity");
            //Scribe_Values.Look(ref FogTemp, "FogTemp");
            //Scribe_Values.Look(ref PuddleChance, "PuddleChance");

        }

        // Draw the actual settings window that shows up after selecting Z-Levels in the list
        public void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("RG.SpawnLeaves".Translate(), ref SpawnLeaves);
            listingStandard.Label("RG.SelectDarknessLevel".Translate());
            foreach (string text in Enum.GetNames(typeof(DarknessLevel)))
            {
                DarknessLevel level = (DarknessLevel)Enum.Parse(typeof(DarknessLevel), text);
                if (listingStandard.RadioButton(Translator.Translate(text), this.currentLevel == level, 8f, null))
                {
                    this.currentLevel = level;
                }
            }

            //listingStandard.CheckboxLabeled("RG.ColdFog".Translate(), ref ColdFog);
            //listingStandard.CheckboxLabeled("RG.IceLayer".Translate(), ref IceLayer);
            //listingStandard.CheckboxLabeled("RG.RainWaterPuddles".Translate(), ref RainWaterPuddles);
            //listingStandard.CheckboxLabeled("RG.RainCleanWaterPuddles".Translate(), ref RainCleanWaterPuddles);
            //listingStandard.Label("RG.FogVelocity".Translate() + ": " + FogVelocity);
            //listingStandard.Slider(FogVelocity, 0, 30);
            //listingStandard.Label("RG.FogTemp".Translate() + ": " + FogTemp);
            //listingStandard.Slider(FogTemp, -273, 0);
            //listingStandard.Label("RG.PuddleChance".Translate() + ": " + PuddleChance + "%");
            //listingStandard.Slider(PuddleChance, 0, 100);
            //listingStandard.End();
        }

    }
}
