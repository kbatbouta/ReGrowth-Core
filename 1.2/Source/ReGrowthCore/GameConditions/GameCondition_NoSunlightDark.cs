using RimWorld;
using UnityEngine;
using Verse;

namespace ReGrowthCore
{
	public class GameCondition_NoSunlightDark : GameCondition
	{
		public override int TransitionTicks
		{
			get
			{
				return 200;
			}
		}
		public override float SkyTargetLerpFactor(Map map)
		{
			return GameConditionUtility.LerpInOutValue(this, (float)this.TransitionTicks, 1f);
		}

		public override SkyTarget? SkyTarget(Map map)
		{
			return new SkyTarget?(new SkyTarget(0f, ReGrowthUtils.SkyColorSet, 1f, 0f));
		}
	}
}
