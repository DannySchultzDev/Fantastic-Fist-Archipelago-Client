using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class GameCache
	{
		public static readonly Dictionary<string, string> levelSelectNameToEntranceNameDict = new Dictionary<string, string>
		{
			{"Level0", "1-1" },
			{"Level1", "1-2" },
			{"Level2", "1-3" },
			{"Level3", "1-4" },
			{"Level4", "1-5" },
			{"Level5", "1-6" },
			{"Level6", "1-7" },
			{"Level7", "1-8" },
			{"Level2_B", "1-A" },
			{"Level3_B", "1-B" },
			{"Level4_B", "1-C" },
			{"Level11", "2-1" },
			{"Level12", "2-2" },
			{"Level13", "2-3" },
			{"Level14", "2-4" },
			{"Level15", "2-5" },
			{"Level_16", "2-6" },
			{"Level12_B", "2-A" },
			{"Level13_B", "2-B" },
			{"Level14_B", "2-C" },
			{"Level15_B", "2-D" },
			{"Level_21", "3-1" },
			{"Level_22", "3-2" },
			{"Level_23", "3-3" },
			{"Level_24", "3-4" },
			{"Level_25", "3-5" },
			{"Level_26", "3-6" },
			{"Level_27", "3-7" },
			{"Level_23_B", "3-A" },
			{"Level_24_B", "3-B" },
			{"Level_30", "4-1" },
			{"Level_31", "4-2" },
			{"Level_32", "4-3" },
			{"Level_33", "4-4" },
			{"Level_34", "4-5" },
			{"Level_35", "4-6" },
			{"Level_36", "4-7" },
			{"Level_37", "4-8" },
			{"Level_38", "4-9" },
			{"Level_31_B", "4-A" },
			{"Level_40", "5-1" },
			{"Level_41", "5-2" },
			{"Level_42", "5-3" },
			{"Level_43", "5-4" },
			{"Level_44", "1-0" },
		};

		public static readonly Dictionary<int, string> levelListIndexToLevelIdDict = new Dictionary<int, string>
		{
			{0, "1-1" },
			{1, "1-2" },
			{2, "1-3" },
			{3, "1-4" },
			{4, "1-5" },
			{5, "1-6" },
			{6, "1-7" },
			{7, "1-8" },
			{8, "1-A" },
			{9, "1-B" },
			{10, "1-C" },
			{11, "2-1" },
			{12, "2-2" },
			{13, "2-3" },
			{14, "2-4" },
			{15, "2-5" },
			{16, "2-6" },
			{17, "2-A" },
			{18, "2-B" },
			{19, "2-C" },
			{20, "2-D" },
			{21, "3-1" },
			{22, "3-2" },
			{23, "3-3" },
			{24, "3-4" },
			{25, "3-5" },
			{26, "3-6" },
			{27, "3-7" },
			{28, "3-A" },
			{29, "3-B" },
			{30, "4-1" },
			{31, "4-2" },
			{32, "4-3" },
			{33, "4-4" },
			{34, "4-5" },
			{35, "4-6" },
			{36, "4-7" },
			{37, "4-8" },
			{38, "4-9" },
			{39, "4-A" },
			{40, "5-1" },
			{41, "5-2" },
			{42, "5-3" },
			{43, "5-4" },
			{44, "1-0" },
		};

		public static Dictionary<string, int> levelIdToLevelListIndexDict = 
			levelListIndexToLevelIdDict.ToDictionary(x => x.Value, x => x.Key);

		public static readonly Dictionary<string, string> firstRoomToLevelIds = new Dictionary<string, string>
		{
			{"Introduction Room 1", "1-1" },
			{"The Caves Room 1", "1-2" },
			{"Get A Grip Room 1", "1-3" },
			{"Verticality Room 1", "1-4" },
			{"Catch A Ride Room 1", "1-5" },
			{"Chaos Cavern Room 1", "1-6" },
			{"Holding On Room 1", "1-7" },
			{"Fist Fight Room 1", "1-8" },
			{"Depths Room 1", "1-A" },
			{"Cliff Warning Room 1", "1-B" },
			{"The Library Room 1", "1-C" },
			{"Midnight Grove Room 1", "2-1" },
			{"Briarbrush Woods Room 1", "2-2" },
			{"Various Explosives Room 1", "2-3" },
			{"Together By Tether Room 1", "2-4" },
			{"Pop Unlock Room 1", "2-5" },
			{"The Gatekeeper Room 1", "2-6" },
			{"The Elevator Room 1", "2-A" },
			{"Frostbite Room 1", "2-B" },
			{"Forgotten Archives Room 1", "2-C" },
			{"The Scenic Route Room 1", "2-D" },
			{"The Timeless Temple Room 1", "3-1" },
			{"Haunted Halls Room 1", "3-2" },
			{"Borrowed Time Room 1", "3-3" },
			{"Nyctophobia Room 1", "3-4" },
			{"Shifting Walls Room 1", "3-5" },
			{"Skullduggery Room 1", "3-6" },
			{"The Throne Room Room 1", "3-7" },
			{"Pop To The Top Room 1", "3-A" },
			{"Periodic Prison Room 1", "3-B" },
			{"Infinity Garden Room 1", "4-1" },
			{"Autumnal Aether Room 1", "4-2" },
			{"Among The Stars Room 1", "4-3" },
			{"Den Of Pixies Room 1", "4-4" },
			{"Heels Over Head Room 1", "4-5" },
			{"The Hive Room 1", "4-6" },
			{"The Five Mile Spire Room 1", "4-7" },
			{"Gube Gardens Room 1", "4-8" },
			{"The Golf Fungus Room 1", "4-9" },
			{"Over The Woods Room 1", "4-A" },
			{"Welcome To The Void Room 1", "5-1" },
			{"The Sky Is Falling Room 1", "5-2" },
			{"The Looking Glass Room 1", "5-3" },
			{"Galactic Central Point Room 1", "5-4" },
			{"Home Room 1", "1-0" }
		};

		public static Dictionary<string, string> entranceRandoTrueEntrances = new Dictionary<string, string>();
		public static Dictionary<string, LevelSelect> levelSelectDict = new Dictionary<string, LevelSelect>();

		/// <summary>
		/// This should be called after a successful connect. It clears and regenerates the entrance rando dict.
		/// </summary>
		public static void UpdateEntranceRando()
		{
			string entrancesRaw = Core.slotData["entrances"].ToString();
			Queue<string> entrancesRawSplit = new Queue<string>(entrancesRaw.Split('\"'));

			entranceRandoTrueEntrances.Clear();
			while (entrancesRawSplit.Count > 1)
			{
				/*
				[
					"1-1",
					"Introduction Room 1",
				]
				*/
				entrancesRawSplit.Dequeue();
				string levelId = entrancesRawSplit.Dequeue();
				entrancesRawSplit.Dequeue();
				string firstRoom = entrancesRawSplit.Dequeue();

				entranceRandoTrueEntrances.Add(levelId, firstRoomToLevelIds[firstRoom]);
			}
		}

	}
}
