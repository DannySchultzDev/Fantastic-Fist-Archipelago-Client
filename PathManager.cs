using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class PathManager
	{
		public static bool[] pathsUnlocked = new bool[50];
		
		private static Dictionary<WorldItem, int> pathToIndexDictionary = new Dictionary<WorldItem, int> 
		{
			{WorldItem.ONE_ONE_STANDARD_EXIT_PATH, 0 },
			{WorldItem.ONE_TWO_STANDARD_EXIT_PATH, 1 },
			{WorldItem.ONE_THREE_STANDARD_EXIT_PATH, 2 },
			{WorldItem.ONE_FOUR_STANDARD_EXIT_PATH, 3 },
			{WorldItem.ONE_FIVE_STANDARD_EXIT_PATH, 4 },
			{WorldItem.ONE_SIX_STANDARD_EXIT_PATH, 5 },
			{WorldItem.ONE_SEVEN_STANDARD_EXIT_PATH, 6 },
			{WorldItem.ONE_TWO_SECRET_EXIT_PATH, 7 },
			{WorldItem.ONE_A_STANDARD_EXIT_PATH, 8 },
			{WorldItem.ONE_B_STANDARD_EXIT_PATH, 9 },
			{WorldItem.ONE_FOUR_SECRET_EXIT_PATH, 10 },
			{WorldItem.ONE_C_STANDARD_EXIT_PATH, 11 },
			{WorldItem.ONE_EIGHT_BOSS_EXIT_PATH, 12 },
			{WorldItem.TWO_ONE_STANDARD_EXIT_PATH, 13 },
			{WorldItem.TWO_TWO_STANDARD_EXIT_PATH, 14 },
			{WorldItem.TWO_THREE_STANDARD_EXIT_PATH, 15 },
			{WorldItem.TWO_FOUR_STANDARD_EXIT_PATH, 16 },
			{WorldItem.TWO_FIVE_STANDARD_EXIT_PATH, 17 },
			{WorldItem.TWO_ONE_SECRET_EXIT_PATH, 18 },
			{WorldItem.TWO_A_STANDARD_EXIT_PATH, 19 },
			{WorldItem.TWO_B_STANDARD_EXIT_PATH, 20 },
			{WorldItem.TWO_C_STANDARD_EXIT_PATH, 21 },
			{WorldItem.TWO_C_SECRET_EXIT_PATH, 22 },
			{WorldItem.TWO_SIX_BOSS_EXIT_PATH, 23 },
			{WorldItem.THREE_ONE_STANDARD_EXIT_PATH, 24 },
			{WorldItem.THREE_TWO_STANDARD_EXIT_PATH, 25 },
			{WorldItem.THREE_THREE_STANDARD_EXIT_PATH, 26 },
			{WorldItem.THREE_FOUR_STANDARD_EXIT_PATH, 27 },
			{WorldItem.THREE_FIVE_STANDARD_EXIT_PATH, 28 },
			{WorldItem.THREE_SIX_STANDARD_EXIT_PATH, 29 },
			{WorldItem.THREE_SEVEN_BOSS_EXIT_PATH, 30 },
			{WorldItem.THREE_ONE_SECRET_EXIT_PATH, 31 },
			{WorldItem.THREE_A_STANDARD_EXIT_PATH, 32 },
			{WorldItem.THREE_B_STANDARD_EXIT_PATH, 33 },
			{WorldItem.TWO_D_STANDARD_EXIT_PATH, 34 },
			{WorldItem.FOUR_ONE_STANDARD_EXIT_PATH, 35 },
			{WorldItem.FOUR_TWO_STANDARD_EXIT_PATH, 36 },
			{WorldItem.FOUR_THREE_STANDARD_EXIT_PATH, 37 },
			{WorldItem.FOUR_FOUR_STANDARD_EXIT_PATH, 38 },
			{WorldItem.FOUR_FIVE_STANDARD_EXIT_PATH, 39 },
			{WorldItem.FOUR_SIX_STANDARD_EXIT_PATH, 40 },
			{WorldItem.FOUR_SEVEN_STANDARD_EXIT_PATH, 41 },
			{WorldItem.FOUR_EIGHT_STANDARD_EXIT_PATH, 42 },
			{WorldItem.FOUR_ONE_SECRET_EXIT_PATH, 43 },
			{WorldItem.FOUR_A_STANDARD_EXIT_PATH, 44 },
			{WorldItem.FOUR_NINE_BOSS_EXIT_PATH, 45 },
			{WorldItem.FIVE_ONE_STANDARD_EXIT_PATH, 46 },
			{WorldItem.FIVE_TWO_STANDARD_EXIT_PATH, 47 },
			{WorldItem.FIVE_THREE_STANDARD_EXIT_PATH, 48 },
			{WorldItem.ONE_ONE_HOME_EXIT_PATH, 49 },
		};
		private static List<WorldItem> standardPathItems = new List<WorldItem>()
		{
			WorldItem.ONE_ONE_STANDARD_EXIT_PATH,
			WorldItem.ONE_TWO_STANDARD_EXIT_PATH,
			WorldItem.ONE_THREE_STANDARD_EXIT_PATH,
			WorldItem.ONE_FOUR_STANDARD_EXIT_PATH,
			WorldItem.ONE_FIVE_STANDARD_EXIT_PATH,
			WorldItem.ONE_SIX_STANDARD_EXIT_PATH,
			WorldItem.ONE_SEVEN_STANDARD_EXIT_PATH,
			WorldItem.ONE_TWO_SECRET_EXIT_PATH,
			WorldItem.ONE_A_STANDARD_EXIT_PATH,
			WorldItem.ONE_B_STANDARD_EXIT_PATH,
			WorldItem.ONE_FOUR_SECRET_EXIT_PATH,
			WorldItem.ONE_C_STANDARD_EXIT_PATH,
			WorldItem.ONE_EIGHT_BOSS_EXIT_PATH,
			WorldItem.TWO_ONE_STANDARD_EXIT_PATH,
			WorldItem.TWO_TWO_STANDARD_EXIT_PATH,
			WorldItem.TWO_THREE_STANDARD_EXIT_PATH,
			WorldItem.TWO_FOUR_STANDARD_EXIT_PATH,
			WorldItem.TWO_FIVE_STANDARD_EXIT_PATH,
			WorldItem.TWO_ONE_SECRET_EXIT_PATH,
			WorldItem.TWO_A_STANDARD_EXIT_PATH,
			WorldItem.TWO_B_STANDARD_EXIT_PATH,
			WorldItem.TWO_C_STANDARD_EXIT_PATH,
			WorldItem.TWO_C_SECRET_EXIT_PATH,
			WorldItem.TWO_SIX_BOSS_EXIT_PATH,
			WorldItem.THREE_ONE_STANDARD_EXIT_PATH,
			WorldItem.THREE_TWO_STANDARD_EXIT_PATH,
			WorldItem.THREE_THREE_STANDARD_EXIT_PATH,
			WorldItem.THREE_FOUR_STANDARD_EXIT_PATH,
			WorldItem.THREE_FIVE_STANDARD_EXIT_PATH,
			WorldItem.THREE_SIX_STANDARD_EXIT_PATH,
			WorldItem.THREE_SEVEN_BOSS_EXIT_PATH,
			WorldItem.THREE_ONE_SECRET_EXIT_PATH,
			WorldItem.THREE_A_STANDARD_EXIT_PATH,
			WorldItem.THREE_B_STANDARD_EXIT_PATH,
			WorldItem.TWO_D_STANDARD_EXIT_PATH,
			WorldItem.FOUR_ONE_STANDARD_EXIT_PATH,
			WorldItem.FOUR_TWO_STANDARD_EXIT_PATH,
			WorldItem.FOUR_THREE_STANDARD_EXIT_PATH,
			WorldItem.FOUR_FOUR_STANDARD_EXIT_PATH,
			WorldItem.FOUR_FIVE_STANDARD_EXIT_PATH,
			WorldItem.FOUR_SIX_STANDARD_EXIT_PATH,
			WorldItem.FOUR_SEVEN_STANDARD_EXIT_PATH,
			WorldItem.FOUR_EIGHT_STANDARD_EXIT_PATH,
			WorldItem.FOUR_ONE_SECRET_EXIT_PATH,
			WorldItem.FOUR_A_STANDARD_EXIT_PATH,
			WorldItem.FOUR_NINE_BOSS_EXIT_PATH,
			WorldItem.FIVE_ONE_STANDARD_EXIT_PATH,
			WorldItem.FIVE_TWO_STANDARD_EXIT_PATH,
			WorldItem.FIVE_THREE_STANDARD_EXIT_PATH,
			WorldItem.ONE_ONE_HOME_EXIT_PATH,
		};

		public static bool goalIsHome = false;

		public static OpenWorldType openWorldType = OpenWorldType.CLOSED;

		public static void UpdatePathAccess()
		{
			pathsUnlocked = new bool[50];

			if (openWorldType == OpenWorldType.CLOSED)
			{
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_ONE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 1;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_TWO_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 2;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_THREE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 3;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_FOUR_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 4;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_FIVE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 5;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_SIX_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 6;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_SEVEN_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 7;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_EIGHT_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 8;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_ONE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 9;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_TWO_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 10;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_THREE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 11;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_FOUR_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 12;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_FIVE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 13;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_SIX_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 14;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_ONE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 15;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_TWO_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 16;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_THREE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 17;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_FOUR_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 18;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_FIVE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 19;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_SIX_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 20;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_SEVEN_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 21;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_ONE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 22;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_TWO_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 23;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_THREE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 24;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_FOUR_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 25;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_FIVE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 26;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_SIX_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 27;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_SEVEN_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 28;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_EIGHT_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 29;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_NINE_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 30;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FIVE_ONE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 31;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FIVE_TWO_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 32;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FIVE_THREE_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 33;
			}
			else if (openWorldType == OpenWorldType.PARTIAL || openWorldType == OpenWorldType.OPEN)
			{
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_EIGHT_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 1;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_SIX_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 2;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_SEVEN_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 3;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_NINE_BOSS_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_STANDARD_PATH] >= 4;
			}

			if (openWorldType == OpenWorldType.CLOSED || openWorldType == OpenWorldType.PARTIAL)
			{
				int goalIsHomeModifier = 0;
				if (!goalIsHome)
				{
					goalIsHomeModifier = 1;
					pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_ONE_HOME_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 1;
				}

				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_TWO_SECRET_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 1 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_A_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 2 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_B_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 3 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_FOUR_SECRET_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 4 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.ONE_C_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 5 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_ONE_SECRET_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 6 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_A_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 7 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_B_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 8 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_C_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 9 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_C_SECRET_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 10 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_D_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 11 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_ONE_SECRET_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 12 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_A_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 13 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.THREE_B_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 14 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_ONE_SECRET_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 15 + goalIsHomeModifier;
				pathsUnlocked[pathToIndexDictionary[WorldItem.FOUR_A_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 16 + goalIsHomeModifier;
			}
			else if (openWorldType == OpenWorldType.OPEN)
			{
				pathsUnlocked[pathToIndexDictionary[WorldItem.TWO_D_STANDARD_EXIT_PATH]] = ItemManager.worldItems[WorldItem.PROGRESSIVE_SECRET_PATH] >= 1;
			}


			foreach (WorldItem standardLevelPath in standardPathItems)
			{
				if (ItemManager.worldItems[standardLevelPath] >= 1)
					pathsUnlocked[pathToIndexDictionary[standardLevelPath]] = true;
			}


			for (int pathIndex = 0; pathIndex < pathsUnlocked.Length; ++pathIndex)
				Global.Dataholder.ListOfClearedExits[pathIndex] = pathsUnlocked[pathIndex];
			Global.Dataholder.EPH.RefreshLevelDots();
		}

		private static void RefreshMapVivi()
		{
			ViviMap mapVivi = Global.Dataholder.VVMap;

			if (mapVivi == null)
				return;

			if (mapVivi.CurrentLevel.LeftExit != -1)
			{
				if (Global.Dataholder.ListOfClearedExits[mapVivi.CurrentLevel.LeftExit])
				{
					mapVivi.LeftExit = mapVivi.CurrentLevel.LeftExit;
					mapVivi.LeftAlt = mapVivi.CurrentLevel.LeftAlt;
				}
				else
				{
					mapVivi.LeftExit = -1;
				}
			}
			else
			{
				mapVivi.LeftExit = -1;
			}

			if (mapVivi.CurrentLevel.RightExit != -1)
			{
				if (mapVivi.PseudoMap || Global.Dataholder.ListOfClearedExits[mapVivi.CurrentLevel.RightExit])
				{
					mapVivi.RightExit = mapVivi.CurrentLevel.RightExit;
					mapVivi.RightAlt = mapVivi.CurrentLevel.RightAlt;
				}
				else
				{
					mapVivi.RightExit = -1;
				}
			}
			else
			{
				mapVivi.RightExit = -1;
			}

			if (mapVivi.CurrentLevel.UpExit != -1)
			{
				if (Global.Dataholder.ListOfClearedExits[mapVivi.CurrentLevel.UpExit])
				{
					mapVivi.UpExit = mapVivi.CurrentLevel.UpExit;
					mapVivi.UpAlt = mapVivi.CurrentLevel.UpAlt;
				}
				else
				{
					mapVivi.UpExit = -1;
				}
			}
			else
			{
				mapVivi.UpExit = -1;
			}

			if (mapVivi.CurrentLevel.DownExit != -1)
			{
				if (Global.Dataholder.ListOfClearedExits[mapVivi.CurrentLevel.DownExit])
				{
					mapVivi.DownExit = mapVivi.CurrentLevel.DownExit;
					mapVivi.DownAlt = mapVivi.CurrentLevel.DownAlt;
				}
				else
				{
					mapVivi.DownExit = -1;
				}
			}
			else
			{
				mapVivi.DownExit = -1;
			}

			NewLevelPath component = mapVivi.CurrentLevel.GetComponent<NewLevelPath>();
			mapVivi.NoArrowRight = component.DontIndicateRight;
			mapVivi.NoArrowLeft = component.DontIndicateLeft;
			mapVivi.NoArrowDown = component.DontIndicateDown;
			mapVivi.NoArrowUp = component.DontIndicateUp;
		}
	}

	public enum OpenWorldType
	{
		CLOSED = 0,
		PARTIAL = 1,
		OPEN = 2,
		FULL = 3
	}
}
