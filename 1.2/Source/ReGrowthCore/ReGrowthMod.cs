using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using static ReGrowthCore.ReGrowthSettings;

namespace ReGrowthCore
{
    class ReGrowthMod : Mod
    {
        public static ReGrowthSettings settings;
        public ReGrowthMod(ModContentPack pack) : base(pack)
        {
            settings = GetSettings<ReGrowthSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            settings.DoSettingsWindowContents(inRect);
        }

        // Return the name of the mod in the settings tab in game
        public override string SettingsCategory()
        {
            return "ReGrowth Core";
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            DefsAlterer.DoDefsAltering();
        }
    }

    [StaticConstructorOnStartup]
    public static class DefsAlterer
    {
        static DefsAlterer()
        {
            DoDefsAltering();
        }


        public static void DoDefsAltering()
        {
            switch (ReGrowthMod.settings.currentLevel)
            {
                case DarknessLevel.Vanilla:
                    var clearWeather = WeatherDefOf.Clear;
                    clearWeather.skyColorsDay = new SkyColorSet
                    {
                        sky = new Color(1, 1, 1),
                        shadow = new Color(0.798f, 0.827f, 0.85f),
                        overlay = new Color(1, 1, 1),
                        saturation = 1.4f
                    };
                    clearWeather.skyColorsDay = new SkyColorSet
                    {
                        sky = new Color(1, 1, 1),
                        shadow = new Color(0.798f, 0.827f, 0.85f),
                        overlay = new Color(1, 1, 1),
                        saturation = 1.4f
                    };

                    break;
            }
        }
    }
}
