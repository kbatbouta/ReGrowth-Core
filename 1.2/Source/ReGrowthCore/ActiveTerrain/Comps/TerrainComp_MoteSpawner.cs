using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace ReGrowthCore
{
    /// <summary>
    /// This terrain comp will push heat endlessly with no regard for ambient temperature.
    /// </summary>
    /// 
    public class TerrainCompProperties_MoteSpawner : TerrainCompProperties
    {
        public TerrainCompProperties_MoteSpawner()
        {
            compClass = typeof(TerrainComp_MoteSpawner);
        }
        public ThingDef moteDef;
        public IntRange tickInterval;
        public FloatRange size;
        public FloatRange rotationRate;
        public FloatRange velocityAngle;
        public FloatRange velocitySpeed;
        public Color instanceColor;
        public FloatRange reqTempRangeToSpawn;
        public List<IntRange> reqTimeRangeToSpawn;
    }
    public class TerrainComp_MoteSpawner : TerrainComp
    {
        public TerrainCompProperties_MoteSpawner Props { get { return (TerrainCompProperties_MoteSpawner)props; } }

        public bool CanSpawnInRequiredTimeRanges()
        {
            var curTime = GenLocalDate.HourInteger(this.parent.Map);
            if (Props.reqTimeRangeToSpawn != null)
            {
                foreach (var reqTime in Props.reqTimeRangeToSpawn)
                {
                    Log.Message(reqTime.min + " - " + reqTime.max + " - " + curTime);
                    Log.Message((curTime >= reqTime.min).ToString());
                    Log.Message((curTime <= reqTime.max).ToString());
                    if (curTime >= reqTime.min && curTime <= reqTime.max)
                    {
                        Log.Message(" - CanSpawnInRequiredTimeRanges - return true; - 6", true);
                        return true;
                    }
                }
            }
            else
            {
                Log.Message(" - CanSpawnInRequiredTimeRanges - return true; - 7", true);
                return true;
            }
            Log.Message(" - CanSpawnInRequiredTimeRanges - return false; - 7", true);
            return false;
        }

        public override void CompTick()
        {
            base.CompTick();
            Log.Message(" - CompTest - if (Props.reqTempRangeToSpawn != null && !Props.reqTempRangeToSpawn.Includes(this.parent.Position.GetTemperature(this.parent.Map))) return; - 2", true);
            if (Props.reqTempRangeToSpawn != null && !Props.reqTempRangeToSpawn.Includes(this.parent.Position.GetTemperature(this.parent.Map))) return;
            Log.Message(" - CompTest - if (!CanSpawnInRequiredTimeRanges()) return; - 3", true);
            if (!CanSpawnInRequiredTimeRanges()) return;

            if (Find.TickManager.TicksGame % Props.tickInterval.RandomInRange == 0)
            {
                Log.Message(" - CompTest - if (Props.size.min > 0f) - 5", true);
                if (Props.size.min > 0f)
                {
                    Log.Message(" - CompTest - ThrowMote(this.parent.Position.ToVector3Shifted(), this.parent.Map, Props.size.RandomInRange); - 6", true);
                    ThrowMote(this.parent.Position.ToVector3Shifted(), this.parent.Map, Props.size.RandomInRange);
                }
                else
                {
                    Log.Message(" - CompTest - ThrowMote(this.parent.Position.ToVector3Shifted(), this.parent.Map, 1f); - 7", true);
                    ThrowMote(this.parent.Position.ToVector3Shifted(), this.parent.Map, 1f);
                }
            }
        }

        public void ThrowMote(Vector3 loc, Map map, float size)
        {
            if (!loc.ShouldSpawnMotesAt(map))
            {
                return;
            }
            MoteThrown moteThrown = (MoteThrown)ThingMaker.MakeThing(Props.moteDef, null);
            moteThrown.Scale = size;
            if (Props.rotationRate != null)
            {
                moteThrown.rotationRate = Props.rotationRate.RandomInRange;
            }
            moteThrown.exactPosition = loc;
            if (Props.velocityAngle != null && Props.velocitySpeed != null)
            {
                moteThrown.SetVelocity(Props.velocityAngle.RandomInRange, Props.velocitySpeed.RandomInRange);
            }
            if (Props.instanceColor != null)
            {
                moteThrown.instanceColor = Props.instanceColor;
            }

            GenSpawn.Spawn(moteThrown, loc.ToIntVec3(), map, WipeMode.Vanish);
        }
    }
}
