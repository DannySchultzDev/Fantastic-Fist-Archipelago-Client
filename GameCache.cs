using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class GameCache
	{
		#region Entrance Rando

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



		#endregion Entrance Rando
		#region Door Rando

		/// <summary>
		//Build_84_1-1
		//Build_84_1-7 Caves
		//Build_84_1-2 Get A Grip
		//Build_84_1-6 Bumpers
		//Build_84_1-3 Catch A Ride
		//Build_84_1-10 TheMines
		//Build_84_1-9 ChaosCavern
		//Build_84_1-Boss
		//Build_84_1-4 Depths
		//Build_84_1-5 Cliff Warning
		//Build_84_1-L
		//Build_86_2-1_MidnightGrove
		//Build_86_2-2_Briar
		//Build_86_2-3_Explosives
		//Build_86_2-5_TogetherTether
		//Build_86_2-4_KeyBubbles
		//Build_86_2-B_Gatekeeper
		//Build_86_2-7_Elavator
		//Build_86_2-6_Frostbite
		//Build_86_2-8_Niche
		//Build_86_2-Scenic
		//Build_88_3A-1
		//Build_88_3A-2
		//Build_88_3B-1
		//Build_88_3B-2_Nyctophobia
		//Build_88_3B-3
		//Build_88_3A-3
		//Build_88_3-Boss
		//Build_88_3B-4 Pop
		//Build_88_3B-5 Dungeon
		//Build_89_4-1
		//Build_90_4-2
		//Build_90_4-3
		//Build_90_4-4
		//Build_90_4-5
		//Build_90_4-6 Hive
		//Build_90_4-7 Spire
		//Build_90_4-8 GubeGardens
		//Build_90_4-Boss
		//Build_90_4-Alt
		//Build_91_5-1
		//Build_91_5-2
		//Build_91_5-3
		//FinalBoss
		//Build_121_Home
		/// </summary>
		public static Dictionary<string, RoomChange> levelMapCache = new Dictionary<string, RoomChange>();

		public static Dictionary<(string, int), string> doorIdToSlotData = new Dictionary<(string, int), string>
		{
			//World 1
			{("Build_84_1-1",3), "Introduction Room 1"},
			{("Build_84_1-1",1), "Introduction Room 2"},
			{("Build_84_1-1",2), "Introduction Room 3"},
			{("Build_84_1-7 Caves",1), "The Caves Room 1"},
			{("Build_84_1-7 Caves",2), "The Caves Room 2"},
			{("Build_84_1-7 Caves",3), "The Caves Room 3"},
			{("Build_84_1-2 Get A Grip",1), "Get A Grip Room 1"},
			{("Build_84_1-2 Get A Grip",2), "Get A Grip Room 2"},
			{("Build_84_1-6 Bumpers",1), "Verticality Room 1"},
			{("Build_84_1-6 Bumpers",2), "Verticality Room 2"},
			{("Build_84_1-6 Bumpers",5), "Verticality Room 2"},
			{("Build_84_1-6 Bumpers",3), "Verticality Room 3"},
			{("Build_84_1-3 Catch A Ride",1), "Catch A Ride Room 1"},
			{("Build_84_1-3 Catch A Ride",3), "Catch A Ride Room 2"},
			{("Build_84_1-3 Catch A Ride",2), "Catch A Ride Room 3"},
			{("Build_84_1-10 TheMines",1), "Chaos Cavern Room 1"},
			{("Build_84_1-10 TheMines",2), "Chaos Cavern Room 2"},
			{("Build_84_1-9 ChaosCavern",1), "Holding On Room 1"},
			{("Build_84_1-9 ChaosCavern",2), "Holding On Room 2"},
			{("Build_84_1-9 ChaosCavern",3), "Holding On Room 3"},
			{("Build_84_1-Boss",1), "Fist Fight Room 1"},
			{("Build_84_1-Boss",6), "Fist Fight Room 2"},
			{("Build_84_1-Boss",2), "Fist Fight Room 3"},
			{("Build_84_1-Boss",3), "Fist Fight Room 4"},
			{("Build_84_1-Boss",5), "Fist Fight Room 5"},
			{("Build_84_1-4 Depths",1), "Depths Room 1"},
			{("Build_84_1-4 Depths",2), "Depths Room 2"},
			{("Build_84_1-5 Cliff Warning",1), "Cliff Warning Room 1"},
			{("Build_84_1-L",2), "The Library Room 1"},
			{("Build_84_1-L",3), "The Library Room 1"},
			{("Build_84_1-L",4), "The Library Room 1"},
			//World 2
			{("Build_86_2-1_MidnightGrove",1), "Midnight Grove Room 1"},
			{("Build_86_2-1_MidnightGrove",2), "Midnight Grove Room 2"},
			{("Build_86_2-1_MidnightGrove",3), "Midnight Grove Room 3"},
			{("Build_86_2-2_Briar",1), "Briarbrush Woods Room 1"},
			{("Build_86_2-2_Briar",2), "Briarbrush Woods Room 2"},
			{("Build_86_2-2_Briar",3), "Briarbrush Woods Room 3"},
			{("Build_86_2-3_Explosives",1), "Various Explosives Room 1"},
			{("Build_86_2-3_Explosives",2), "Various Explosives Room 2"},
			{("Build_86_2-5_TogetherTether",1), "Together By Tether Room 1"},
			{("Build_86_2-5_TogetherTether",2), "Together By Tether Room 2"},
			{("Build_86_2-5_TogetherTether",3), "Together By Tether Room 3"},
			{("Build_86_2-4_KeyBubbles",1), "Pop Unlock Room 1"},
			{("Build_86_2-4_KeyBubbles",2), "Pop Unlock Room 2"},
			{("Build_86_2-B_Gatekeeper",1), "The Gatekeeper Room 1"},
			{("Build_86_2-B_Gatekeeper",2), "The Gatekeeper Room 2"},
			{("Build_86_2-B_Gatekeeper",3), "The Gatekeeper Room 3"},
			{("Build_86_2-B_Gatekeeper",5), "The Gatekeeper Room 4"},
			{("Build_86_2-7_Elavator",1), "The Elevator Room 1"},
			{("Build_86_2-7_Elavator",2), "The Elevator Room 2"},
			{("Build_86_2-6_Frostbite",1), "Frostbite Room 1"},
			{("Build_86_2-6_Frostbite",2), "Frostbite Room 2"},
			{("Build_86_2-6_Frostbite",3), "Frostbite Room 3"},
			{("Build_86_2-8_Niche",1), "Forgotten Archives Room 1"},
			{("Build_86_2-8_Niche",2), "Forgotten Archives Room 2"},
			{("Build_86_2-8_Niche",3), "Forgotten Archives Room 3"},
			{("Build_86_2-8_Niche",4), "Forgotten Archives Room 4"},
			{("Build_86_2-Scenic",1), "The Scenic Route Room 1"},
			{("Build_86_2-Scenic",2), "The Scenic Route Room 2"},
			{("Build_86_2-Scenic",3), "The Scenic Route Room 3"},
			{("Build_86_2-Scenic",4), "The Scenic Route Room 4"},
			{("Build_86_2-Scenic",5), "The Scenic Route Room 5"},
			{("Build_86_2-Scenic",6), "The Scenic Route Room 6"},
			//World 3
			{("Build_88_3A-1",1), "The Timeless Temple Room 1"},
			{("Build_88_3A-1",2), "The Timeless Temple Room 2"},
			{("Build_88_3A-2",1), "Haunted Halls Room 1"},
			{("Build_88_3A-2",2), "Haunted Halls Room 2"},
			{("Build_88_3A-2",3), "Haunted Halls Room 3"},
			{("Build_88_3B-1",1), "Borrowed Time Room 1"},
			{("Build_88_3B-1",2), "Borrowed Time Room 2"},
			{("Build_88_3B-1",3), "Borrowed Time Room 3"},
			{("Build_88_3B-2_Nyctophobia",1), "Nyctophobia Room 1"},
			{("Build_88_3B-2_Nyctophobia",2), "Nyctophobia Room 2"},
			{("Build_88_3B-2_Nyctophobia",3), "Nyctophobia Room 3"},
			{("Build_88_3B-2_Nyctophobia",4), "Nyctophobia Room 4"},
			{("Build_88_3B-3",1), "Shifting Walls Room 1"},
			{("Build_88_3B-3",2), "Shifting Walls Room 2"},
			{("Build_88_3B-3",3), "Shifting Walls Room 3"},
			{("Build_88_3A-3",1), "Skullduggery Room 1"},
			{("Build_88_3A-3",2), "Skullduggery Room 2"},
			{("Build_88_3A-3",4), "Skullduggery Room 3"},
			{("Build_88_3A-3",3), "Skullduggery Room 4"},
			{("Build_88_3-Boss",1), "The Throne Room Room 1"},
			{("Build_88_3-Boss",3), "The Throne Room Room 2"},
			{("Build_88_3-Boss",4), "The Throne Room Room 3"},
			{("Build_88_3-Boss",5), "The Throne Room Room 3"},
			{("Build_88_3-Boss",6), "The Throne Room Room 4"},
			{("Build_88_3-Boss",7), "The Throne Room Room 5"},
			{("Build_88_3-Boss",8), "The Throne Room Room 5"},
			{("Build_88_3-Boss",9), "The Throne Room Room 6"},
			{("Build_88_3-Boss",10), "The Throne Room Room 7"},
			{("Build_88_3B-4 Pop",1), "Pop To The Top Room 1"},
			{("Build_88_3B-4 Pop",2), "Pop To The Top Room 2"},
			{("Build_88_3B-5 Dungeon",1), "Periodic Prison Room 1"},
			{("Build_88_3B-5 Dungeon",2), "Periodic Prison Room 2"},
			{("Build_88_3B-5 Dungeon",3), "Periodic Prison Room 3"},
			//World 4
			{("Build_89_4-1",1), "Infinity Garden Room 1"},
			{("Build_89_4-1",2), "Infinity Garden Room 2"},
			{("Build_90_4-2",1), "Autumnal Aether Room 1"},
			{("Build_90_4-2",3), "Autumnal Aether Room 2"},
			{("Build_90_4-3",1), "Among The Stars Room 1"},
			{("Build_90_4-3",2), "Among The Stars Room 2"},
			{("Build_90_4-3",3), "Among The Stars Room 3"},
			{("Build_90_4-4",1), "Den Of Pixies Room 1"},
			{("Build_90_4-4",2), "Den Of Pixies Room 2"},
			{("Build_90_4-4",3), "Den Of Pixies Room 3"},
			{("Build_90_4-5",1), "Heels Over Head Room 1"},
			{("Build_90_4-5",2), "Heels Over Head Room 2"},
			{("Build_90_4-5",3), "Heels Over Head Room 3"},
			{("Build_90_4-6 Hive",1), "The Hive Room 1"},
			{("Build_90_4-6 Hive",2), "The Hive Room 2"},
			{("Build_90_4-6 Hive",3), "The Hive Room 3"},
			{("Build_90_4-6 Hive",4), "The Hive Room 4"},
			{("Build_90_4-6 Hive",5), "The Hive Room 5"},
			{("Build_90_4-6 Hive",6), "The Hive Room 6"},
			{("Build_90_4-7 Spire",1), "The Five Mile Spire Room 1"},
			{("Build_90_4-7 Spire",2), "The Five Mile Spire Room 2"},
			{("Build_90_4-7 Spire",3), "The Five Mile Spire Room 3"},
			{("Build_90_4-7 Spire",4), "The Five Mile Spire Room 4"},
			{("Build_90_4-7 Spire",5), "The Five Mile Spire Room 5"},
			{("Build_90_4-7 Spire",6), "The Five Mile Spire Room 6"},
			{("Build_90_4-7 Spire",7), "The Five Mile Spire Room 7"},
			{("Build_90_4-7 Spire",8), "The Five Mile Spire Room 7"},
			{("Build_90_4-8 GubeGardens",1), "Gube Gardens Room 1"},
			{("Build_90_4-8 GubeGardens",2), "Gube Gardens Room 2"},
			{("Build_90_4-8 GubeGardens",3), "Gube Gardens Room 3"},
			{("Build_90_4-8 GubeGardens",4), "Gube Gardens Room 4"},
			{("Build_90_4-Boss",1), "The Golf Fungus Room 1"},
			{("Build_90_4-Boss",2), "The Golf Fungus Room 2"},
			{("Build_90_4-Boss",3), "The Golf Fungus Room 3"},
			{("Build_90_4-Boss",4), "The Golf Fungus Room 4"},
			{("Build_90_4-Boss",5), "The Golf Fungus Room 5"},
			{("Build_90_4-Boss",6), "The Golf Fungus Room 6"},
			{("Build_90_4-Boss",7), "The Golf Fungus Room 7"},
			{("Build_90_4-Boss",8), "The Golf Fungus Room 8"},
			{("Build_90_4-Boss",9), "The Golf Fungus Room 9"},
			{("Build_90_4-Boss",10), "The Golf Fungus Room 10"},
			{("Build_90_4-Alt",1), "Over The Woods Room 1"},
			{("Build_90_4-Alt",2), "Over The Woods Room 2"},
			//World 5
			{("Build_91_5-1",1), "Welcome To The Void Room 1"},
			{("Build_91_5-1",2), "Welcome To The Void Room 2"},
			{("Build_91_5-1",3), "Welcome To The Void Room 3"},
			{("Build_91_5-1",4), "Welcome To The Void Room 4"},
			{("Build_91_5-2",1), "The Sky Is Falling Room 1"},
			{("Build_91_5-2",2), "The Sky Is Falling Room 2"},
			{("Build_91_5-2",3), "The Sky Is Falling Room 3"},
			{("Build_91_5-2",4), "The Sky Is Falling Room 4"},
			{("Build_91_5-3",1), "The Looking Glass Room 1"},
			{("Build_91_5-3",2), "The Looking Glass Room 2"},
			{("Build_91_5-3",3), "The Looking Glass Room 3"},
			{("Build_91_5-3",4), "The Looking Glass Room 4"},
			{("FinalBoss",5), "Galactic Central Point Room 1"},
			{("FinalBoss",6), "Galactic Central Point Room 2"},
			{("FinalBoss",2), "Galactic Central Point Room 3"},
			{("Build_121_Home",1), "Home Room 1"},
			{("Build_121_Home",2), "Home Room 2"},
			{("Build_121_Home",3), "Home Room 3"},
			{("Build_121_Home",4), "Home Room 4"},
			{("Build_121_Home",5), "Home Room 5"},
		};
		public static Dictionary<string, List<string>> doorMapping = new Dictionary<string, List<string>>();
		public static Dictionary<string, (string levelId, int roomId, Vector2 spawnPos, bool freeCam, int startHoney)> slotDataToDoorId = 
			new Dictionary<string, (string levelId, int roomId, Vector2 spawnPos, bool freeCam, int startHoney)>
		{
				//World 1
				{"Introduction Room 2", ("Build_84_1-1", 3, new Vector2(0,0), false, 0)},
				{"Introduction Room 3", ("Build_84_1-1", 1, new Vector2(0,0), false, 0)},
				{"Introduction Room 4", ("Build_84_1-1", 2, new Vector2(0,0), true, 0)},
				{"The Caves Room 2", ("Build_84_1-7 Caves", 1, new Vector2(0,0), false, 0)},
				{"The Caves Room 3", ("Build_84_1-7 Caves", 2, new Vector2(0,0), false, 0)},
				{"The Caves Room 4", ("Build_84_1-7 Caves", 3, new Vector2(0,0), true, 0)},
				{"Get A Grip Room 2", ("Build_84_1-2 Get A Grip", 1, new Vector2(0,0), true, 0)},
				{"Get A Grip Room 3", ("Build_84_1-2 Get A Grip", 2, new Vector2(0,0), false, 0)},
				{"Verticality Room 2", ("Build_84_1-6 Bumpers", 1, new Vector2(0,0), true, 0)},
				{"Verticality Room 2B", ("Build_84_1-6 Bumpers", 5, new Vector2(0,0), true, 0)},
				{"Verticality Room 3", ("Build_84_1-6 Bumpers", 2, new Vector2(0,0), true, 0)},
				{"Verticality Room 4", ("Build_84_1-6 Bumpers", 3, new Vector2(0,0), true, 0)},
				{"Catch A Ride Room 2", ("Build_84_1-3 Catch A Ride", 1, new Vector2(0,0), true, 0)},
				{"Catch A Ride Room 3", ("Build_84_1-3 Catch A Ride", 3, new Vector2(0,0), true, 0)},
				{"Catch A Ride Room 4", ("Build_84_1-3 Catch A Ride", 2, new Vector2(0,0), false, 0)},
				{"Chaos Cavern Room 2", ("Build_84_1-10 TheMines", 1, new Vector2(0,0), true, 0)},
				{"Chaos Cavern Room 3", ("Build_84_1-10 TheMines", 2, new Vector2(0,0), true, 0)},
				{"Holding On Room 2", ("Build_84_1-9 ChaosCavern", 1, new Vector2(0,0), false, 0)},
				{"Holding On Room 3", ("Build_84_1-9 ChaosCavern", 2, new Vector2(0,0), true, 0)},
				{"Holding On Room 4", ("Build_84_1-9 ChaosCavern", 3, new Vector2(0,0), true, 0)},
				{"Fist Fight Room 2", ("Build_84_1-Boss", 1, new Vector2(0,0), false, 0)},
				{"Fist Fight Room 3", ("Build_84_1-Boss", 6, new Vector2(0,0), false, 0)},
				{"Fist Fight Room 4", ("Build_84_1-Boss", 2, new Vector2(0,0), true, 0)},
				{"Fist Fight Room 5", ("Build_84_1-Boss", 3, new Vector2(0,0), true, 0)},
				{"Fist Fight Boss Arena", ("Build_84_1-Boss", 5, new Vector2(0,0), false, 0)},
				{"Depths Room 2", ("Build_84_1-4 Depths", 1, new Vector2(0,0), true, 0)},
				{"Depths Room 3", ("Build_84_1-4 Depths", 2, new Vector2(0,0), true, 0)},
				{"Cliff Warning Room 2", ("Build_84_1-5 Cliff Warning", 1, new Vector2(0,0), false, 0)},
				{"The Library Room 1B", ("Build_84_1-L", 2, new Vector2(0,0), false, 0)},
				{"The Library Room 1C", ("Build_84_1-L", 3, new Vector2(0,0), false, 0)},
				{"The Library Room 1D", ("Build_84_1-L", 4, new Vector2(0,0), false, 0)},
				//World 2
				{"Midnight Grove Room 2", ("Build_86_2-1_MidnightGrove", 1, new Vector2(0,0), true, 0)},
				{"Midnight Grove Room 3", ("Build_86_2-1_MidnightGrove", 2, new Vector2(0,0), true, 0)},
				{"Midnight Grove Room 4", ("Build_86_2-1_MidnightGrove", 3, new Vector2(0,0), true, 0)},
				{"Briarbrush Woods Room 2", ("Build_86_2-2_Briar", 1, new Vector2(0,0), false, 0)},
				{"Briarbrush Woods Room 3", ("Build_86_2-2_Briar", 2, new Vector2(0,0), true, 0)},
				{"Briarbrush Woods Room 4", ("Build_86_2-2_Briar", 3, new Vector2(0,0), true, 0)},
				{"Various Explosives Room 2", ("Build_86_2-3_Explosives", 1, new Vector2(0,0), true, 0)},
				{"Various Explosives Room 3", ("Build_86_2-3_Explosives", 2, new Vector2(0,0), true, 0)},
				{"Together By Tether Room 2", ("Build_86_2-5_TogetherTether", 1, new Vector2(0,0), true, 0)},
				{"Together By Tether Room 3", ("Build_86_2-5_TogetherTether", 2, new Vector2(0,0), true, 0)},
				{"Together By Tether Room 4", ("Build_86_2-5_TogetherTether", 3, new Vector2(0,0), true, 0)},
				{"Pop Unlock Room 2", ("Build_86_2-4_KeyBubbles", 1, new Vector2(0,0), true, 0)},
				{"Pop Unlock Room 3", ("Build_86_2-4_KeyBubbles", 2, new Vector2(0,0), true, 0)},
				{"The Gatekeeper Room 2", ("Build_86_2-B_Gatekeeper", 1, new Vector2(0,0), true, 0)},
				{"The Gatekeeper Room 3", ("Build_86_2-B_Gatekeeper", 2, new Vector2(0,0), false, 0)},
				{"The Gatekeeper Room 4", ("Build_86_2-B_Gatekeeper", 3, new Vector2(0,0), true, 0)},
				{"The Gatekeeper Boss Arena", ("Build_86_2-B_Gatekeeper", 5, new Vector2(0,0), true, 0)},
				{"The Elevator Room 2", ("Build_86_2-7_Elavator", 1, new Vector2(0,0), true, 0)},
				{"The Elevator Room 3", ("Build_86_2-7_Elavator", 2, new Vector2(0,0), true, 0)},
				{"Frostbite Room 2", ("Build_86_2-6_Frostbite", 1, new Vector2(0,0), false, 0)},
				{"Frostbite Room 3", ("Build_86_2-6_Frostbite", 2, new Vector2(0,0), true, 0)},
				{"Frostbite Room 4", ("Build_86_2-6_Frostbite", 3, new Vector2(0,0), false, 0)},
				{"Forgotten Archives Room 2", ("Build_86_2-8_Niche", 1, new Vector2(0,0), true, 0)},
				{"Forgotten Archives Room 3", ("Build_86_2-8_Niche", 2, new Vector2(0,0), true, 0)},
				{"Forgotten Archives Room 4", ("Build_86_2-8_Niche", 3, new Vector2(0,0), true, 0)},
				{"Forgotten Archives Room 5", ("Build_86_2-8_Niche", 4, new Vector2(0,0), true, 0)},
				{"The Scenic Route Room 2", ("Build_86_2-Scenic", 1, new Vector2(0,0), true, 0)},
				{"The Scenic Route Room 3", ("Build_86_2-Scenic", 2, new Vector2(0,0), true, 0)},
				{"The Scenic Route Room 4", ("Build_86_2-Scenic", 3, new Vector2(0,0), true, 0)},
				{"The Scenic Route Room 5", ("Build_86_2-Scenic", 4, new Vector2(0,0), true, 0)},
				{"The Scenic Route Room 6", ("Build_86_2-Scenic", 5, new Vector2(0,0), true, 0)},
				{"The Scenic Route Room 7", ("Build_86_2-Scenic", 6, new Vector2(0,0), true, 0)},
				//World 3
				{"The Timeless Temple Room 2", ("Build_88_3A-1", 1, new Vector2(0,0), false, 0)},
				{"The Timeless Temple Room 3", ("Build_88_3A-1", 2, new Vector2(0,0), false, 0)},
				{"Haunted Halls Room 2", ("Build_88_3A-2", 1, new Vector2(0,0), false, 0)},
				{"Haunted Halls Room 3", ("Build_88_3A-2", 2, new Vector2(0,0), true, 0)},
				{"Haunted Halls Room 4", ("Build_88_3A-2", 3, new Vector2(0,0), false, 0)},
				{"Borrowed Time Room 2", ("Build_88_3B-1", 1, new Vector2(0,0), false, 0)},
				{"Borrowed Time Room 3", ("Build_88_3B-1", 2, new Vector2(0,0), true, 0)},
				{"Borrowed Time Room 4", ("Build_88_3B-1", 3, new Vector2(0,0), false, 0)},
				{"Nyctophobia Room 2", ("Build_88_3B-2_Nyctophobia", 1, new Vector2(0,0), false, 0)},
				{"Nyctophobia Room 3", ("Build_88_3B-2_Nyctophobia", 2, new Vector2(0,0), true, 0)},
				{"Nyctophobia Room 4", ("Build_88_3B-2_Nyctophobia", 3, new Vector2(0,0), true, 0)},
				{"Nyctophobia Room 5", ("Build_88_3B-2_Nyctophobia", 4, new Vector2(0,0), true, 0)},
				{"Shifting Walls Room 2", ("Build_88_3B-3", 1, new Vector2(0,0), true, 0)},
				{"Shifting Walls Room 3", ("Build_88_3B-3", 2, new Vector2(0,0), true, 0)},
				{"Shifting Walls Room 4", ("Build_88_3B-3", 3, new Vector2(0,0), true, 0)},
				{"Skullduggery Room 2", ("Build_88_3A-3", 1, new Vector2(0,0), false, 0)},
				{"Skullduggery Room 3", ("Build_88_3A-3", 2, new Vector2(0,0), true, 0)},
				{"Skullduggery Room 4", ("Build_88_3A-3", 4, new Vector2(0,0), true, 0)},
				{"Skullduggery Room 5", ("Build_88_3A-3", 3, new Vector2(0,0), true, 0)},
				{"The Throne Room Room 2", ("Build_88_3-Boss", 1, new Vector2(-4,-4), false, 0)},
				{"The Throne Room Room 3", ("Build_88_3-Boss", 3, new Vector2(0,0), true, 0)},
				{"The Throne Room Room 4A", ("Build_88_3-Boss", 4, new Vector2(0,0), true, 0)},
				{"The Throne Room Room 4B", ("Build_88_3-Boss", 5, new Vector2(0,0), true, 0)},
				{"The Throne Room Room 5", ("Build_88_3-Boss", 6, new Vector2(0,0), false, 0)},
				{"The Throne Room Room 6A", ("Build_88_3-Boss", 7, new Vector2(0,0), true, 0)},
				{"The Throne Room Room 6B", ("Build_88_3-Boss", 8, new Vector2(0,0), true, 0)},
				{"The Throne Room Room 7", ("Build_88_3-Boss", 9, new Vector2(0,0), true, 0)},
				{"The Throne Room Boss Arena", ("Build_88_3-Boss", 10, new Vector2(0,0), false, 0)},
				{"Pop To The Top Room 2", ("Build_88_3B-4 Pop", 1, new Vector2(0,0), true, 0)},
				{"Pop To The Top Room 3", ("Build_88_3B-4 Pop", 2, new Vector2(0,0), true, 0)},
				{"Periodic Prison Room 2", ("Build_88_3B-5 Dungeon", 1, new Vector2(0,0), true, 0)},
				{"Periodic Prison Room 3", ("Build_88_3B-5 Dungeon", 2, new Vector2(0,0), true, 0)},
				{"Periodic Prison Room 4", ("Build_88_3B-5 Dungeon", 3, new Vector2(0,0), true, 0)},
				//World 4
				{"Infinity Garden Room 2", ("Build_89_4-1", 1, new Vector2(0,0), true, 0)},
				{"Infinity Garden Room 3", ("Build_89_4-1", 2, new Vector2(0,0), true, 0)},
				{"Autumnal Aether Room 2", ("Build_90_4-2", 1, new Vector2(0,32), true, 0)},
				{"Autumnal Aether Room 3", ("Build_90_4-2", 3, new Vector2(0,0), true, 0)},
				{"Among The Stars Room 2", ("Build_90_4-3", 1, new Vector2(0,0), true, 0)},
				{"Among The Stars Room 3", ("Build_90_4-3", 2, new Vector2(0,0), true, 0)},
				{"Among The Stars Room 4", ("Build_90_4-3", 3, new Vector2(0,0), true, 0)},
				{"Den Of Pixies Room 2", ("Build_90_4-4", 1, new Vector2(0,0), false, 0)},
				{"Den Of Pixies Room 3", ("Build_90_4-4", 2, new Vector2(0,0), true, 0)},
				{"Den Of Pixies Room 4", ("Build_90_4-4", 3, new Vector2(0,0), false, 0)},
				{"Heels Over Head Room 2", ("Build_90_4-5", 1, new Vector2(0,0), false, 0)},
				{"Heels Over Head Room 3", ("Build_90_4-5", 2, new Vector2(0,0), false, 1)},
				{"Heels Over Head Room 4", ("Build_90_4-5", 3, new Vector2(0,0), true, 0)},
				{"The Hive Room 2", ("Build_90_4-6 Hive", 1, new Vector2(0,0), false, 0)},
				{"The Hive Room 3", ("Build_90_4-6 Hive", 2, new Vector2(0,0), false, 0)},
				{"The Hive Room 4", ("Build_90_4-6 Hive", 3, new Vector2(0,0), true, 0)},
				{"The Hive Room 5", ("Build_90_4-6 Hive", 4, new Vector2(0,0), true, 0)},
				{"The Hive Room 6", ("Build_90_4-6 Hive", 5, new Vector2(0,0), true, 0)},
				{"The Hive Room 7", ("Build_90_4-6 Hive", 6, new Vector2(0,0), true, 1)},
				{"The Five Mile Spire Room 2", ("Build_90_4-7 Spire", 1, new Vector2(0,0), false, 2)},
				{"The Five Mile Spire Room 3", ("Build_90_4-7 Spire", 2, new Vector2(0,0), true, 2)},
				{"The Five Mile Spire Room 4", ("Build_90_4-7 Spire", 3, new Vector2(0,0), true, 2)},
				{"The Five Mile Spire Room 5", ("Build_90_4-7 Spire", 4, new Vector2(0,0), true, 2)},
				{"The Five Mile Spire Room 6", ("Build_90_4-7 Spire", 5, new Vector2(0,0), true, 2)},
				{"The Five Mile Spire Room 7", ("Build_90_4-7 Spire", 6, new Vector2(0,0), true, 2)},
				{"The Five Mile Spire Room 7B", ("Build_90_4-7 Spire", 8, new Vector2(0,0), true, 2)},
				{"The Five Mile Spire Room 8", ("Build_90_4-7 Spire", 7, new Vector2(0,0), true, 0)},
				{"Gube Gardens Room 2", ("Build_90_4-8 GubeGardens", 1, new Vector2(0,0), true, 0)},
				{"Gube Gardens Room 3", ("Build_90_4-8 GubeGardens", 2, new Vector2(0,0), false, 0)},
				{"Gube Gardens Room 4", ("Build_90_4-8 GubeGardens", 3, new Vector2(0,0), false, 0)},
				{"Gube Gardens Room 5", ("Build_90_4-8 GubeGardens", 4, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 2", ("Build_90_4-Boss", 1, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 3", ("Build_90_4-Boss", 2, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 4", ("Build_90_4-Boss", 3, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 5", ("Build_90_4-Boss", 4, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 6", ("Build_90_4-Boss", 5, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 7", ("Build_90_4-Boss", 6, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 8", ("Build_90_4-Boss", 7, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 9", ("Build_90_4-Boss", 8, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 10", ("Build_90_4-Boss", 9, new Vector2(0,0), false, 0)},
				{"The Golf Fungus Room 11", ("Build_90_4-Boss", 11, new Vector2(0,0), false, 0)},
				{"Over The Woods Room 2", ("Build_90_4-Alt", 1, new Vector2(0,0), true, 0)},
				{"Over The Woods Room 3", ("Build_90_4-Alt", 2, new Vector2(0,0), false, 0)},
				//World 5
				{"Welcome To The Void Room 2", ("Build_91_5-1", 1, new Vector2(0,0), true, 0)},
				{"Welcome To The Void Room 3", ("Build_91_5-1", 2, new Vector2(0,0), true, 0)},
				{"Welcome To The Void Room 4", ("Build_91_5-1", 3, new Vector2(0,0), true, 0)},
				{"Welcome To The Void Room 5", ("Build_91_5-1", 4, new Vector2(0,0), true, 0)},
				{"The Sky Is Falling Room 2", ("Build_91_5-2", 1, new Vector2(0,0), true, 0)},
				{"The Sky Is Falling Room 3", ("Build_91_5-2", 2, new Vector2(0,0), true, 0)},
				{"The Sky Is Falling Room 4", ("Build_91_5-2", 3, new Vector2(0,0), true, 0)},
				{"The Sky Is Falling Room 5", ("Build_91_5-2", 4, new Vector2(0,0), true, 0)},
				{"The Looking Glass Room 2", ("Build_91_5-3", 1, new Vector2(0,0), false, 0)},
				{"The Looking Glass Room 3", ("Build_91_5-3", 2, new Vector2(0,0), true, 0)},
				{"The Looking Glass Room 4", ("Build_91_5-3", 3, new Vector2(0,0), true, 0)},
				{"The Looking Glass Room 5", ("Build_91_5-3", 4, new Vector2(0,0), true, 0)},
				{"Galactic Central Point Room 2", ("FinalBoss", 5, new Vector2(0,0), true, 0)},
				{"Galactic Central Point Room 3", ("FinalBoss", 6, new Vector2(0,0), true, 0)},
				{"Galactic Central Point Boss Arena", ("FinalBoss", 2, new Vector2(0,0), true, 0)},
				{"Home Room 2", ("Build_121_Home", 1, new Vector2(0,0), false, 0)},
				{"Home Room 3", ("Build_121_Home", 2, new Vector2(0,0), true, 0)},
				{"Home Room 4", ("Build_121_Home", 3, new Vector2(0,0), true, 0)},
				{"Home Room 5", ("Build_121_Home", 4, new Vector2(0,0), false, 0)},
				{"Home Room 6", ("Build_121_Home", 5, new Vector2(0,0), false, 0)},
			};

		public static void UpdateDoorRando()
		{
			string doorsRaw = Core.slotData["doors"].ToString();
			Queue<string> doorsRawSplit = new Queue<string>(doorsRaw.Split('\"'));

			doorMapping.Clear();
			while (doorsRawSplit.Count > 1)
			{
				doorsRawSplit.Dequeue();
				string doorEntrance = doorsRawSplit.Dequeue();
				doorsRawSplit.Dequeue();
				string doorExit = doorsRawSplit.Dequeue();

				if (doorMapping.ContainsKey(doorEntrance))
					doorMapping[doorEntrance].Add(doorExit);
				else
					doorMapping[doorEntrance] = new List<string>{ doorExit};
			}
		}
		#endregion Door Rando
	}
}
