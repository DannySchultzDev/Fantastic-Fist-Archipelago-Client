using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class ItemManager
	{
		public static Dictionary<ItemType, bool> itemUnlocks = new Dictionary<ItemType, bool>();
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
