using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

// Copyright Sarg - Alpha Biomes 2020

namespace ReGrowthCore
{
    public class RGW_Wasteland_ObjectSpawnsDef : Def
    {
        public ThingDef thingDef;
        public bool allowOnWater;
        public bool allowOnChunks;
        public IntRange numberToSpawn;
        public List<string> terrainValidationAllowed;
        public List<string> terrainValidationDisallowed;
        public string allowedBiome;
        public List<string> biomesWithExtraGeneration;
        public int extraGeneration = 0;
        public string disallowedBiome;
        public bool findCellsOutsideColony = false;
    }
}
