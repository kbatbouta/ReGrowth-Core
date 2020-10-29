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
    public static class ReGrowthUtils
    {
        public static SkyColorSet SkyColorSet
        {
            get
            {
                switch(ReGrowthMod.settings.currentLevel)
                {
                    case DarknessLevel.Realistic:
                        return new SkyColorSet(new Color(0.117f, 0.117f, 0.147f), Color.white, new Color(0.6f, 0.6f, 0.6f), 1f);
                    case DarknessLevel.Light:
                        return new SkyColorSet(new Color(0.4f, 0.4f, 0.46f), Color.white, new Color(0.6f, 0.6f, 0.6f), 1f);
                    default:
                        return new SkyColorSet(new Color(0.4f, 0.4f, 0.46f), Color.white, new Color(0.6f, 0.6f, 0.6f), 1f);
                }
            }
        }
    }
}
