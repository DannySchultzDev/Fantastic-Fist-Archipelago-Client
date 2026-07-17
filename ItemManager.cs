using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class ItemManager
	{
		public static Dictionary<ItemType, bool> itemUnlocks = new Dictionary<ItemType, bool>();

		public static Dictionary<WorldItem, int> worldItems = new Dictionary<WorldItem, int>();

		private static readonly Dictionary<WorldItem, (ItemType, int)[]> worldItemToItemType = new Dictionary<WorldItem, (ItemType, int)[]>
		{
			{WorldItem.DESTRUCTIBLE_BLOCKS, [(ItemType.SMASH_BLOCK, 1), (ItemType.BURNABLE_BLOCK, 1), (ItemType.SNAKE_BLOCK, 1)] },
			{WorldItem.PROGRESSIVE_DESTRUCTIBLE_BLOCKS, [(ItemType.SMASH_BLOCK, 1), (ItemType.BURNABLE_BLOCK, 2), (ItemType.SNAKE_BLOCK, 3)] },
			{WorldItem.SMASH_BLOCKS, [(ItemType.SMASH_BLOCK, 1)] },
			{WorldItem.BURNABLE_BLOCKS, [(ItemType.BURNABLE_BLOCK, 1)] },
			{WorldItem.SNAKE_BLOCKS, [(ItemType.SNAKE_BLOCK, 1)] },
			{WorldItem.PHYSICS_BLOCKS, [(ItemType.PHYSICS_BLOCK_STANDARD, 1), (ItemType.PHYSICS_BLOCK_ICE, 1), (ItemType.PHYSICS_BLOCK_HOLD, 1), (ItemType.PHYSICS_BLOCK_CONCRETE, 1), (ItemType.PHYSICS_BLOCK_ELECTRIC, 1), (ItemType.PHYSICS_BLOCK_LINE, 1)] },
			{WorldItem.PROGRESSIVE_PHYSICS_BLOCKS, [(ItemType.PHYSICS_BLOCK_STANDARD, 1), (ItemType.PHYSICS_BLOCK_ICE, 2), (ItemType.PHYSICS_BLOCK_HOLD, 3), (ItemType.PHYSICS_BLOCK_CONCRETE, 4), (ItemType.PHYSICS_BLOCK_ELECTRIC, 5), (ItemType.PHYSICS_BLOCK_LINE, 6)] },
			{WorldItem.STANDARD_PHYSICS_BLOCKS, [(ItemType.PHYSICS_BLOCK_STANDARD, 1)] },
			{WorldItem.ICE_BLOCKS, [(ItemType.PHYSICS_BLOCK_ICE, 1)] },
			{WorldItem.YELLOW_PHYSICS_BLOCKS, [(ItemType.PHYSICS_BLOCK_HOLD, 1)] },
			{WorldItem.CONCRETE_BLOCKS, [(ItemType.PHYSICS_BLOCK_CONCRETE, 1)] },
			{WorldItem.ELECTRIC_BLOCKS, [(ItemType.PHYSICS_BLOCK_ELECTRIC, 1)] },
			{WorldItem.LINE_BLOCKS, [(ItemType.PHYSICS_BLOCK_LINE, 1)] },
			{WorldItem.SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_STANDARD, 1), (ItemType.SLIDING_BLOCK_HOLD, 1), (ItemType.SLIDING_BLOCK_DELAY, 1), (ItemType.SLIDING_BLOCK_CRYSTAL, 1), (ItemType.SLIDING_BLOCK_GALACTIC, 1)] },
			{WorldItem.PROGRESSIVE_SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_STANDARD, 1), (ItemType.SLIDING_BLOCK_HOLD, 2), (ItemType.SLIDING_BLOCK_DELAY, 3), (ItemType.SLIDING_BLOCK_CRYSTAL, 4), (ItemType.SLIDING_BLOCK_GALACTIC, 5)] },
			{WorldItem.STANDARD_SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_STANDARD, 1)] },
			{WorldItem.YELLOW_SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_HOLD, 1)] },
			{WorldItem.BLUE_SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_DELAY, 1)] },
			{WorldItem.CRYSTAL_SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_CRYSTAL, 1)] },
			{WorldItem.GALACTIC_SLIDING_BLOCKS, [(ItemType.SLIDING_BLOCK_GALACTIC, 1)] },
			{WorldItem.BOSS_BLOCKS, [(ItemType.STAR_BLOCK_STANDARD, 1), (ItemType.STAR_BLOCK_HOLD, 1), (ItemType.STAR_BLOCK_DELAY, 1), (ItemType.HEART_BLOCK_STANDARD, 1), (ItemType.HEART_BLOCK_SLIDING, 1), (ItemType.HEART_BLOCK_DELAY, 1)] },
			{WorldItem.PROGRESSIVE_BOSS_BLOCKS, [(ItemType.STAR_BLOCK_STANDARD, 1), (ItemType.STAR_BLOCK_HOLD, 2), (ItemType.STAR_BLOCK_DELAY, 3), (ItemType.HEART_BLOCK_STANDARD, 4), (ItemType.HEART_BLOCK_SLIDING, 5), (ItemType.HEART_BLOCK_DELAY, 6)] },
			{WorldItem.STANDARD_STAR_BLOCKS, [(ItemType.STAR_BLOCK_STANDARD, 1)] },
			{WorldItem.YELLOW_STAR_BLOCKS, [(ItemType.STAR_BLOCK_HOLD, 1)] },
			{WorldItem.BLUE_STAR_BLOCKS, [(ItemType.STAR_BLOCK_DELAY, 1)] },
			{WorldItem.STANDARD_HEART_BLOCKS, [(ItemType.HEART_BLOCK_STANDARD, 1)] },
			{WorldItem.SLIDING_HEART_BLOCKS, [(ItemType.HEART_BLOCK_SLIDING, 1)] },
			{WorldItem.DELAYED_HEART_BLOCKS, [(ItemType.HEART_BLOCK_DELAY, 1)] },
			{WorldItem.POP_BLOCKS, [(ItemType.POP_BLOCK_STANDARD, 1), (ItemType.POP_BLOCK_GALACTIC, 1)] },
			{WorldItem.PROGRESSIVE_POP_BLOCKS, [(ItemType.POP_BLOCK_STANDARD, 1), (ItemType.POP_BLOCK_GALACTIC, 2)] },
			{WorldItem.STANDARD_POP_BLOCKS, [(ItemType.POP_BLOCK_STANDARD, 1)] },
			{WorldItem.GALACTIC_POP_BLOCKS, [(ItemType.POP_BLOCK_GALACTIC, 1)] },
			{WorldItem.BUMPERS, [(ItemType.BUMPER_STANDARD, 1), (ItemType.BUMPER_DIRECTIONAL, 1), (ItemType.BUMPER_HOLD, 1), (ItemType.BUMPER_BLACK_HOLE, 1)] },
			{WorldItem.PROGRESSIVE_BUMPERS, [(ItemType.BUMPER_STANDARD, 1), (ItemType.BUMPER_DIRECTIONAL, 2), (ItemType.BUMPER_HOLD, 3), (ItemType.BUMPER_BLACK_HOLE, 4)] },
			{WorldItem.STANDARD_BUMPERS, [(ItemType.BUMPER_STANDARD, 1)] },
			{WorldItem.DIRECTIONAL_BUMPERS, [(ItemType.BUMPER_DIRECTIONAL, 1)] },
			{WorldItem.YELLOW_BUMPERS, [(ItemType.BUMPER_HOLD, 1)] },
			{WorldItem.BLACK_HOLE_BUMPERS, [(ItemType.BUMPER_BLACK_HOLE, 1)] },
			{WorldItem.SWITCHES, [(ItemType.SWITCH_BLOCK_TIMED, 1), (ItemType.SWITCH_BLOCK_TOGGLE, 1)] },
			{WorldItem.PROGRESSIVE_SWITCHES, [(ItemType.SWITCH_BLOCK_TIMED, 1), (ItemType.SWITCH_BLOCK_TOGGLE, 2)] },
			{WorldItem.BLUE_SWITCHES, [(ItemType.SWITCH_BLOCK_TIMED, 1)] },
			{WorldItem.ORANGE_SWITCHES, [(ItemType.SWITCH_BLOCK_TOGGLE, 1)] },
			{WorldItem.PUNCHAPPEAR_BLOCKS, [(ItemType.PUNCHAPPEAR_BLOCK_STANDARD, 1), (ItemType.PUNCHAPPEAR_BLOCK_HOLD, 1), (ItemType.PUNCHAPPEAR_BLOCK_TIMED, 1), (ItemType.PUNCHAPPEAR_BLOCK_TOGGLE, 1)] },
			{WorldItem.PROGRESSIVE_PUNCHAPPEAR_BLOCKS, [(ItemType.PUNCHAPPEAR_BLOCK_STANDARD, 1), (ItemType.PUNCHAPPEAR_BLOCK_HOLD, 2), (ItemType.PUNCHAPPEAR_BLOCK_TIMED, 3), (ItemType.PUNCHAPPEAR_BLOCK_TOGGLE, 4)] },
			{WorldItem.STANDARD_PUNCHAPPEAR_BLOCKS, [(ItemType.PUNCHAPPEAR_BLOCK_STANDARD, 1)] },
			{WorldItem.YELLOW_PUNCHAPPEAR_BLOCKS, [(ItemType.PUNCHAPPEAR_BLOCK_HOLD, 1)] },
			{WorldItem.BLUE_PUNCHAPPEAR_BLOCKS, [(ItemType.PUNCHAPPEAR_BLOCK_TIMED, 1)] },
			{WorldItem.ORANGE_PUNCHAPPEAR_BLOCKS, [(ItemType.PUNCHAPPEAR_BLOCK_TOGGLE, 1)] },
			{WorldItem.SKULL_BLOCKS, [(ItemType.SKULL_BLOCK_HOLD, 1), (ItemType.SKULL_BLOCK_TIMED, 1), (ItemType.SKULL_BLOCK_TOGGLE, 1), (ItemType.SKULL_BLOCK_HOLD_DISABLE, 2), (ItemType.SKULL_BLOCK_TIMED_DISABLE, 2), (ItemType.SKULL_BLOCK_TOGGLE_DISABLE, 2)] },
			{WorldItem.PROGRESSIVE_SKULL_BLOCKS, [(ItemType.SKULL_BLOCK_HOLD, 1), (ItemType.SKULL_BLOCK_TIMED, 2), (ItemType.SKULL_BLOCK_TOGGLE, 3), (ItemType.SKULL_BLOCK_HOLD_DISABLE, 4), (ItemType.SKULL_BLOCK_TIMED_DISABLE, 4), (ItemType.SKULL_BLOCK_TOGGLE_DISABLE, 4)] },
			{WorldItem.YELLOW_SKULL_BLOCKS, [(ItemType.SKULL_BLOCK_HOLD, 1), (ItemType.SKULL_BLOCK_HOLD_DISABLE, 2)] },
			{WorldItem.BLUE_SKULL_BLOCKS, [(ItemType.SKULL_BLOCK_TIMED, 1), (ItemType.SKULL_BLOCK_TIMED_DISABLE, 2)] },
			{WorldItem.ORANGE_SKULL_BLOCKS, [(ItemType.SKULL_BLOCK_TOGGLE, 1), (ItemType.SKULL_BLOCK_TOGGLE_DISABLE, 2)] },
			{WorldItem.SKULL_RINGS, [(ItemType.SKULL_RING_HOLD, 1), (ItemType.SKULL_RING_TIMED, 1), (ItemType.SKULL_RING_HOLD_DISABLE, 2), (ItemType.SKULL_RING_TIMED_DISABLE, 2)] },
			{WorldItem.PROGRESSIVE_SKULL_RINGS, [(ItemType.SKULL_RING_HOLD, 1), (ItemType.SKULL_RING_TIMED, 2), (ItemType.SKULL_RING_HOLD_DISABLE, 3), (ItemType.SKULL_RING_TIMED_DISABLE, 3)] },
			{WorldItem.YELLOW_SKULL_RINGS, [(ItemType.SKULL_RING_HOLD, 1), (ItemType.SKULL_RING_HOLD_DISABLE, 2)] },
			{WorldItem.BLUE_SKULL_RINGS, [(ItemType.SKULL_RING_TIMED, 1), (ItemType.SKULL_RING_TIMED_DISABLE, 2)] },
			{WorldItem.ENEMIES, [(ItemType.GUBE, 1), (ItemType.GORB_HOLD, 1), (ItemType.GORB_DELAY, 1), (ItemType.PIXIE, 1), (ItemType.GUBE_DISABLE, 2), (ItemType.GORB_HOLD_DISABLE, 2), (ItemType.GORB_DELAY_DISABLE, 2), (ItemType.PIXIE_DISABLE, 2)] },
			{WorldItem.PROGRESSIVE_ENEMIES, [(ItemType.GUBE, 1), (ItemType.GORB_HOLD, 2), (ItemType.GORB_DELAY, 3), (ItemType.PIXIE, 4), (ItemType.GUBE_DISABLE, 5), (ItemType.GORB_HOLD_DISABLE, 5), (ItemType.GORB_DELAY_DISABLE, 5), (ItemType.PIXIE_DISABLE, 5)] },
			{WorldItem.GUBES, [(ItemType.GUBE, 1), (ItemType.GUBE_DISABLE, 2)] },
			{WorldItem.YELLOW_GORBS, [(ItemType.GORB_HOLD, 1), (ItemType.GORB_HOLD_DISABLE, 2)] },
			{WorldItem.BLUE_GORBS, [(ItemType.GORB_DELAY, 1), (ItemType.GORB_DELAY_DISABLE, 2)] },
			{WorldItem.PIXIES, [(ItemType.PIXIE, 1), (ItemType.PIXIE_DISABLE, 2)] },
			{WorldItem.VIVI_BLOCKS, [(ItemType.VIVI_BLOCK_STANDARD, 1), (ItemType.VIVI_BLOCK_HOLD, 1), (ItemType.VIVI_BLOCK_FIREWORK, 1)] },
			{WorldItem.PROGRESSIVE_VIVI_BLOCKS, [(ItemType.VIVI_BLOCK_STANDARD, 1), (ItemType.VIVI_BLOCK_HOLD, 2), (ItemType.VIVI_BLOCK_FIREWORK, 3)] },
			{WorldItem.STANDARD_VIVI_BLOCKS, [(ItemType.VIVI_BLOCK_STANDARD, 1)] },
			{WorldItem.YELLOW_VIVI_BLOCKS, [(ItemType.VIVI_BLOCK_HOLD, 1)] },
			{WorldItem.FIREWORK_VIVI_BLOCKS, [(ItemType.VIVI_BLOCK_FIREWORK, 1)] },
			{WorldItem.BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_STANDARD, 1), (ItemType.BLOCK_LAUNCHER_WING, 1), (ItemType.BLOCK_LAUNCHER_PEARL, 1), (ItemType.BLOCK_LAUNCHER_ICE, 1), (ItemType.BLOCK_LAUNCHER_HOLD, 1), (ItemType.BLOCK_LAUNCHER_DELAY, 1), (ItemType.BLOCK_LAUNCHER_INVERTED, 1), (ItemType.BLOCK_LAUNCHER_GALACTIC, 1), (ItemType.BLOCK_LAUNCHER_FIRE, 1)] },
			{WorldItem.PROGRESSIVE_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_STANDARD, 1), (ItemType.BLOCK_LAUNCHER_WING, 2), (ItemType.BLOCK_LAUNCHER_PEARL, 3), (ItemType.BLOCK_LAUNCHER_ICE, 4), (ItemType.BLOCK_LAUNCHER_HOLD, 5), (ItemType.BLOCK_LAUNCHER_DELAY, 6), (ItemType.BLOCK_LAUNCHER_INVERTED, 7), (ItemType.BLOCK_LAUNCHER_GALACTIC, 8), (ItemType.BLOCK_LAUNCHER_FIRE, 9)] },
			{WorldItem.STANDARD_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_STANDARD, 1)] },
			{WorldItem.WING_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_WING, 1)] },
			{WorldItem.PEARL_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_PEARL, 1)] },
			{WorldItem.ICE_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_ICE, 1)] },
			{WorldItem.YELLOW_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_HOLD, 1)] },
			{WorldItem.BLUE_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_DELAY, 1)] },
			{WorldItem.INVERTED_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_INVERTED, 1)] },
			{WorldItem.GALACTIC_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_GALACTIC, 1)] },
			{WorldItem.FIRE_BLOCK_LAUNCHERS, [(ItemType.BLOCK_LAUNCHER_FIRE, 1)] },
			{WorldItem.LAUNCHERS, [(ItemType.LAUNCHER_STANDARD, 1), (ItemType.LAUNCHER_PEARL_BLUE, 1), (ItemType.LAUNCHER_PEARL_RED, 1), (ItemType.LAUNCHER_CRYSTAL_HOLD, 1), (ItemType.LAUNCHER_CRYSTAL_TIMED, 1), (ItemType.LAUNCHER_MOON, 1)] },
			{WorldItem.PROGRESSIVE_LAUNCHERS, [(ItemType.LAUNCHER_STANDARD, 1), (ItemType.LAUNCHER_PEARL_BLUE, 2), (ItemType.LAUNCHER_PEARL_RED, 3), (ItemType.LAUNCHER_CRYSTAL_HOLD, 4), (ItemType.LAUNCHER_CRYSTAL_TIMED, 5), (ItemType.LAUNCHER_MOON, 6)] },
			{WorldItem.STANDARD_LAUNCHERS, [(ItemType.LAUNCHER_STANDARD, 1)] },
			{WorldItem.BLUE_PEARL_LAUNCHERS, [(ItemType.LAUNCHER_PEARL_BLUE, 1)] },
			{WorldItem.RED_PEARL_LAUNCHERS, [(ItemType.LAUNCHER_PEARL_RED, 1)] },
			{WorldItem.YELLOW_CRYSTAL_LAUNCHERS, [(ItemType.LAUNCHER_CRYSTAL_HOLD, 1)] },
			{WorldItem.BLUE_CRYSTAL_LAUNCHERS, [(ItemType.LAUNCHER_CRYSTAL_TIMED, 1)] },
			{WorldItem.MOON_LAUNCHERS, [(ItemType.LAUNCHER_MOON, 1)] },
			{WorldItem.HAZARDS, [(ItemType.SPINNER_STANDARD, 1), (ItemType.SPINNER_STAR, 1), (ItemType.FIRE_RING_RED, 1), (ItemType.FIRE_RING_BLUE, 1), (ItemType.SPINNER_STANDARD_DISABLE, 2), (ItemType.SPINNER_STAR_DISABLE, 2), (ItemType.FIRE_RING_RED_DISABLE, 2), (ItemType.FIRE_RING_BLUE_DISABLE, 2)] },
			{WorldItem.PROGRESSIVE_HAZARDS, [(ItemType.SPINNER_STANDARD, 1), (ItemType.SPINNER_STAR, 2), (ItemType.FIRE_RING_RED, 3), (ItemType.FIRE_RING_BLUE, 4), (ItemType.SPINNER_STANDARD_DISABLE, 5), (ItemType.SPINNER_STAR_DISABLE, 5), (ItemType.FIRE_RING_RED_DISABLE, 5), (ItemType.FIRE_RING_BLUE_DISABLE, 5)] },
			{WorldItem.STANDARD_SPINNERS, [(ItemType.SPINNER_STANDARD, 1), (ItemType.SPINNER_STANDARD_DISABLE, 2)] },
			{WorldItem.STAR_SPINNERS, [(ItemType.SPINNER_STAR, 1), (ItemType.SPINNER_STAR_DISABLE, 2)] },
			{WorldItem.RED_FIRE_RINGS, [(ItemType.FIRE_RING_RED, 1), (ItemType.FIRE_RING_RED_DISABLE, 2)] },
			{WorldItem.BLUE_FIRE_RINGS, [(ItemType.FIRE_RING_BLUE, 1), (ItemType.FIRE_RING_BLUE_DISABLE, 2)] },
			{WorldItem.BUBBLES, [(ItemType.BUBBLE_STATIONARY, 1), (ItemType.BUBBLE_KEY, 1), (ItemType.BUBBLE_NUMBER, 1), (ItemType.BUBBLE_CLEAR, 1), (ItemType.BUBBLE_HONEY, 1)] },
			{WorldItem.PROGRESSIVE_BUBBLES, [(ItemType.BUBBLE_STATIONARY, 1), (ItemType.BUBBLE_KEY, 2), (ItemType.BUBBLE_NUMBER, 3), (ItemType.BUBBLE_CLEAR, 4), (ItemType.BUBBLE_HONEY, 5)] },
			{WorldItem.GREEN_BUBBLES, [(ItemType.BUBBLE_STATIONARY, 1)] },
			{WorldItem.KEY_BUBBLES, [(ItemType.BUBBLE_KEY, 1)] },
			{WorldItem.NUMBER_BUBBLES, [(ItemType.BUBBLE_NUMBER, 1)] },
			{WorldItem.CLEAR_BUBBLES, [(ItemType.BUBBLE_CLEAR, 1)] },
			{WorldItem.HONEY_BUBBLES, [(ItemType.BUBBLE_HONEY, 1)] },
			{WorldItem.BALLOONS, [(ItemType.BALLOON_RED, 1), (ItemType.BALLOON_BLUE, 1), (ItemType.BALLOON_LEAD, 1), (ItemType.BALLOON_TOGGLE, 1)] },
			{WorldItem.PROGRESSIVE_BALLOONS, [(ItemType.BALLOON_RED, 1), (ItemType.BALLOON_BLUE, 2), (ItemType.BALLOON_LEAD, 3), (ItemType.BALLOON_TOGGLE, 4)] },
			{WorldItem.RED_BALLOONS, [(ItemType.BALLOON_RED, 1)] },
			{WorldItem.BLUE_BALLOONS, [(ItemType.BALLOON_BLUE, 1)] },
			{WorldItem.LEAD_BALLOONS, [(ItemType.BALLOON_LEAD, 1)] },
			{WorldItem.TOGGLE_BALLOONS, [(ItemType.BALLOON_TOGGLE, 1)] },
			{WorldItem.BOMBS, [(ItemType.BOMB_FLOWER, 1), (ItemType.BOMB_BLOCK, 1), (ItemType.BOMB_HIVE, 1)] },
			{WorldItem.PROGRESSIVE_BOMBS, [(ItemType.BOMB_FLOWER, 1), (ItemType.BOMB_BLOCK, 2), (ItemType.BOMB_HIVE, 3)] },
			{WorldItem.BOMB_FLOWERS, [(ItemType.BOMB_FLOWER, 1)] },
			{WorldItem.BOMB_BLOCKS, [(ItemType.BOMB_BLOCK, 1)] },
			{WorldItem.HIVE_BOMBS, [(ItemType.BOMB_HIVE, 1)] },
			{WorldItem.HIVE_BLOCKS, [(ItemType.HIVE_BLOCK_RED, 1), (ItemType.HIVE_BLOCK_BLUE, 1)] },
			{WorldItem.PROGRESSIVE_HIVE_BLOCKS, [(ItemType.HIVE_BLOCK_RED, 1), (ItemType.HIVE_BLOCK_BLUE, 2)] },
			{WorldItem.RED_HIVE_BLOCKS, [(ItemType.HIVE_BLOCK_RED, 1)] },
			{WorldItem.BLUE_HIVE_BLOCKS, [(ItemType.HIVE_BLOCK_BLUE, 1)] },
			{WorldItem.KEYS, [(ItemType.KEY_BLOCK_STANDARD, 1), (ItemType.KEY_QUARTET, 1), (ItemType.KEY_BLOCK_ICE, 1), (ItemType.KEY_BLOCK_INVERTED, 1)] },
			{WorldItem.PROGRESSIVE_KEYS, [(ItemType.KEY_BLOCK_STANDARD, 1), (ItemType.KEY_QUARTET, 2), (ItemType.KEY_BLOCK_ICE, 3), (ItemType.KEY_BLOCK_INVERTED, 4)] },
			{WorldItem.STANDARD_KEY_BLOCKS, [(ItemType.KEY_BLOCK_STANDARD, 1)] },
			{WorldItem.KEY_QUARTETS, [(ItemType.KEY_QUARTET, 1)] },
			{WorldItem.ICE_KEY_BLOCKS, [(ItemType.KEY_BLOCK_ICE, 1)] },
			{WorldItem.INVERTED_KEY_BLOCKS, [(ItemType.KEY_BLOCK_INVERTED, 1)] },
			{WorldItem.GRAVITY_ITEMS, [(ItemType.GRAVITY_FLIPPER_UP, 1), (ItemType.GRAVITY_FLIPPER_DOWN, 1), (ItemType.GRAVITY_FIELD_UP, 1), (ItemType.GRAVITY_FIELD_DOWN, 1), (ItemType.GRAVITY_WATER_UP, 1), (ItemType.GRAVITY_WATER_DOWN, 1), (ItemType.GRAVITY_FIST, 1), (ItemType.GRAVITY_ANCHOR, 1)] },
			{WorldItem.PROGRESSIVE_GRAVITY_ITEMS, [(ItemType.GRAVITY_FLIPPER_UP, 1), (ItemType.GRAVITY_FLIPPER_DOWN, 2), (ItemType.GRAVITY_FIELD_UP, 3), (ItemType.GRAVITY_FIELD_DOWN, 4), (ItemType.GRAVITY_WATER_UP, 5), (ItemType.GRAVITY_WATER_DOWN, 6), (ItemType.GRAVITY_FIST, 7), (ItemType.GRAVITY_ANCHOR, 8)] },
			{WorldItem.UP_GRAVITY_FLIPPERS, [(ItemType.GRAVITY_FLIPPER_UP, 1)] },
			{WorldItem.DOWN_GRAVITY_FLIPPERS, [(ItemType.GRAVITY_FLIPPER_DOWN, 1)] },
			{WorldItem.UP_GRAVITY_FIELDS, [(ItemType.GRAVITY_FIELD_UP, 1)] },
			{WorldItem.DOWN_GRAVITY_FIELDS, [(ItemType.GRAVITY_FIELD_DOWN, 1)] },
			{WorldItem.UP_WATER, [(ItemType.GRAVITY_WATER_UP, 1)] },
			{WorldItem.DOWN_WATER, [(ItemType.GRAVITY_WATER_DOWN, 1)] },
			{WorldItem.GRAVITY_FISTS, [(ItemType.GRAVITY_FIST, 1)] },
			{WorldItem.GRAVITY_ANCHORS, [(ItemType.GRAVITY_ANCHOR, 1)] },
			{WorldItem.LIFTS, [(ItemType.LIFT_ARROW, 1), (ItemType.LIFT_HOLD, 1), (ItemType.LIFT_HIVE, 1)] },
			{WorldItem.PROGRESSIVE_LIFTS, [(ItemType.LIFT_ARROW, 1), (ItemType.LIFT_HOLD, 2), (ItemType.LIFT_HIVE, 3)] },
			{WorldItem.ARROW_LIFTS, [(ItemType.LIFT_ARROW, 1)] },
			{WorldItem.YELLOW_LIFTS, [(ItemType.LIFT_HOLD, 1)] },
			{WorldItem.HIVE_LIFTS, [(ItemType.LIFT_HIVE, 1)] },
			{WorldItem.SEMISOLIDS, [(ItemType.SEMISOLID_STANDARD, 1), (ItemType.SEMISOLID_INVERTED, 1), (ItemType.SEMISOLID_TOGGLE, 1)] },
			{WorldItem.PROGRESSIVE_SEMISOLIDS, [(ItemType.SEMISOLID_STANDARD, 1), (ItemType.SEMISOLID_INVERTED, 2), (ItemType.SEMISOLID_TOGGLE, 3)] },
			{WorldItem.STANDARD_SEMISOLIDS, [(ItemType.SEMISOLID_STANDARD, 1)] },
			{WorldItem.INVERTED_SEMISOLIDS, [(ItemType.SEMISOLID_INVERTED, 1)] },
			{WorldItem.TOGGLE_SEMISOLIDS, [(ItemType.SEMISOLID_TOGGLE, 1)] },
			{WorldItem.ON_OFF_BLOCKS, [(ItemType.ON_OFF_BLOCK, 1)] },
			{WorldItem.TIMER_BUTTONS, [(ItemType.TIMER_BUTTON, 1)] },
			{WorldItem.TOGGLE_FLOWERS, [(ItemType.TOGGLE_FLOWER, 1)] },
			{WorldItem.TETHERS, [(ItemType.TETHER, 1)] },
			{WorldItem.ICICLES, [(ItemType.ICICLE, 1)] },
			{WorldItem.GLASS_BLOCKS, [(ItemType.GLASS_BLOCK, 1)] },
			{WorldItem.VIVIS_FLASHLIGHT, [(ItemType.FLASHLIGHT, 1)] },
			{WorldItem.THERMALS, [(ItemType.THERMAL, 1)] },
			{WorldItem.GOLF_BALL, [(ItemType.GOLF_BALL, 1)] },
			{WorldItem.GOLF_CART, [(ItemType.GOLF_CART, 1)] },
			{WorldItem.FALLING_CRYSTALS, [(ItemType.FALLING_CRYSTAL, 1)] },
			{WorldItem.GRAB_BLOCKS, [(ItemType.GRAB_BLOCK, 1)] },
			{WorldItem.MIRRORS, [(ItemType.MIRROR, 1)] },
			{WorldItem.BARRELS, [(ItemType.BARREL, 1)] },
			{WorldItem.PILLARS, [(ItemType.PILLAR, 1)] },
			{WorldItem.YELLOW_SPIN_BLOCKS, [(ItemType.SPIN_HOLD_BLOCK, 1)] },
			{WorldItem.TREES, [(ItemType.TREE, 1)] }
		};

		public static void InitializeItems()
		{
			foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
			{
				itemUnlocks[itemType] = false;
			}

			foreach (WorldItem worldItem in Enum.GetValues(typeof(WorldItem)))
			{
				worldItems[worldItem] = 0;
			}
		}

		public static void ReceivedWorldItem(WorldItem worldItem)
		{
			++worldItems[worldItem];

			if ((int)worldItem < 260)
			{
				foreach ((ItemType, int) itemType in worldItemToItemType[worldItem])
				{
					if (worldItems[worldItem] >= itemType.Item2)
					{
						itemUnlocks[itemType.Item1] = true;
					}
				}
			}
			else if ((int)worldItem == 260)
			{
				//TODO add coin logic
			}
			else if ((int)worldItem < 400)
			{
				PathManager.UpdatePathAccess();
			}

		}
	}


	public enum WorldItem
    {
		DESTRUCTIBLE_BLOCKS = 1,
		PROGRESSIVE_DESTRUCTIBLE_BLOCKS = 2,
		SMASH_BLOCKS = 3,
		BURNABLE_BLOCKS = 4,
		SNAKE_BLOCKS = 5,

		PHYSICS_BLOCKS = 10,
		PROGRESSIVE_PHYSICS_BLOCKS = 11,
		STANDARD_PHYSICS_BLOCKS = 12,
		ICE_BLOCKS = 13,
		YELLOW_PHYSICS_BLOCKS = 14,
		CONCRETE_BLOCKS = 15,
		ELECTRIC_BLOCKS = 16,
		LINE_BLOCKS = 17,

		SLIDING_BLOCKS = 20,
		PROGRESSIVE_SLIDING_BLOCKS = 21,
		STANDARD_SLIDING_BLOCKS = 22,
		YELLOW_SLIDING_BLOCKS = 23,
		BLUE_SLIDING_BLOCKS = 24,
		CRYSTAL_SLIDING_BLOCKS = 25,
		GALACTIC_SLIDING_BLOCKS = 26,

		BOSS_BLOCKS = 30,
		PROGRESSIVE_BOSS_BLOCKS = 31,
		STANDARD_STAR_BLOCKS = 32,
		YELLOW_STAR_BLOCKS = 33,
		BLUE_STAR_BLOCKS = 34,
		STANDARD_HEART_BLOCKS = 35,
		SLIDING_HEART_BLOCKS = 36,
		DELAYED_HEART_BLOCKS = 37,

		POP_BLOCKS = 40,
		PROGRESSIVE_POP_BLOCKS = 41,
		STANDARD_POP_BLOCKS = 42,
		GALACTIC_POP_BLOCKS = 43,

		BUMPERS = 50,
		PROGRESSIVE_BUMPERS = 51,
		STANDARD_BUMPERS = 52,
		DIRECTIONAL_BUMPERS = 53,
		YELLOW_BUMPERS = 54,
		BLACK_HOLE_BUMPERS = 55,

		SWITCHES = 60,
		PROGRESSIVE_SWITCHES = 61,
		BLUE_SWITCHES = 62,
		ORANGE_SWITCHES = 63,

		PUNCHAPPEAR_BLOCKS = 70,
		PROGRESSIVE_PUNCHAPPEAR_BLOCKS = 71,
		STANDARD_PUNCHAPPEAR_BLOCKS = 72,
		YELLOW_PUNCHAPPEAR_BLOCKS = 73,
		BLUE_PUNCHAPPEAR_BLOCKS = 74,
		ORANGE_PUNCHAPPEAR_BLOCKS = 75,

		SKULL_BLOCKS = 80,
		PROGRESSIVE_SKULL_BLOCKS = 81,
		YELLOW_SKULL_BLOCKS = 82,
		BLUE_SKULL_BLOCKS = 83,
		ORANGE_SKULL_BLOCKS = 84,

		SKULL_RINGS = 90,
		PROGRESSIVE_SKULL_RINGS = 91,
		YELLOW_SKULL_RINGS = 92,
		BLUE_SKULL_RINGS = 93,

		ENEMIES = 100,
		PROGRESSIVE_ENEMIES = 101,
		GUBES = 102,
		YELLOW_GORBS = 103,
		BLUE_GORBS = 104,
		PIXIES = 105,

		VIVI_BLOCKS = 110,
		PROGRESSIVE_VIVI_BLOCKS = 111,
		STANDARD_VIVI_BLOCKS = 112,
		YELLOW_VIVI_BLOCKS = 113,
		FIREWORK_VIVI_BLOCKS = 114,

		BLOCK_LAUNCHERS = 120,
		PROGRESSIVE_BLOCK_LAUNCHERS = 121,
		STANDARD_BLOCK_LAUNCHERS = 122,
		WING_BLOCK_LAUNCHERS = 123,
		PEARL_BLOCK_LAUNCHERS = 124,
		ICE_BLOCK_LAUNCHERS = 125,
		YELLOW_BLOCK_LAUNCHERS = 126,
		BLUE_BLOCK_LAUNCHERS = 127,
		INVERTED_BLOCK_LAUNCHERS = 128,
		GALACTIC_BLOCK_LAUNCHERS = 129,
		FIRE_BLOCK_LAUNCHERS = 130,

		LAUNCHERS = 140,
		PROGRESSIVE_LAUNCHERS = 141,
		STANDARD_LAUNCHERS = 142,
		BLUE_PEARL_LAUNCHERS = 143,
		RED_PEARL_LAUNCHERS = 144,
		YELLOW_CRYSTAL_LAUNCHERS = 145,
		BLUE_CRYSTAL_LAUNCHERS = 146,
		MOON_LAUNCHERS = 147,

		HAZARDS = 150,
		PROGRESSIVE_HAZARDS = 151,
		STANDARD_SPINNERS = 152,
		STAR_SPINNERS = 153,
		RED_FIRE_RINGS = 154,
		BLUE_FIRE_RINGS = 155,

		BUBBLES = 160,
		PROGRESSIVE_BUBBLES = 161,
		GREEN_BUBBLES = 162,
		KEY_BUBBLES = 163,
		NUMBER_BUBBLES = 164,
		CLEAR_BUBBLES = 165,
		HONEY_BUBBLES = 166,

		BALLOONS = 170,
		PROGRESSIVE_BALLOONS = 171,
		RED_BALLOONS = 172,
		BLUE_BALLOONS = 173,
		LEAD_BALLOONS = 174,
		TOGGLE_BALLOONS = 175,

		BOMBS = 180,
		PROGRESSIVE_BOMBS = 181,
		BOMB_FLOWERS = 182,
		BOMB_BLOCKS = 183,
		HIVE_BOMBS = 184,

		HIVE_BLOCKS = 190,
		PROGRESSIVE_HIVE_BLOCKS = 191,
		BLUE_HIVE_BLOCKS = 192,
		RED_HIVE_BLOCKS = 193,

		KEYS = 200,
		PROGRESSIVE_KEYS = 201,
		STANDARD_KEY_BLOCKS = 202,
		KEY_QUARTETS = 203,
		ICE_KEY_BLOCKS = 204,
		INVERTED_KEY_BLOCKS = 205,

		GRAVITY_ITEMS = 210,
		PROGRESSIVE_GRAVITY_ITEMS = 211,
		UP_GRAVITY_FLIPPERS = 212,
		DOWN_GRAVITY_FLIPPERS = 213,
		UP_GRAVITY_FIELDS = 214,
		DOWN_GRAVITY_FIELDS = 215,
		UP_WATER = 216,
		DOWN_WATER = 217,
		GRAVITY_FISTS = 218,
		GRAVITY_ANCHORS = 219,

		LIFTS = 220,
		PROGRESSIVE_LIFTS = 221,
		ARROW_LIFTS = 222,
		YELLOW_LIFTS = 223,
		HIVE_LIFTS = 224,

		SEMISOLIDS = 230,
		PROGRESSIVE_SEMISOLIDS = 231,
		STANDARD_SEMISOLIDS = 232,
		INVERTED_SEMISOLIDS = 233,
		TOGGLE_SEMISOLIDS = 234,

		ON_OFF_BLOCKS = 240,
		TIMER_BUTTONS = 241,
		TOGGLE_FLOWERS = 242,
		TETHERS = 243,
		ICICLES = 244,
		GLASS_BLOCKS = 245,
		VIVIS_FLASHLIGHT = 246,

		THERMALS = 247,
		GOLF_BALL = 248,
		GOLF_CART = 249,
		FALLING_CRYSTALS = 250,
		GRAB_BLOCKS = 251,
		MIRRORS = 252,
		BARRELS = 253,
		PILLARS = 254,
		YELLOW_SPIN_BLOCKS = 255,
		TREES = 256,

		COIN = 260,

		PROGRESSIVE_STANDARD_PATH = 300,
		PROGRESSIVE_SECRET_PATH = 301,

        ONE_ONE_STANDARD_EXIT_PATH = 310,
        ONE_TWO_STANDARD_EXIT_PATH = 311,
        ONE_THREE_STANDARD_EXIT_PATH = 312,
        ONE_FOUR_STANDARD_EXIT_PATH = 313,
        ONE_FIVE_STANDARD_EXIT_PATH = 314,
        ONE_SIX_STANDARD_EXIT_PATH = 315,
        ONE_SEVEN_STANDARD_EXIT_PATH = 316,
        TWO_ONE_STANDARD_EXIT_PATH = 317,
        TWO_TWO_STANDARD_EXIT_PATH = 318,
        TWO_THREE_STANDARD_EXIT_PATH = 319,
        TWO_FOUR_STANDARD_EXIT_PATH = 320,
        TWO_FIVE_STANDARD_EXIT_PATH = 321,
        THREE_ONE_STANDARD_EXIT_PATH = 322,
        THREE_TWO_STANDARD_EXIT_PATH = 323,
        THREE_THREE_STANDARD_EXIT_PATH = 324,
        THREE_FOUR_STANDARD_EXIT_PATH = 325,
        THREE_FIVE_STANDARD_EXIT_PATH = 326,
        THREE_SIX_STANDARD_EXIT_PATH = 327,
        FOUR_ONE_STANDARD_EXIT_PATH = 328,
        FOUR_TWO_STANDARD_EXIT_PATH = 329,
        FOUR_THREE_STANDARD_EXIT_PATH = 330,
        FOUR_FOUR_STANDARD_EXIT_PATH = 331,
        FOUR_FIVE_STANDARD_EXIT_PATH = 332,
        FOUR_SIX_STANDARD_EXIT_PATH = 333,
        FOUR_SEVEN_STANDARD_EXIT_PATH = 334,
        FOUR_EIGHT_STANDARD_EXIT_PATH = 335,
        FIVE_ONE_STANDARD_EXIT_PATH = 336,
        FIVE_TWO_STANDARD_EXIT_PATH = 337,
        FIVE_THREE_STANDARD_EXIT_PATH = 338,
    
        ONE_TWO_SECRET_EXIT_PATH = 340,
        ONE_FOUR_SECRET_EXIT_PATH = 341,
        TWO_ONE_SECRET_EXIT_PATH = 342,
        TWO_C_SECRET_EXIT_PATH = 343,
        THREE_ONE_SECRET_EXIT_PATH = 344,
        FOUR_ONE_SECRET_EXIT_PATH = 345,
    
        ONE_A_STANDARD_EXIT_PATH = 346,
        ONE_B_STANDARD_EXIT_PATH = 347,
        ONE_C_STANDARD_EXIT_PATH = 348,
        TWO_A_STANDARD_EXIT_PATH = 349,
        TWO_B_STANDARD_EXIT_PATH = 350,
        TWO_C_STANDARD_EXIT_PATH = 351,
        THREE_A_STANDARD_EXIT_PATH = 352,
        THREE_B_STANDARD_EXIT_PATH = 353,
        FOUR_A_STANDARD_EXIT_PATH = 354,
    
        ONE_EIGHT_BOSS_EXIT_PATH = 360,
        TWO_SIX_BOSS_EXIT_PATH = 361,
        THREE_SEVEN_BOSS_EXIT_PATH = 362,
        FOUR_NINE_BOSS_EXIT_PATH = 363,
    
        TWO_D_STANDARD_EXIT_PATH = 364,
    
        ONE_ONE_HOME_EXIT_PATH = 370,

		NOTHING = 400
	}

	public enum ItemType
	{
		//Core Items
		//Destructible Blocks
		SMASH_BLOCK,					//SmashBlock, SmashBlock_Block, SmashBlock_Block 1, SmashBlock_W4_W, SmashBlock_W4_H
		BURNABLE_BLOCK,					//W2Boss_RopePlatform, W2Boss_Vinewall
		SNAKE_BLOCK,                    //Ice_bomb_Trigger
		//Physics Blocks
		PHYSICS_BLOCK_STANDARD,         //NewPhysBlock, NewPhysBlock_Big, W2Tether, W41x1, W41x1H
		PHYSICS_BLOCK_ICE,              //NewIce, NewIce_Small
		PHYSICS_BLOCK_HOLD,             //LockBlock, LockBlock_Big
		PHYSICS_BLOCK_CONCRETE,         //NoPunch, NoPunch_Big
		PHYSICS_BLOCK_ELECTRIC,         //W5Box_8, W5Box_16, W5Box_32, W5Box_64, W5Box_128, W5Box_256
		PHYSICS_BLOCK_LINE,             //Scrapped_AxisBlock
		//Evolving Items
		//Sliding Blocks
		SLIDING_BLOCK_STANDARD,         //World1_Slider
		SLIDING_BLOCK_HOLD,             //W3A_BigLockBox
		SLIDING_BLOCK_DELAY,            //W3B_BigBox
		SLIDING_BLOCK_CRYSTAL,          //Final_BigBox
		SLIDING_BLOCK_GALACTIC,         //FinaleSlider
		//Boss Blocks
		STAR_BLOCK_STANDARD,            //Starblock, Starblock_W2, Boss3Starblock
		STAR_BLOCK_HOLD,                //Boss3Starblock_Lock
		STAR_BLOCK_DELAY,               //Boss3_IceStar
		HEART_BLOCK_STANDARD,           //Boss3Heartblock_N
		HEART_BLOCK_SLIDING,            //Boss3_HeartFaceNeutral, Boss3_HeartFaceA
		HEART_BLOCK_DELAY,              //Boss3_HeartFaceB
		//Pop Blocks
		POP_BLOCK_STANDARD,             //W3B_Pop
		POP_BLOCK_GALACTIC,             //Finale_Pop
		//Bumpers
		BUMPER_STANDARD,                //Bumper
		BUMPER_DIRECTIONAL,             //W2Bumper
		BUMPER_HOLD,                    //LockBumperBoom
		BUMPER_BLACK_HOLE,              //BlackHoleBumper
		//Switch Blocks
		SWITCH_BLOCK_TIMED,             //W3B_Punchable
		SWITCH_BLOCK_TOGGLE,            //W3A_Punchable
		//Punchappear Blocks
		PUNCHAPPEAR_BLOCK_STANDARD,     //Punchappear_1x2, Punchappear_1x4, Punchappear_2x1, Punchappear_2x2, Punchappear_4x1
		PUNCHAPPEAR_BLOCK_HOLD,         //Punchappear_W3, FinalBoss_49_W3ABlock
		PUNCHAPPEAR_BLOCK_TIMED,        //W3B_Punchappear_B2
		PUNCHAPPEAR_BLOCK_TOGGLE,       //W3A2_Punchappear
		//Skull Blocks
		SKULL_BLOCK_HOLD,               //SkullBox, SkullBox_R, FinalBoss_49_W3ASkull
		SKULL_BLOCK_TIMED,              //SkullBox_W3B, SkullBox_W3B 1
		SKULL_BLOCK_TOGGLE,             //SkullBox_W3A2
		SKULL_BLOCK_HOLD_DISABLE,       //SkullBox, SkullBox_R, FinalBoss_49_W3ASkull
		SKULL_BLOCK_TIMED_DISABLE,      //SkullBox_W3B, SkullBox_W3B 1
		SKULL_BLOCK_TOGGLE_DISABLE,		//SkullBox_W3A2
		//Skull Rings
		SKULL_RING_HOLD,                //MagicSkull, LoneSkullGen
		SKULL_RING_TIMED,               //MagicSkull_3B
		SKULL_RING_HOLD_DISABLE,        //MagicSkull, LoneSkullGen
		SKULL_RING_TIMED_DISABLE,       //MagicSkull_3B
		//Enemies
		GUBE,                           //W1Gube, W41x1, Gobe
		GORB_HOLD,                      //FinalGhost
		GORB_DELAY,                     //FinalGhost_B
		PIXIE,                          //Pixie
		GUBE_DISABLE,                   //W1Gube, W41x1, Gobe
		GORB_HOLD_DISABLE,              //FinalGhost
		GORB_DELAY_DISABLE,             //FinalGhost_B
		PIXIE_DISABLE,                  //Pixie
		//Vivi Blocks
		VIVI_BLOCK_STANDARD,            //ViviPunchBlock
		VIVI_BLOCK_HOLD,                //ViviPunchBlock_W3A
		VIVI_BLOCK_FIREWORK,            //Starwork_Gem
		//Block Launchers
		BLOCK_LAUNCHER_STANDARD,        //Pow, PowSpike, Pow4, W5_Pow, W5_Pow_Chunky, W5_Pow_Big, W5_Pow_Beeg, FinalBoss_49_PowBlockBase
		BLOCK_LAUNCHER_WING,            //PowWinged
		BLOCK_LAUNCHER_PEARL,			//Pow_W2, Pow_W2_Spiked, Pow_W2_HL, Pow_W2_HR
		BLOCK_LAUNCHER_ICE,             //Pow_Ice
		BLOCK_LAUNCHER_HOLD,            //LockPow
		BLOCK_LAUNCHER_DELAY,           //IceLockPow
		BLOCK_LAUNCHER_INVERTED,        //Pow4H
		BLOCK_LAUNCHER_GALACTIC,        //Pow_FinalPreBoss, Pow_FinalPreBossSmasher
		BLOCK_LAUNCHER_FIRE,            //Scrapped_FirePow
		//Player Launchers
		LAUNCHER_STANDARD,              //JetblockLeft, JetblockRight
		LAUNCHER_PEARL_BLUE,			//W2Pearl
		LAUNCHER_PEARL_RED,				//W2PearlPlayer
		LAUNCHER_CRYSTAL_HOLD,          //ArrowLight
		LAUNCHER_CRYSTAL_TIMED,         //ArrowLight_W3B
		LAUNCHER_MOON,                  //W4_Moon
		//Generic Items
		//Hazards
		SPINNER_STANDARD,               //Waterball1
		SPINNER_STAR,                   //WaterballBossAttack
		FIRE_RING_RED,                  //W2PearlFire
		FIRE_RING_BLUE,                 //W2PearlFireBlue
		SPINNER_STANDARD_DISABLE,		//Waterball1
		SPINNER_STAR_DISABLE,           //WaterballBossAttack, PreBossPipe
		FIRE_RING_RED_DISABLE,          //W2PearlFire
		FIRE_RING_BLUE_DISABLE,         //W2PearlFireBlue
		//Bubbles
		BUBBLE_STATIONARY,              //Bubble
		BUBBLE_KEY,                     //Bubble_Key
		BUBBLE_NUMBER,                  //PreBoss_Pillar, StarBubble
		BUBBLE_CLEAR,                   //W3BBubble, Bubble
		BUBBLE_HONEY,                   //HoneyBubble, Col_Icecube
		//Balloons
		BALLOON_RED,                    //Balloon
		BALLOON_BLUE,                   //Balloon_Impulse
		BALLOON_LEAD,                  //LeadBalloon, LeadBalloon_Frostbite
		BALLOON_TOGGLE,                 //LeadBalloonCell, LeadBalloonCell_Frostbite
		//Bombs
		BOMB_FLOWER,                    //BombFruitFruitBomb
		BOMB_BLOCK,                     //SurpriseBombGen
		BOMB_HIVE,                      //HiveBomb
		//Hive Blocks
		HIVE_BLOCK_BLUE,                //Hive_Bombable
		HIVE_BLOCK_RED,                 //Hive_Bombable, Hive_Bombable 1
		//Keys
		KEY_BLOCK_STANDARD,             //KeyBlock
		KEY_QUARTET,                    //Archive_KeyButton, Library_ToggleBox_Niche 1
		KEY_BLOCK_ICE,                  //NewIceKey
		KEY_BLOCK_INVERTED,             //SpireGravityKey
		//Gravity Items
		GRAVITY_FLIPPER_UP,             //HoneyOrb
		GRAVITY_FLIPPER_DOWN,           //WaterOrb
		GRAVITY_FIELD_UP,               //Quatrafoil_Alt
		GRAVITY_FIELD_DOWN,				//Quatrafoil
		GRAVITY_WATER_UP,               //Reflection Honey_Infinite
		GRAVITY_WATER_DOWN,             //Reflection_Infinite
		GRAVITY_FIST,                   //SplitScreen_Tool
		GRAVITY_ANCHOR,					//SpireGravityAnchor
		//Lifts
		LIFT_ARROW,						//W2Slider_Take2
		LIFT_HOLD,						//Girder
		LIFT_HIVE,						//CarryPlat
		//Semisolids
		SEMISOLID_STANDARD,				//Mod_PropBlock_Blue
		SEMISOLID_INVERTED,				//Mod_PropBlock_Pink
		SEMISOLID_TOGGLE,               //Mod_PropBlock_Punch
		//Specific Items
		//World 1
		ON_OFF_BLOCK,                   //PunchToggle_1x2, PunchToggle_2x1, PunchToggle_2x2, Punchappear_2x1, Punchappear_2x2, FinalBoss_49_W3ABlock
		TIMER_BUTTON,                   //W3B_Punchappear_B2, Lib_TimerButton, PaeButton_1, Library_ToggleBox_Niche
		//World 2
		TOGGLE_FLOWER,                  //PunchFlower, PunchFlower_P
		TETHER,                         //W2Tether, W41x1
		ICICLE,                         //Icicle_New
		//World 3
		GLASS_BLOCK,                    //W3B_Punchappear_H, W3B_Punchappear_B
		FLASHLIGHT,                     //NewDarkness
		//World 4
		THERMAL,                        //Whirl
		GOLF_BALL,                      //W41x1
		GOLF_CART,                      //Player
		//World 5
		FALLING_CRYSTAL,                //GemArrayHazard
		GRAB_BLOCK,                     //Final_BigBox 1
		MIRROR,                         //W5Mirror
		//Finale
		BARREL,                         //Barrel, Barrel_, Lib_TimerButton
		PILLAR,                         //PushBricks, UsDPushBricks
		SPIN_HOLD_BLOCK,                //RotateBox
		TREE                            //RotatingPillarM
	}
}
