using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace RegrowthCore
{

	[HarmonyPatch(typeof(AmbientSoundManager))]
	[HarmonyPatch("RecreateMapSustainers")]
	internal static class RecreateMapSustainers_Patch
	{
		private static void Prefix()
		{
			Log.Message("RecreateMapSustainers_Patch", true);
		}
	}

	[HarmonyPatch(typeof(SoundStarter))]
	[HarmonyPatch("PlayOneShot")]
	internal static class PlayOneShot_Patch
	{
		private static void Prefix(SoundDef soundDef, SoundInfo info)
		{
			Log.Message("PlayOneShot_Patch: " + soundDef + " - " + info, true);
		}
	}

	[HarmonyPatch(typeof(SoundStarter))]
	[HarmonyPatch("PlayOneShotOnCamera")]
	internal static class PlayOneShotOnCamera_Patch
	{
		private static void Prefix(SoundDef soundDef, Map onlyThisMap)
		{
			Log.Message("PlayOneShotOnCamera_Patch: " + soundDef, true);
		}
	}

	[HarmonyPatch(typeof(SoundStarter))]
	[HarmonyPatch("TrySpawnSustainer")]
	internal static class TrySpawnSustainer_Patch
	{
		private static void Prefix(SoundDef soundDef, SoundInfo info)
		{
			Log.Message("TrySpawnSustainer_Patch: " + soundDef + " - " + info, true);
		}
	}

	[HarmonyPatch(typeof(MusicManagerPlay))]
	[HarmonyPatch("StartNewSong")]
	internal static class StartNewSong_Patch
	{
		private static void Postfix(AudioSource ___audioSource)
		{
			Log.Message("StartNewSong_Patch: " + ___audioSource, true);
		}
	}

	[HarmonyPatch(typeof(MusicManagerEntry))]
	[HarmonyPatch("StartPlaying")]
	internal static class StartPlaying_Patch
	{
		private static void Postfix(AudioSource ___audioSource)
		{
			Log.Message("StartPlaying_Patch: " + ___audioSource, true);
		}
	}

	[HarmonyPatch(typeof(MusicManagerPlay))]
	[HarmonyPatch("ChooseNextSong")]
	internal static class ChooseNextSong_Patch
	{
		private static void Postfix(SongDef __result)
		{
			Log.Message("ChooseNextSong: " + __result, true);
		}
	}

	[HarmonyPatch(typeof(MusicManagerPlay))]
	[HarmonyPatch("AppropriateNow")]
	internal static class AppropriateNow_Patch
	{
		private static void Postfix(SongDef song, bool __result)
		{
			Log.Message("AppropriateNow_Patch: " + song + " - " + __result, true);
		}
	}

}
