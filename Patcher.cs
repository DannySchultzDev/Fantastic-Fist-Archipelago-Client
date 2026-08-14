using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using HarmonyLib;
using JetBrains.Annotations;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.TimeZoneInfo;
using static MelonLoader.MelonLogger;

namespace Fantastic_Fist_Archipelago_Client
{
	//Test message statement:
	//Melon<Core>.Logger.Msg("TEST MESSAGE");

	#region Items

	[HarmonyPatch(typeof(SmashBlockMain), "OnTriggerEnter")]
	public static class SmashBlockPatch
	{
		private static bool Prefix(SmashBlockMain __instance)
		{
			if (ItemManager.itemUnlocks[ItemType.SMASH_BLOCK])
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

	[HarmonyPatch(typeof(W2Boss_RopeBridge), "OnTriggerStay")]
	public static class RopeBridgePatch
	{
		private static bool Prefix(Collider other)
		{
			if (other.tag == "Killzone" && other.name != "---")
				return ItemManager.itemUnlocks[ItemType.BURNABLE_BLOCK];

			return true;
		}
	}

	[HarmonyPatch(typeof(IceBomb), "OnTriggerEnter")]
	public static class SnakeBlockPatch
	{
		private static bool Prefix(Collider other)
		{
			return ItemManager.itemUnlocks[ItemType.SNAKE_BLOCK];
		}
	}

	[HarmonyPatch(typeof(LockBlock), "FixedUpdate")]
	public static class LockBlockPatchFixedUpdate
	{
		private static bool Prefix(LockBlock __instance)
		{
			bool enabled = LockBlockIdentifier.IsLockBlockEnabled(__instance, out ItemType lockBlockType);

			if (lockBlockType == ItemType.GUBE)
			{
				if (__instance.GetComponent<W4Gobe>() == null)
				{
					__instance.RB.constraints = ItemManager.itemUnlocks[ItemType.GUBE_DISABLE] ?
						RigidbodyConstraints.FreezeAll : (RigidbodyConstraints)56;
				}
				else
				{
					__instance.RB.constraints = enabled ?
						(RigidbodyConstraints)56 : RigidbodyConstraints.FreezeAll;

					bool disabled = ItemManager.itemUnlocks[ItemType.GUBE_DISABLE];

					BoxCollider[] boxColliders = __instance.GetComponentsInChildren<BoxCollider>();

					foreach (BoxCollider boxCollider in boxColliders)
						boxCollider.enabled = !disabled;

					boxColliders[0].enabled = true;
					boxColliders[4].enabled = true;
					__instance.gameObject.tag = disabled ? "Untagged" : "Killzone";
				}

				return enabled;
			}
			else if (lockBlockType == ItemType.BLOCK_LAUNCHER_ICE)
			{
				return true;
			}
			else if (enabled)
			{
				__instance.RB.constraints = (RigidbodyConstraints)56;

				return true;
			}
			else
			{
				__instance.RB.constraints = RigidbodyConstraints.FreezeAll;

				return false;
			}
		}
	}

	[HarmonyPatch(typeof(LockBlock), "Update")]
	public static class LockBlockPatchUpdate
	{
		private static bool Prefix(LockBlock __instance)
		{
			return LockBlockIdentifier.IsLockBlockEnabled(__instance, out _);
		}
	}

	[HarmonyPatch(typeof(LockBlock), "OnTriggerEnter")]
	public static class LockBlockPatchOnTriggerEnter
	{
		private static bool Prefix(Collider other, LockBlock __instance)
		{
			return LockBlockIdentifier.IsLockBlockEnabled(__instance, out _);
		}
	}

	[HarmonyPatch(typeof(LockBlock), "OnTriggerStay")]
	public static class LockBlockPatchOnTriggerStay
	{
		private static bool Prefix(Collider other, LockBlock __instance)
		{
			return LockBlockIdentifier.IsLockBlockEnabled(__instance, out _);
		}
	}

	[HarmonyPatch(typeof(LockBlock), "OnTriggerExit")]
	public static class LockBlockPatchOnTriggerExit
	{
		private static bool Prefix(Collider other, LockBlock __instance)
		{
			return LockBlockIdentifier.IsLockBlockEnabled(__instance, out _);
		}
	}

	public static class LockBlockIdentifier
	{
		public static bool IsLockBlockEnabled(LockBlock lockBlock, out ItemType type)
		{
			switch (Core.CropString(lockBlock.gameObject.name))
			{
				case "NewPhysBlock":
				case "NewPhysBlock_Big":
				case "W2Tether":
				case "W4_Box":
				case "W4_Honey_Big":
				case "W4_Honey":
					type = ItemType.PHYSICS_BLOCK_STANDARD;
					break;
				case "W41x1":
				case "W41x1H":
				case "Gobe":
					if (lockBlock.golfBall)
						type = ItemType.GOLF_BALL;
					else if (lockBlock.GetComponent<W4Gobe>() == null)
						type = ItemType.PHYSICS_BLOCK_STANDARD;
					else
						type = ItemType.GUBE;
					break;
				case "NewIce":
				case "NewIce_Small":
					type = ItemType.PHYSICS_BLOCK_ICE;
					break;
				case "LockBlock":
				case "LockBlock_Big":
					type = ItemType.PHYSICS_BLOCK_HOLD;
					break;
				case "NoPunch":
				case "NoPunch_Big":
					type = ItemType.PHYSICS_BLOCK_CONCRETE;
					break;
				case "W5Box_8":
				case "W5Box_16":
				case "W5Box_32":
				case "W5Box_64":
				case "W5Box_128":
				case "W5Box_256":
					type = ItemType.PHYSICS_BLOCK_ELECTRIC;
					break;
				case "Scrapped_AxisBlock":
					type = ItemType.PHYSICS_BLOCK_LINE;
					break;
				case "Starblock":
				case "Starblock_W2":
				case "Boss3Starblock":
					type = ItemType.STAR_BLOCK_STANDARD;
					break;
				case "Boss3Starblock_Lock":
					type = ItemType.STAR_BLOCK_HOLD;
					break;
				case "Boss3Heartblock_N":
					type = ItemType.HEART_BLOCK_STANDARD;
					break;
				case "W1Gube":
					type = ItemType.GUBE;
					break;
				case "PowPlat":
					type = ItemType.BLOCK_LAUNCHER_ICE;
					break;
				case "Col_Icecube":
					type = ItemType.BUBBLE_HONEY;
					break;
				case "BombFruitFruitBomb":
					type = ItemType.BOMB_FLOWER;
					break;
				case "HiveBomb":
					type = ItemType.BOMB_HIVE;
					break;
				case "KeyBlock":
					type = ItemType.KEY_BLOCK_STANDARD;
					break;
				case "NewIceKey":
					type = ItemType.KEY_BLOCK_ICE;
					break;
				case "Icicle_New":
					type = ItemType.ICICLE;
					break;
				case "Barrel":
				case "Barrel_":
					type = ItemType.BARREL;
					break;
				case "Gorbit":
					type = ItemType.GORB_HOLD;
					break;
				default:
					Melon<Core>.Logger.Error("Lock block has name: " + Core.CropString(lockBlock.gameObject.name));
					type = ItemType.PHYSICS_BLOCK_STANDARD;
					return true;
			}

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(W1Sliders), "OnTriggerEnter")]
	public static class W1SliderPatchOnTriggerEnter
	{
		private static bool Prefix(W1Sliders __instance)
		{
			return ItemManager.itemUnlocks[(!__instance.FinaleVersion) ?
				ItemType.SLIDING_BLOCK_STANDARD : ItemType.SLIDING_BLOCK_GALACTIC];
		}
	}

	[HarmonyPatch(typeof(W1Sliders), "OnTriggerExit")]
	public static class W1SliderPatchOnTriggerExit
	{
		private static bool Prefix(W1Sliders __instance)
		{
			return ItemManager.itemUnlocks[(!__instance.FinaleVersion) ?
				ItemType.SLIDING_BLOCK_STANDARD : ItemType.SLIDING_BLOCK_GALACTIC];
		}
	}

	[HarmonyPatch(typeof(W3B_BigBox), "FixedUpdate")]
	public static class W3SliderPatchFixedUpdate
	{
		private static bool Prefix(W3B_BigBox __instance)
		{
			return W3SliderIdentifier.IsW3SliderEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(W3B_BigBox), "Update")]
	public static class W3SliderPatchUpdate
	{
		private static bool Prefix(W3B_BigBox __instance)
		{
			return W3SliderIdentifier.IsW3SliderEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(W3B_BigBox), "OnTriggerEnter")]
	public static class W3SliderPatchOnTriggerEnter
	{
		private static bool Prefix(W3B_BigBox __instance)
		{
			return W3SliderIdentifier.IsW3SliderEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(W3B_BigBox), "OnTriggerStay")]
	public static class W3SliderPatchOnTriggerStay
	{
		private static bool Prefix(W3B_BigBox __instance)
		{
			return W3SliderIdentifier.IsW3SliderEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(W3B_BigBox), "OnTriggerExit")]
	public static class W3SliderPatchOnTriggerExit
	{
		private static bool Prefix(W3B_BigBox __instance)
		{
			return W3SliderIdentifier.IsW3SliderEnabled(__instance);
		}
	}

	public static class W3SliderIdentifier
	{
		public static bool IsW3SliderEnabled(W3B_BigBox slider)
		{
			ItemType type;

			if (slider.W3A)
				type = ItemType.SLIDING_BLOCK_HOLD;
			else if (slider.World2Slider)
				type = ItemType.LIFT_ARROW;
			else if (!slider.idea2)
				type = ItemType.SLIDING_BLOCK_CRYSTAL;
			else if (!slider.Boss3Version)
				type = ItemType.SLIDING_BLOCK_DELAY;
			else if (slider.BossAVer)
				type = ItemType.HEART_BLOCK_SLIDING;
			else
				type = ItemType.HEART_BLOCK_DELAY;

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(FrozenPunchPlayer), "Update")]
	public static class FrozenPunchPlayerPatchUpdate
	{
		private static bool Prefix(FrozenPunchPlayer __instance)
		{
			if (ItemManager.itemUnlocks[ItemType.STAR_BLOCK_DELAY])
			{
				__instance.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)56;

				return true;
			}
			else
			{
				__instance.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

				return false;
			}
		}
	}

	[HarmonyPatch(typeof(FrozenPunchPlayer), "OnTriggerEnter")]
	public static class FrozenPunchPlayerPatchOnTriggerEnter
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.STAR_BLOCK_DELAY];
		}
	}

	[HarmonyPatch(typeof(FrozenPunchPlayer), "OnTriggerExit")]
	public static class FrozenPunchPlayerPatchOnTriggerExit
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.STAR_BLOCK_DELAY];
		}
	}

	[HarmonyPatch(typeof(W3B_PopBlock), "OnTriggerEnter")]
	public static class PopBlockStandardPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.POP_BLOCK_STANDARD];
		}
	}

	[HarmonyPatch(typeof(FinalePopupBlocks), "OnTriggerEnter")]
	public static class PopBlockGalacticPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.POP_BLOCK_GALACTIC];
		}
	}

	[HarmonyPatch(typeof(Bumper), "OnTriggerEnter")]
	public static class BumperPatch
	{
		private static bool Prefix(Bumper __instance)
		{
			if (__instance.W2Version)
				return ItemManager.itemUnlocks[ItemType.BUMPER_DIRECTIONAL];
			else if (Core.CropString(__instance.gameObject.name).Equals("BlackHoleBumper"))
				return ItemManager.itemUnlocks[ItemType.BUMPER_BLACK_HOLE];
			else
				return ItemManager.itemUnlocks[ItemType.BUMPER_STANDARD];
		}
	}

	[HarmonyPatch(typeof(LockBoom), "Update")]
	public static class BumperHoldPatch
	{
		private static bool Prefix(Bumper __instance)
		{
			return ItemManager.itemUnlocks[ItemType.BUMPER_HOLD];
		}
	}

	[HarmonyPatch(typeof(W3BPunchableBox), "OnTriggerEnter")]
	public static class PunchableBoxPatch
	{
		private static bool Prefix(W3BPunchableBox __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3A ?
				ItemType.SWITCH_BLOCK_TOGGLE : ItemType.SWITCH_BLOCK_TIMED];
		}
	}

	[HarmonyPatch(typeof(PunchappearBlocks), "FixedUpdate")]
	public static class PunchappearBlockPatchFixedUpdate
	{
		private static bool Prefix(PunchappearBlocks __instance)
		{
			return IdentifyPunchappearBlock.IsPunchappearBlockEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(PunchappearBlocks), "Update")]
	public static class PunchappearBlockPatchUpdate
	{
		private static bool Prefix(PunchappearBlocks __instance)
		{
			return IdentifyPunchappearBlock.IsPunchappearBlockEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(PunchappearBlocks), "OnTriggerEnter")]
	public static class PunchappearBlockPatchOnTriggerEnter
	{
		private static bool Prefix(PunchappearBlocks __instance)
		{
			return IdentifyPunchappearBlock.IsPunchappearBlockEnabled(__instance);
		}
	}

	[HarmonyPatch(typeof(PunchappearBlocks), "OnTriggerStay")]
	public static class PunchappearBlockPatchOnTriggerStay
	{
		private static bool Prefix(PunchappearBlocks __instance)
		{
			return IdentifyPunchappearBlock.IsPunchappearBlockEnabled(__instance);
		}
	}

	public static class IdentifyPunchappearBlock
	{
		public static bool IsPunchappearBlockEnabled(PunchappearBlocks punchappearBlock)
		{
			ItemType type;

			if (punchappearBlock.W3A)
				type = ItemType.PUNCHAPPEAR_BLOCK_HOLD;
			else if (punchappearBlock.W3B2)
			{
				if (punchappearBlock.SkullTimerMaterial != null)
					type = ItemType.PUNCHAPPEAR_BLOCK_TIMED;
				else
					type = ItemType.TIMER_BUTTON;
			}
			else if (punchappearBlock.W3A2)
				type = ItemType.PUNCHAPPEAR_BLOCK_TOGGLE;
			else if (punchappearBlock.ArchiveKeyWall)
				type = ItemType.KEY_QUARTET;
			else if (punchappearBlock.W4)
				type = ItemType.SEMISOLID_TOGGLE;
			else if (punchappearBlock.NewW1)
				type = ItemType.PUNCHAPPEAR_BLOCK_STANDARD;
			else if (punchappearBlock.W3B)
				type = ItemType.GLASS_BLOCK;
			else
				type = ItemType.ON_OFF_BLOCK;

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(LockDeathblock), "Update")]
	public static class SkullBlockPatchUpdate
	{
		private static bool Prefix(LockDeathblock __instance)
		{
			switch (IdentifySkullBlock.GetSkullBlockState(__instance))
			{
				case 0:
					__instance.KZ.SetActive(true);
					__instance.SR.sprite = __instance.Active;
					__instance.PS.enableEmission = true;

					if (__instance.White != null)
						__instance.White.color = new Vector4(1f, 1f, 1f, 0);

					return false;
				case 1:
					return true;
				case 2:
					__instance.KZ.SetActive(false);
					__instance.SR.sprite = __instance.Inactive;
					__instance.PS.enableEmission = false;

					if (__instance.White != null)
						__instance.White.color = new Vector4(1f, 1f, 1f, 0);

					return false;
				default:
					Melon<Core>.Logger.Error("Skull block enabled state is " +
						IdentifySkullBlock.GetSkullBlockState(__instance));
					return true;
			}
		}
	}

	public static class IdentifySkullBlock
	{
		public static int GetSkullBlockState(LockDeathblock skullBlock)
		{
			ItemType type;
			ItemType typeDisable;

			if (!skullBlock.W3B && !skullBlock.W3A2)
			{
				type = ItemType.SKULL_BLOCK_HOLD;
				typeDisable = ItemType.SKULL_BLOCK_HOLD_DISABLE;
			}
			else if (!skullBlock.W3A2)
			{
				type = ItemType.SKULL_BLOCK_TIMED;
				typeDisable = ItemType.SKULL_BLOCK_TIMED_DISABLE;
			}
			else
			{
				type = ItemType.SKULL_BLOCK_TOGGLE;
				typeDisable = ItemType.SKULL_BLOCK_TOGGLE_DISABLE;
			}

			return ItemManager.itemUnlocks[typeDisable] ? 2 : (ItemManager.itemUnlocks[type] ? 1 : 0);
		}
	}

	[HarmonyPatch(typeof(LockSkull), "Update")]
	public static class SkullRingPatch
	{
		private static bool Prefix(LockSkull __instance)
		{
			ItemType type = __instance.W3B ?
				ItemType.SKULL_RING_TIMED : ItemType.SKULL_RING_HOLD;
			ItemType typeDisable = __instance.W3B ?
				ItemType.SKULL_RING_TIMED_DISABLE : ItemType.SKULL_RING_HOLD_DISABLE;

			if (ItemManager.itemUnlocks[typeDisable])
			{
				__instance.GetComponent<BoxCollider>().enabled = false;
				__instance.SR.enabled = false;

				return false;
			}
			else if (ItemManager.itemUnlocks[type])
			{
				__instance.GetComponent<BoxCollider>().enabled = true;
				__instance.SR.enabled = true;

				return true;
			}
			else
			{
				__instance.GetComponent<BoxCollider>().enabled = true;
				__instance.SR.enabled = true;

				if (!__instance.NonLoopSkull)
					__instance.transform.parent.eulerAngles -= new Vector3(0f, 0f, __instance.Speed * Time.deltaTime);
				else
				{
					__instance.transform.position -= new Vector3(0f, __instance.Speed, 0f) * Time.deltaTime;
					__instance.Lifetime -= Time.deltaTime;
					if (__instance.Lifetime < 0f)
					{
						UnityEngine.Object.Destroy(__instance.gameObject);
					}
				}

				return false;
			}
		}
	}


	[HarmonyPatch(typeof(W3LoneSkullGenerator), "FixedUpdate")]
	public static class SkullGeneratorPatch
	{
		private static bool Prefix(W3LoneSkullGenerator __instance)
		{
			if (!__instance.PreBossBombGenerator)
			{
				if (ItemManager.itemUnlocks[ItemType.SKULL_RING_HOLD_DISABLE])
					return false;
				else if (ItemManager.itemUnlocks[ItemType.SKULL_RING_HOLD])
					return true;

				__instance.Timer -= Time.fixedDeltaTime;
				if (__instance.Timer < 0f)
				{
					__instance.Timer = (float)__instance.Range(50, 200) / 100f;
					UnityEngine.Object.Instantiate(
						__instance.SkullPrefab,
						__instance.transform.position,
						__instance.RotationExample.transform.rotation,
						__instance.transform);
				}

				return false;
			}
			else
			{
				return ItemManager.itemUnlocks[ItemType.BOMB_BLOCK];
			}
		}
	}

	[HarmonyPatch(typeof(W1Gube), "FixedUpdate")]
	public static class GubePatchFixedUpdate
	{
		private static bool Prefix(W1Gube __instance)
		{
			bool gubesExist = !ItemManager.itemUnlocks[ItemType.GUBE_DISABLE];

			foreach (BoxCollider boxCollider in __instance.GetComponentsInChildren<BoxCollider>())
				boxCollider.enabled = gubesExist;

			__instance.SR_Box1.enabled = gubesExist;
			__instance.SR_Box2.enabled = gubesExist;
			__instance.SR_Legs.enabled = gubesExist;

			return gubesExist;
		}
	}

	[HarmonyPatch(typeof(W1Gube), "Update")]
	public static class GubePatchUpdate
	{
		private static bool Prefix()
		{
			return !ItemManager.itemUnlocks[ItemType.GUBE_DISABLE];
		}
	}

	[HarmonyPatch(typeof(W1Gube), "LateUpdate")]
	public static class GubePatchLateUpdate
	{
		private static bool Prefix()
		{
			return !ItemManager.itemUnlocks[ItemType.GUBE_DISABLE];
		}
	}

	[HarmonyPatch(typeof(FinalGhostLooping), "Update")]
	public static class GorbPatchUpdate
	{
		private static bool Prefix(FinalGhostLooping __instance)
		{
			ItemType type = __instance.W3B ?
				ItemType.GORB_DELAY : ItemType.GORB_HOLD;
			ItemType typeDisable = __instance.W3B ?
				ItemType.GORB_DELAY_DISABLE : ItemType.GORB_HOLD_DISABLE;

			if (!ItemManager.itemUnlocks[type])
			{
				foreach (SpriteRenderer spriteRenderer in __instance.SR)
				{
					spriteRenderer.sprite = __instance.Inactive;
				}
			}

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(
					!ItemManager.itemUnlocks[typeDisable]);
			}

			return true;
		}
	}

	[HarmonyPatch(typeof(FinalGhostLooping), "OnTriggerEnter")]
	public static class GorbPatchOnTriggerEnter
	{
		private static bool Prefix(FinalGhostLooping __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ? ItemType.GORB_DELAY : ItemType.GORB_HOLD];
		}
	}

	[HarmonyPatch(typeof(FinalGhostLooping), "OnTriggerExit")]
	public static class GorbPatchOnTriggerExit
	{
		private static bool Prefix(FinalGhostLooping __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ? ItemType.GORB_DELAY : ItemType.GORB_HOLD];
		}
	}

	[HarmonyPatch(typeof(ViViPunchBlock), "OnTriggerEnter")]
	public static class ViviBlockPatchOnTriggerEnter
	{
		private static bool Prefix(ViViPunchBlock __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3A ? ItemType.VIVI_BLOCK_HOLD : ItemType.VIVI_BLOCK_STANDARD];
		}
	}

	[HarmonyPatch(typeof(ViViPunchBlock), "OnTriggerExit")]
	public static class ViviBlockPatchOnTriggerExit
	{
		private static bool Prefix(ViViPunchBlock __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3A ? ItemType.VIVI_BLOCK_HOLD : ItemType.VIVI_BLOCK_STANDARD];
		}
	}

	[HarmonyPatch(typeof(W5_StarworkGem), "OnTriggerEnter")]
	public static class ViviBlockFireworkPatchOnTriggerEnter
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.VIVI_BLOCK_FIREWORK];
		}
	}

	[HarmonyPatch(typeof(W5_StarworkGem), "OnTriggerExit")]
	public static class ViviBlockFireworkPatchOnTriggerExit
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.VIVI_BLOCK_FIREWORK];
		}
	}

	[HarmonyPatch(typeof(Pow), "OnTriggerEnter")]
	public static class PowPatchOnTriggerEnter
	{
		private static bool Prefix(Pow __instance)
		{
			return IdentifyPow.IsPowEnabled(__instance.transform.parent.gameObject);
		}
	}

	[HarmonyPatch(typeof(Pow), "OnTriggerStay")]
	public static class PowPatchOnTriggerStay
	{
		private static bool Prefix(Pow __instance)
		{
			return IdentifyPow.IsPowEnabled(__instance.transform.parent.gameObject);
		}
	}

	[HarmonyPatch(typeof(LockPow), "Update")]
	public static class LockPowPatchUpdate
	{
		private static bool Prefix(LockPow __instance)
		{
			return IdentifyPow.IsPowEnabled(__instance.transform.parent.parent.gameObject);
		}
	}

	[HarmonyPatch(typeof(LockPow), "OnTriggerEnter")]
	public static class LockPowPatchOnTriggerEnter
	{
		private static bool Prefix(LockPow __instance)
		{
			return IdentifyPow.IsPowEnabled(__instance.transform.parent.parent.gameObject);
		}
	}

	[HarmonyPatch(typeof(LockPow), "OnTriggerStay")]
	public static class LockPowPatchOnTriggerStay
	{
		private static bool Prefix(LockPow __instance)
		{
			return IdentifyPow.IsPowEnabled(__instance.transform.parent.parent.gameObject);
		}
	}

	public static class IdentifyPow
	{
		public static bool IsPowEnabled(GameObject pow)
		{
			ItemType type;

			switch (Core.CropString(pow.name))
			{
				case "Pow":
				case "PowSpike":
				case "Pow4":
				case "W5_Pow":
				case "W5_Pow_Chunky":
				case "W5_Pow_Big":
				case "W5_Pow_Beeg":
					type = ItemType.BLOCK_LAUNCHER_STANDARD;
					break;
				case "PowWinged":
					type = ItemType.BLOCK_LAUNCHER_WING;
					break;
				case "Pow_W2":
				case "Pow_W2_Spiked":
				case "Pow_W2_HL":
				case "Pow_W2_HR":
					type = ItemType.BLOCK_LAUNCHER_PEARL;
					break;
				case "Pow_Ice":
					type = ItemType.BLOCK_LAUNCHER_ICE;
					break;
				case "LockPow":
					type = ItemType.BLOCK_LAUNCHER_HOLD;
					break;
				case "IceLockPow":
					type = ItemType.BLOCK_LAUNCHER_DELAY;
					break;
				case "Pow4H":
					type = ItemType.BLOCK_LAUNCHER_INVERTED;
					break;
				case "Pow_FinalPreBoss":
				case "Pow_FinalPreBossSmasher":
					type = ItemType.BLOCK_LAUNCHER_GALACTIC;
					break;
				case "Scrapped_FirePow":
					type = ItemType.BLOCK_LAUNCHER_FIRE;
					break;
				default:
					Melon<Core>.Logger.Error("Pow has name: " + Core.CropString(pow.name));
					return true;
			}

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(JetBlock), "Update")]
	public static class LauncherPatchUpdate
	{
		private static bool Prefix(JetBlock __instance)
		{
			__instance.transform.GetChild(0).GetChild(1).gameObject.SetActive(
				ItemManager.itemUnlocks[ItemType.LAUNCHER_STANDARD]);

			return ItemManager.itemUnlocks[ItemType.LAUNCHER_STANDARD];
		}
	}

	[HarmonyPatch(typeof(JetBlock), "OnTriggerEnter")]
	public static class LauncherPatchOnTriggerEnter
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.LAUNCHER_STANDARD];
		}
	}

	[HarmonyPatch(typeof(W2_Pearl), "Update")]
	public static class PearlLauncherPatchUpdate
	{
		private static bool Prefix(W2_Pearl __instance)
		{
			if (__instance.PowBlock)
				return ItemManager.itemUnlocks[ItemType.BLOCK_LAUNCHER_PEARL];

			bool enabled = ItemManager.itemUnlocks[__instance.AnyRot ?
				ItemType.LAUNCHER_PEARL_RED : ItemType.LAUNCHER_PEARL_BLUE];

			if (__instance.RingWhite != null)
				__instance.RingWhite.enabled = enabled;
			if (__instance.Ring != null)
				__instance.Ring.enabled = enabled;

			return enabled;
		}
	}

	[HarmonyPatch(typeof(W2_Pearl), "Punch")]
	public static class PearlLauncherPatchPunch
	{
		private static bool Prefix(W2_Pearl __instance)
		{
			return ItemManager.itemUnlocks[__instance.PowBlock ?
				ItemType.BLOCK_LAUNCHER_PEARL : (__instance.AnyRot ?
				ItemType.LAUNCHER_PEARL_RED : ItemType.LAUNCHER_PEARL_BLUE)];
		}
	}

	[HarmonyPatch(typeof(LockLight), "Update")]
	public static class CrystalLauncherPatchUpdate
	{
		private static bool Prefix(LockLight __instance)
		{
			bool enabled = ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.LAUNCHER_CRYSTAL_TIMED : ItemType.LAUNCHER_CRYSTAL_HOLD];

			if (!enabled)
			{
				__instance.Light.SetActive(false);
				__instance.White.color = new Vector4(1f, 1f, 1f, 0f);
			}

			__instance.transform.GetChild(0).gameObject.SetActive(enabled);

			return enabled;
		}
	}

	[HarmonyPatch(typeof(LockLight), "OnTriggerEnter")]
	public static class CrystalLauncherPatchOnTriggerEnter
	{
		private static bool Prefix(LockLight __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.LAUNCHER_CRYSTAL_TIMED : ItemType.LAUNCHER_CRYSTAL_HOLD];
		}
	}

	[HarmonyPatch(typeof(LockLight), "OnTriggerExit")]
	public static class CrystalLauncherPatchOnTriggerExit
	{
		private static bool Prefix(LockLight __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.LAUNCHER_CRYSTAL_TIMED : ItemType.LAUNCHER_CRYSTAL_HOLD];
		}
	}

	[HarmonyPatch(typeof(W4_Moon), "Update")]
	public static class MoonLauncherPatchUpdate
	{
		private static bool Prefix(W4_Moon __instance)
		{
			bool enabled = ItemManager.itemUnlocks[ItemType.LAUNCHER_MOON];

			__instance.transform.GetChild(0).gameObject.SetActive(enabled);

			if (!enabled)
			{
				__instance.OnCol.SetActive(false);
				__instance.OffCol.SetActive(false);
			}
			else
			{
				__instance.OnCol.SetActive(__instance.On);
				__instance.OffCol.SetActive(!__instance.On);
			}

			return enabled;
		}
	}

	[HarmonyPatch(typeof(W4_Moon), "Punch")]
	public static class MoonLauncherPatchPunch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.LAUNCHER_MOON];
		}
	}

	[HarmonyPatch(typeof(SpikeBubble), "Update")]
	public static class SpinnerPatchUpdate
	{
		private static bool Prefix(SpikeBubble __instance)
		{
			ItemType type = __instance.BossStar ?
				ItemType.SPINNER_STAR : ItemType.SPINNER_STANDARD;
			ItemType typeDisable = __instance.BossStar ?
				ItemType.SPINNER_STAR_DISABLE : ItemType.SPINNER_STANDARD_DISABLE;

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(
					!ItemManager.itemUnlocks[typeDisable]);
			}

			SphereCollider sphereCollider = __instance.GetComponent<SphereCollider>();
			if (sphereCollider != null)
				sphereCollider.enabled = !ItemManager.itemUnlocks[typeDisable];

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(SpikeBubble), "OnTriggerEnter")]
	public static class SpinnerPatchOnTriggerEnter
	{
		private static bool Prefix(SpikeBubble __instance)
		{
			return ItemManager.itemUnlocks[__instance.BossStar ?
				ItemType.SPINNER_STAR : ItemType.SPINNER_STANDARD];
		}
	}

	[HarmonyPatch(typeof(SpikeBubble), "OnTriggerExit")]
	public static class SpinnerPatchOnTriggerExit
	{
		private static bool Prefix(SpikeBubble __instance)
		{
			return ItemManager.itemUnlocks[__instance.BossStar ?
				ItemType.SPINNER_STAR : ItemType.SPINNER_STANDARD];
		}
	}

	[HarmonyPatch(typeof(BossOnePipe), "Update")]
	public static class BossOnePipePatch
	{
		private static void Prefix(BossOnePipe __instance)
		{
			if (!__instance.PreBoss || !ItemManager.itemUnlocks[ItemType.SPINNER_STAR_DISABLE])
				return;

			__instance.PreBossObstruction = null;
		}
	}

	[HarmonyPatch(typeof(W2_SunFlower), "Update")]
	public static class FireRingPatchUpdate
	{
		private static void Prefix(W2_SunFlower __instance)
		{
			bool enabled = !ItemManager.itemUnlocks[__instance.BlueDabaDeDabaDai ?
				ItemType.FIRE_RING_BLUE_DISABLE : ItemType.FIRE_RING_RED_DISABLE];

			if (!enabled)
			{
				__instance.Disabled = true;
				__instance.DisTimer = 4f;
				__instance.PetalRadius = 0f;
				__instance.PetalTimer = 0f;
				__instance.BulbTimer = 0f;
				__instance.BulbCenter.transform.localScale = Vector3.zero;
				if (__instance.PS != null)
					__instance.PS.emissionRate = 0.0f;
				if (__instance.oldPS != null)
					__instance.oldPS.gameObject.SetActive(value: false);
				if (__instance.Col != null)
					__instance.Col.SetActive(false);
			}
		}
	}

	[HarmonyPatch(typeof(W2_SunFlower), "BecomeSun")]
	public static class FireRingPatchBecomeSun
	{
		private static bool Prefix(W2_SunFlower __instance)
		{
			return !ItemManager.itemUnlocks[__instance.BlueDabaDeDabaDai ?
				ItemType.FIRE_RING_BLUE_DISABLE : ItemType.FIRE_RING_RED_DISABLE];
		}
	}

	[HarmonyPatch(typeof(W2_SunFlower), "Punch")]
	public static class FireRingPatchPunch
	{
		private static bool Prefix(W2_SunFlower __instance)
		{
			return ItemManager.itemUnlocks[__instance.BlueDabaDeDabaDai ?
				ItemType.FIRE_RING_BLUE : ItemType.FIRE_RING_RED];
		}
	}

	[HarmonyPatch(typeof(W2Bubble), "FixedUpdate")]
	public static class BubblePatchFixedUpdate
	{
		private static bool Prefix(W2Bubble __instance)
		{
			ItemType type;

			if (__instance.Key)
				type = ItemType.BUBBLE_KEY;
			else if (__instance.W3B)
				type = ItemType.BUBBLE_CLEAR;
			else if (__instance.SurpriseHoneyBubble)
				type = ItemType.BUBBLE_HONEY;
			else
				type = ItemType.BUBBLE_STATIONARY;

			bool enabled = ItemManager.itemUnlocks[type];

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
			}

			return enabled;
		}
	}

	[HarmonyPatch(typeof(W2Bubble), "Update")]
	public static class BubblePatchUpdate
	{
		private static bool Prefix(W2Bubble __instance)
		{
			ItemType type;

			if (__instance.Key)
				type = ItemType.BUBBLE_KEY;
			else if (__instance.W3B)
				type = ItemType.BUBBLE_CLEAR;
			else if (__instance.SurpriseHoneyBubble)
				type = ItemType.BUBBLE_HONEY;
			else
				type = ItemType.BUBBLE_STATIONARY;

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(W2Bubble), "OnTriggerEnter")]
	public static class BubblePatchOnTriggerEnter
	{
		private static bool Prefix(W2Bubble __instance)
		{
			ItemType type;

			if (__instance.Key)
				type = ItemType.BUBBLE_KEY;
			else if (__instance.W3B)
				type = ItemType.BUBBLE_CLEAR;
			else if (__instance.SurpriseHoneyBubble)
				type = ItemType.BUBBLE_HONEY;
			else
				type = ItemType.BUBBLE_STATIONARY;

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(W2Bubble), "OnTriggerStay")]
	public static class BubblePatchOnTriggerStay
	{
		private static bool Prefix(W2Bubble __instance)
		{
			ItemType type;

			if (__instance.Key)
				type = ItemType.BUBBLE_KEY;
			else if (__instance.W3B)
				type = ItemType.BUBBLE_CLEAR;
			else if (__instance.SurpriseHoneyBubble)
				type = ItemType.BUBBLE_HONEY;
			else
				type = ItemType.BUBBLE_STATIONARY;

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(W2Bubble), "OnTriggerExit")]
	public static class BubblePatchOnTriggerExit
	{
		private static bool Prefix(W2Bubble __instance)
		{
			ItemType type;

			if (__instance.Key)
				type = ItemType.BUBBLE_KEY;
			else if (__instance.W3B)
				type = ItemType.BUBBLE_CLEAR;
			else if (__instance.SurpriseHoneyBubble)
				type = ItemType.BUBBLE_HONEY;
			else
				type = ItemType.BUBBLE_STATIONARY;

			return ItemManager.itemUnlocks[type];
		}
	}

	[HarmonyPatch(typeof(W2Boss_Bubble), "FixedUpdate")]
	public static class BossBubblePatchFixedUpdate
	{
		private static bool Prefix(W2Boss_Bubble __instance)
		{
			bool enabled = ItemManager.itemUnlocks[ItemType.BUBBLE_NUMBER];

			__instance.GetComponent<SpriteRenderer>().enabled = enabled;

			return enabled;
		}
	}

	[HarmonyPatch(typeof(W2Boss_Bubble), "LateUpdate")]
	public static class BossBubblePatchLateUpdate
	{
		private static bool Prefix(W2Boss_Bubble __instance)
		{
			return ItemManager.itemUnlocks[ItemType.BUBBLE_NUMBER];
		}
	}

	[HarmonyPatch(typeof(W2Boss_Bubble), "OnTriggerEnter")]
	public static class BossBubblePatchOnTriggerEnter
	{
		private static bool Prefix(W2Boss_Bubble __instance)
		{
			return ItemManager.itemUnlocks[ItemType.BUBBLE_NUMBER];
		}
	}

	[HarmonyPatch(typeof(Balloon), "Update")]
	public static class BalloonPatch
	{
		private static bool Prefix(Balloon __instance)
		{
			ItemType type;

			if (__instance.LeadCell)
				type = ItemType.BALLOON_TOGGLE;
			else if (__instance.Lead)
				type = ItemType.BALLOON_LEAD;
			else if (Core.CropString(__instance.gameObject.name).Equals("Balloon_Impulse"))
				type = ItemType.BALLOON_BLUE;
			else
				type = ItemType.BALLOON_RED;

			bool enabled = ItemManager.itemUnlocks[type];

			if (!enabled)
			{
				__instance.Pop = true;
				__instance.Poptimer = 0;
				if (__instance.Outline != null)
					__instance.Outline.enabled = true;
				if (__instance.Vis != null)
					__instance.Vis.transform.localScale = Vector3.zero;
			}
			else if (type == ItemType.BALLOON_LEAD || type == ItemType.BALLOON_TOGGLE)
			{
				__instance.Pop = false;
				if (__instance.Outline != null)
					__instance.Outline.enabled = false;
				if (__instance.Vis != null)
					__instance.Vis.transform.localScale = Vector3.one;
			}

			return enabled;
		}
	}

	[HarmonyPatch(typeof(Bombable_HiveHoney), "OnTriggerEnter")]
	public static class HiveBlockPatch
	{
		private static bool Prefix(Bombable_HiveHoney __instance)
		{
			return ItemManager.itemUnlocks[__instance.Pink ?
				ItemType.HIVE_BLOCK_RED : ItemType.HIVE_BLOCK_BLUE];
		}
	}

	[HarmonyPatch(typeof(Page_Buttons), "OnTriggerStay")]
	public static class ButtonPatch
	{
		private static bool Prefix(Page_Buttons __instance)
		{
			return ItemManager.itemUnlocks[__instance.ArchiveKeyButton ?
				ItemType.KEY_QUARTET : (__instance.FinalBoss49Manager ?
				ItemType.BARREL : ItemType.TIMER_BUTTON)];
		}
	}

	[HarmonyPatch(typeof(FiveMileSpireCloverChamber), "FixedUpdate")]
	public static class KeyInvertedPatch
	{
		private static void Prefix(FiveMileSpireCloverChamber __instance)
		{
			Rigidbody rb = __instance.GetComponent<Rigidbody>();

			if (rb == null)
				return;

			rb.constraints =
				ItemManager.itemUnlocks[ItemType.KEY_BLOCK_INVERTED] ?
				(RigidbodyConstraints)56 : RigidbodyConstraints.FreezeAll;
		}
	}

	[HarmonyPatch(typeof(GhostPush), "FixedUpdate")]
	public static class WaterDropPatch
	{
		private static void Prefix(GhostPush __instance)
		{
			if (!__instance.WaterOrb)
				return;

			bool enabled = ItemManager.itemUnlocks[Core.CropString(
				__instance.gameObject.name).Equals("HoneyOrb") ?
				ItemType.GRAVITY_FLIPPER_UP : ItemType.GRAVITY_FLIPPER_DOWN];

			__instance.GetComponent<BoxCollider>().enabled = enabled;

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
			}
		}
	}


	[HarmonyPatch(typeof(DeleteOnRightClick), "Start")]
	public static class LockerPatch
	{
		private static void Prefix(DeleteOnRightClick __instance)
		{
			switch (Core.CropString(__instance.gameObject.name))
			{
				case "Quatrafoil":
				case "Quatrafoil_Alt":
				case "Reflection Honey_Infinite":
				case "Reflection_Infinite":
					Locker.gameObjects.Add(__instance.gameObject);
					break;
			}
		}
	}

	[HarmonyPatch(typeof(SplitScreen), "Update")]
	public static class GravityFistPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.GRAVITY_FIST];
		}
	}

	[HarmonyPatch(typeof(FiveMileSpireCloverChamber), "OtherFistStuff")]
	public static class GravityAnchorPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.GRAVITY_ANCHOR];
		}
	}

	[HarmonyPatch(typeof(W3Girder), "FixedUpdate")]
	public static class GirderPatch
	{
		private static bool Prefix(W3Girder __instance)
		{
			bool enabled = ItemManager.itemUnlocks[ItemType.LIFT_HOLD];

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
			}

			__instance.GetComponent<SpriteRenderer>().enabled = enabled;

			__instance.GetComponent<BoxCollider>().enabled = enabled;

			return enabled;
		}
	}


	[HarmonyPatch(typeof(DroneCarryPlatform), "FixedUpdate")]
	public static class HiveElevatorPatch
	{
		private static bool Prefix(DroneCarryPlatform __instance)
		{
			bool enabled = ItemManager.itemUnlocks[ItemType.LIFT_HIVE];

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
			}

			foreach (BoxCollider boxCollider in __instance.GetComponents<BoxCollider>())
			{
				boxCollider.enabled = enabled;
			}

			return enabled;
		}
	}

	[HarmonyPatch(typeof(OneWayTiles), "Start")]
	public static class SemisolidPatch
	{
		private static void Prefix(OneWayTiles __instance)
		{
			Locker.gameObjects.Add(__instance.transform.parent.gameObject);
		}
	}

	[HarmonyPatch(typeof(PunchFlower), "Update")]
	public static class PunchFlowerPatchUpdate
	{
		private static void Prefix(PunchFlower __instance)
		{
			if (!__instance.Bulb)
				return;

			bool enabled = ItemManager.itemUnlocks[ItemType.TOGGLE_FLOWER];

			if (__instance.Pink)
			{
				if (enabled)
				{
					__instance.transform.GetChild(3).gameObject.SetActive(enabled);
				}
				else
				{
					for (int childId = 0; childId < __instance.transform.childCount; ++childId)
					{
						__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
					}
				}
			}
			else
			{
				for (int childId = 0; childId < __instance.transform.childCount; ++childId)
				{
					__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
				}
			}
		}
	}

	[HarmonyPatch(typeof(PunchFlower), "OnTriggerEnter")]
	public static class PunchFlowerPatchOnTriggerEnter
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.TOGGLE_FLOWER];
		}
	}

	[HarmonyPatch(typeof(W4Gobe), "FixedUpdate")]
	public static class TetherPatchFixedUpdate
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.TETHER];
		}
	}

	[HarmonyPatch(typeof(W4Gobe), "LateUpdate")]
	public static class TetherPatchLateUpdate
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.TETHER];
		}
	}

	[HarmonyPatch(typeof(NewDarkness), "LateUpdate")]
	public static class FlashlightPatch
	{
		private static bool Prefix(NewDarkness __instance)
		{
			bool hasFlashlight = ItemManager.itemUnlocks[ItemType.FLASHLIGHT];

			__instance.GetComponent<SpriteRenderer>().enabled = !hasFlashlight;

			return !hasFlashlight;
		}
	}

	[HarmonyPatch(typeof(W4Pixie), "FixedUpdate")]
	public static class PixiePatchFixedUpdate
	{
		private static bool Prefix(W4Pixie __instance)
		{
			if (ItemManager.itemUnlocks[ItemType.PIXIE_DISABLE])
			{
				__instance.GetComponent<SpriteRenderer>().enabled = false;
				__instance.GetComponent<SphereCollider>().enabled = false;

				for (int childId = 0; childId < __instance.transform.childCount; ++childId)
				{
					__instance.transform.GetChild(childId).gameObject.SetActive(false);
				}

				return false;
			}

			__instance.GetComponent<SpriteRenderer>().enabled = true;
			__instance.GetComponent<SphereCollider>().enabled = true;

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(true);
			}

			return true;
		}
	}

	[HarmonyPatch(typeof(W4Pixie), "Update")]
	public static class PixiePatchUpdate
	{
		private static bool Prefix()
		{
			if (ItemManager.itemUnlocks[ItemType.PIXIE_DISABLE])
				return false;

			return true;
		}
	}

	[HarmonyPatch(typeof(W4Pixie), "OnTriggerEnter")]
	public static class PixiePatchOnTriggerEnter
	{
		private static bool Prefix()
		{
			if (ItemManager.itemUnlocks[ItemType.PIXIE_DISABLE])
				return false;
			else if (ItemManager.itemUnlocks[ItemType.PIXIE])
				return true;
			return false;
		}
	}

	[HarmonyPatch(typeof(W4Pixie), "OnTriggerStay")]
	public static class PixiePatchOnTriggerStay
	{
		private static bool Prefix()
		{
			if (ItemManager.itemUnlocks[ItemType.PIXIE_DISABLE])
				return false;
			else if (ItemManager.itemUnlocks[ItemType.PIXIE])
				return true;
			return false;
		}
	}

	[HarmonyPatch(typeof(Vivi_movement), "FixedUpdate")]
	public static class ViviMovementPatchFixedUpdate
	{
		private static bool Prefix(Vivi_movement __instance)
		{
			if (__instance.GolfCarting)
				return ItemManager.itemUnlocks[ItemType.GOLF_CART];
			return true;
		}
	}

	[HarmonyPatch(typeof(Vivi_movement), "Update")]
	public static class ViviMovementPatchUpdate
	{
		private static bool Prefix(Vivi_movement __instance)
		{
			if (__instance.GolfCarting)
				return ItemManager.itemUnlocks[ItemType.GOLF_CART];
			return true;
		}
	}

	[HarmonyPatch(typeof(Whirl), "Update")]
	public static class ThermalPatch
	{
		private static bool Prefix(Whirl __instance)
		{
			bool enabled = ItemManager.itemUnlocks[ItemType.THERMAL];

			__instance.GetComponent<BoxCollider>().enabled = enabled;

			__instance.transform.parent.GetChild(0).gameObject.SetActive(enabled);
			__instance.transform.parent.GetChild(1).gameObject.SetActive(enabled);
			__instance.transform.parent.GetChild(2).gameObject.SetActive(enabled);

			return enabled;
		}
	}

	[HarmonyPatch(typeof(GemArrayHazard), "OnTriggerEnter")]
	public static class FallingCrystalPatchOnTriggerEnter
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.FALLING_CRYSTAL];
		}
	}

	[HarmonyPatch(typeof(GemArrayHazard), "OnTriggerStay")]
	public static class FallingCrystalPatchOnTriggerStay
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.FALLING_CRYSTAL];
		}
	}

	[HarmonyPatch(typeof(GemArrayHazard), "OnTriggerExit")]
	public static class FallingCrystalPatchOnTriggerExit
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.FALLING_CRYSTAL];
		}
	}

	[HarmonyPatch(typeof(W5_MoveBlocks), "OnTriggerStay")]
	public static class GrabBlockPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.GRAB_BLOCK];
		}
	}

	[HarmonyPatch(typeof(W5Mirror), "Update")]
	public static class MirrorPatch
	{
		private static bool Prefix(W5Mirror __instance)
		{
			bool enabled = ItemManager.itemUnlocks[ItemType.MIRROR];

			if (!enabled)
			{
				__instance.Col.transform.localPosition = Vector3.zero;
				__instance.Vis.SetActive(value: true);
				__instance.White.color = new Vector4(1f, 1f, 1f, 0f);
			}

			return enabled;
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_OnOff), "Update")]
	public static class StronkeyKongPatchUpdate
	{
		private static bool Prefix(FinalBoss_49_OnOff __instance)
		{
			if (__instance.Skulls)
			{
				if (ItemManager.itemUnlocks[ItemType.SKULL_BLOCK_HOLD_DISABLE])
				{
					__instance.Killbox.SetActive(false);
					__instance.PS.enableEmission = false;
					__instance.SR.sprite = __instance.S_Off;
					__instance.Solid = false;
					__instance.WallBox.transform.localScale = Vector3.one;

					return false;
				}
				else if (ItemManager.itemUnlocks[ItemType.SKULL_BLOCK_HOLD])
				{
					return true;
				}
				else
				{
					__instance.Killbox.SetActive(true);
					__instance.PS.enableEmission = true;
					__instance.SR.sprite = __instance.S_On;
					__instance.Solid = true;
					__instance.WallBox.transform.localScale = Vector3.one * .8f;

					return false;
				}
			}

			if (__instance.W3)
			{
				return ItemManager.itemUnlocks[ItemType.PUNCHAPPEAR_BLOCK_HOLD];
			}

			return true;
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_OnOff), "ToggleWorld1Version")]
	public static class StronkeyKongPatchOnOffBlock
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.ON_OFF_BLOCK];
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_PowTrigger), "OnTriggerStay")]
	public static class StronkeyKongPatchBlockLauncher
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.BLOCK_LAUNCHER_STANDARD];
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_Bubbles), "FixedUpdate")]
	public static class StronkeyKongPatchBubbleFixedUpdate
	{
		private static bool Prefix(FinalBoss_49_Bubbles __instance)
		{
			bool enabled = ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.BUBBLE_CLEAR : ItemType.BUBBLE_STATIONARY];

			for (int childId = 0; childId < __instance.transform.childCount; ++childId)
			{
				__instance.transform.GetChild(childId).gameObject.SetActive(enabled);
			}

			return enabled;
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_Bubbles), "Update")]
	public static class StronkeyKongPatchBubbleUpdate
	{
		private static bool Prefix(FinalBoss_49_Bubbles __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.BUBBLE_CLEAR : ItemType.BUBBLE_STATIONARY];
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_Bubbles), "OnTriggerEnter")]
	public static class StronkeyKongPatchBubbleOnTriggerEnter
	{
		private static bool Prefix(FinalBoss_49_Bubbles __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.BUBBLE_CLEAR : ItemType.BUBBLE_STATIONARY];
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_Bubbles), "OnTriggerStay")]
	public static class StronkeyKongPatchBubbleOnTriggerStay
	{
		private static bool Prefix(FinalBoss_49_Bubbles __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.BUBBLE_CLEAR : ItemType.BUBBLE_STATIONARY];
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_Bubbles), "OnTriggerExit")]
	public static class StronkeyKongPatchBubbleOnTriggerExit
	{
		private static bool Prefix(FinalBoss_49_Bubbles __instance)
		{
			return ItemManager.itemUnlocks[__instance.W3B ?
				ItemType.BUBBLE_CLEAR : ItemType.BUBBLE_STATIONARY];
		}
	}

	[HarmonyPatch(typeof(PushDownBricks), "OnTriggerStay")]
	public static class PushDownBrickPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.PILLAR];
		}
	}

	[HarmonyPatch(typeof(PushUpBricks), "OnTriggerStay")]
	public static class PushUpBrickPatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.PILLAR];
		}
	}

	[HarmonyPatch(typeof(LockRotate), "FixedUpdate")]
	public static class SpinBlockPatch
	{
		private static bool Prefix(LockRotate __instance)
		{
			if (ItemManager.itemUnlocks[ItemType.SPIN_HOLD_BLOCK])
				return true;

			__instance.Steeps[0].tag = "Untagged";
			__instance.Steeps[1].tag = "Untagged";
			__instance.Steeps[2].tag = "Untagged";
			__instance.Steeps[3].tag = "Untagged";
			__instance.Rot = __instance.Rotates[0].transform.eulerAngles.z % 360f;
			if (__instance.Rot > 180f)
			{
				__instance.Rot -= 360f;
			}

			if (__instance.Rot < 0f && __instance.Rot > -30f)
			{
				__instance.Steeps[0].tag = "SteepRight";
			}
			else if (__instance.Rot < -60f && __instance.Rot > -90f)
			{
				__instance.Steeps[1].tag = "SteepLeft";
			}
			else if (__instance.Rot < -90f && __instance.Rot > -120f)
			{
				__instance.Steeps[3].tag = "SteepRight";
			}
			else if (__instance.Rot < -150f && __instance.Rot > -180f)
			{
				__instance.Steeps[0].tag = "SteepLeft";
			}
			else if (__instance.Rot < 180f && __instance.Rot > 150f)
			{
				__instance.Steeps[2].tag = "SteepRight";
			}
			else if (__instance.Rot < 120f && __instance.Rot > 90f)
			{
				__instance.Steeps[3].tag = "SteepLeft";
			}
			else if (__instance.Rot < 90f && __instance.Rot > 60f)
			{
				__instance.Steeps[1].tag = "SteepRight";
			}
			else if (__instance.Rot < 30f && __instance.Rot > 0f)
			{
				__instance.Steeps[2].tag = "SteepLeft";
			}

			__instance.R += Time.fixedDeltaTime * __instance.Speed;
			if (__instance.R > 360f)
			{
				__instance.R -= 360f;
			}
			else if (__instance.R < -360f)
			{
				__instance.R += 360f;
			}

			for (int i = 0; i < __instance.Rotates.Length; i++)
			{
				__instance.Rotates[i].transform.localEulerAngles = new Vector3(0f, 0f, __instance.R);
			}

			__instance.SR.sprite = __instance.Inactive;

			return false;
		}
	}

	[HarmonyPatch(typeof(JungleRotatorsManual), "FixedUpdate")]
	public static class TreePatch
	{
		private static bool Prefix()
		{
			return ItemManager.itemUnlocks[ItemType.TREE];
		}
	}

	#endregion Items

	#region Menu

	[HarmonyPatch(typeof(FinalTitleButtons), "Update")]
	public static class TitleButtonUpdatePatch
	{
		private static bool Prefix(FinalTitleButtons __instance)
		{
			if (__instance.EnterSaveFile || __instance.EraseSaveFile)
			{
				__instance.gameObject.SetActive(false);
				Core.titleScreenTransitionObject = __instance.Transition;

				return false;
			}
			else if (Core.CropString(__instance.gameObject.name).Equals("Title_FileSelect_Erase"))
			{
				__instance.gameObject.SetActive(false);

				GameObject apSetupPanel = GameObject.Find("ApSetupPanel");
				if (apSetupPanel == null)
				{
					Core.fantasticFistFont = __instance.GetComponent<TextMesh>().font;
					Core.fantasticFistFontMaterials = __instance.GetComponent<MeshRenderer>().materials;

					Melon<Core>.Logger.Msg("Setting up ApSetupPanel");
					apSetupPanel = new GameObject("ApSetupPanel");
					apSetupPanel.transform.parent = __instance.transform.parent;
					apSetupPanel.transform.localPosition = new Vector3(0, 0, -10);
					apSetupPanel.transform.localScale = Vector3.one * .03f;

					var addressLabel = TextMeshSetup.Setup("AddressLabel", "Address", apSetupPanel);
					addressLabel.Item1.transform.localPosition = Vector3.up * 50;
					var addressTextBox = TextMeshSetup.Setup("AddressTextBox", "archipelago.gg:12345", apSetupPanel);
					addressTextBox.Item1.transform.localPosition = Vector3.up * 25;
					addressTextBox.Item2.color = Color.yellow;
					var slotNameLabel = TextMeshSetup.Setup("SlotNameLabel", "Slot Name", apSetupPanel);
					slotNameLabel.Item1.transform.localPosition = Vector3.up * 0;
					var slotNameTextBox = TextMeshSetup.Setup("SlotNameTextBox", "Player1", apSetupPanel);
					slotNameTextBox.Item1.transform.localPosition = Vector3.up * -25;
					var passwordLabel = TextMeshSetup.Setup("PasswordLabel", "Password", apSetupPanel);
					passwordLabel.Item1.transform.localPosition = Vector3.up * -50;
					var passwordTextBox = TextMeshSetup.Setup("SlotNameTextBox", "", apSetupPanel);
					passwordTextBox.Item1.transform.localPosition = Vector3.up * -75;
					var connectButton = TextMeshSetup.Setup("ConnectButton", "Connect", apSetupPanel);
					connectButton.Item1.transform.localPosition = Vector3.up * -100;

					if (File.Exists(Core.AP_SETUP_FILEPATH))
					{
						string dataToRead = File.ReadAllText(Core.AP_SETUP_FILEPATH);
						string[] splitDataToRead = dataToRead.Split('\n');
						if (splitDataToRead.Length == 3)
						{
							addressTextBox.Item2.text = splitDataToRead[0].Trim();
							slotNameTextBox.Item2.text = splitDataToRead[1].Trim();
							passwordTextBox.Item2.text = splitDataToRead[2].Trim();
						}
					}

					Core.apSetupPanel = apSetupPanel;
					Core.apSetupSelectedIndex = 0;
				}

				return false;
			}
			return true;
		}
	}

	public static class TextMeshSetup
	{
		public static (GameObject, TextMesh) Setup(string textMeshName, string text, GameObject parent)
		{
			GameObject textMeshGameObject = new GameObject(textMeshName);
			textMeshGameObject.transform.parent = parent.transform;
			textMeshGameObject.transform.localPosition = Vector3.zero;
			textMeshGameObject.transform.localScale = Vector3.one;
			TextMesh textMesh = textMeshGameObject.AddComponent<TextMesh>();
			textMesh.font = Core.fantasticFistFont;
			textMesh.text = text;
			textMesh.anchor = TextAnchor.MiddleCenter;
			MeshRenderer meshRenderer = textMeshGameObject.GetComponent<MeshRenderer>();
			meshRenderer.materials = Core.fantasticFistFontMaterials;

			return (textMeshGameObject, textMesh);
		}
	}

	[HarmonyPatch(typeof(ViviMap), "OnEnable")]
	public static class InitialViviMovePatch
	{
		public static void Prefix(ViviMap __instance)
		{
			PathManager.UpdatePathAccess();

			if (Core.viviMapInitialMove)
			{
				Global.Dataholder.MapWorld = 1f;
				__instance.CurrentLevel = Global.Dataholder.LevelList[0].MapPosition.GetComponent<LevelSelect>();
				__instance.transform.position = new Vector3(Global.Dataholder.LevelList[0].MapPosition.transform.position.x, Global.Dataholder.LevelList[0].MapPosition.transform.position.y + 0.3625f, Global.Dataholder.VVMap.transform.position.z);
				__instance.Honeyed = false;

				Core.viviMapInitialMove = false;

				if (__instance.PHold.Inside)
				{
					__instance.PHold.InsideTransition.transform.position = new Vector3(__instance.PHold.CPath.Dest.transform.position.x, __instance.PHold.CPath.Dest.transform.position.y, __instance.PHold.InsideTransition.transform.position.z);
					__instance.PHold.TransitionTimer = 0.5f;
					__instance.PHold.AffectInsideCover = true;
					__instance.PHold.Inside = false;
				}

				Melon<Core>.Logger.Msg("Moved Vivi to 1-1");
			}
		}
	}

	[HarmonyPatch(typeof(ViviMap), "Update")]
	public static class ViviMapPatch
	{
		public static bool Prefix(ViviMap __instance)
		{
			CoinLocationsUpdate.UpdateCoinLocations();

			if (Global.Dataholder.GetReboundInputDown(KeyCode.Space) && __instance.IdleAndAtLevel && __instance.CurrentLevel.Map != null && !Global.Dataholder.ReturningToTitle)
			{
				Int64 coinsNeededToAccessTheLevel = 0;
				switch(__instance.CurrentLevel.name)
				{
					case "Level7":
						coinsNeededToAccessTheLevel = (Int64)Core.slotData["boss_coin_req_0"];
						break;
					case "Level_16":
						coinsNeededToAccessTheLevel = (Int64)Core.slotData["boss_coin_req_1"];
						break;
					case "Level_27":
						coinsNeededToAccessTheLevel = (Int64)Core.slotData["boss_coin_req_2"];
						break;
					case "Level_38":
						coinsNeededToAccessTheLevel = (Int64)Core.slotData["boss_coin_req_3"];
						break;
					case "Level_43":
						coinsNeededToAccessTheLevel = (Int64)Core.slotData["boss_coin_req_4"];
						break;
				}

				if (ItemManager.worldItems[WorldItem.COIN] < coinsNeededToAccessTheLevel)
				{
					Core.instance.messageManager.AddMessageToQueue("Cannot enter boss stage. You have " + ItemManager.worldItems[WorldItem.COIN] + " coins, but need " + coinsNeededToAccessTheLevel + ".");
					return false;
				}
			}
			return true;
		}
	}

	[HarmonyPatch(typeof(GoalPillar), "OnTriggerStay")]
	public static class GoalPillarSecretPatchOnTriggerStay
	{
		public static bool Prefix(GoalPillar __instance, Collider other)
		{
			if (!__instance.SecretExitDoorPillar)
				return true;

			if (!(other.tag == "Player") || __instance.Goal.Active || (__instance.SkullFrog && (!__instance.SkullFrog || Global.Dataholder.Vivi.Touching_CGD <= 0)) || Global.Dataholder.Vivi.Fireworking)
			{
				return false;
			}

			int num = ItemManager.worldItems[WorldItem.COIN];
			if (num >= __instance.CoinRequirement)
			{
				__instance.SecretRoomRingMat.SetFloat("_Fill", 1f);
				__instance.Goal.Appear = true;
				__instance.Goal.Disappear = false;
				__instance.CoinReqTM.color = Color.black;
				__instance.CoinReqTM.GetComponent<MeshRenderer>().sortingOrder = 25;
			}
			else
			{
				__instance.NotEnoughTM.gameObject.SetActive(value: true);
				__instance.SecretRoomRingMat.SetColor("_Color", new Vector4(1f, 0f, 0f, 1f));
				__instance.CoinReqTM.color = new Vector4(1f, 0f, 0f, 1f);
			}

			return false;
		}
	}

	[HarmonyPatch(typeof(GoalPillar), "Update")]
	public static class GoalPillarSecretPatchUpdate
	{
		public static bool Prefix(GoalPillar __instance)
		{
			if (__instance.SecretExitDoorPillar)
			{
				int num = ItemManager.worldItems[WorldItem.COIN];
				if (num >= __instance.CoinRequirement)
				{
					__instance.CoinReqTM.text = "!";
				}
			}
			return false;
		}
	}

	[HarmonyPatch(typeof(GoalPillar), "Start")]
	public static class GoalPillarSecretPatchStart
	{
		public static bool Prefix(GoalPillar __instance)
		{
			if (__instance.SkullFrog)
			{
				return false;
			}

			if (Global.Dataholder.CurrentWorld != 7f)
			{
				__instance.SR.sprite = __instance.ColorByWorld[Mathf.RoundToInt(Global.Dataholder.CurrentWorld)];
			}
			else if (!Global.Dataholder.PauseFunction.IsGamePaused)
			{
				__instance.SR.sprite = null;
			}
			else
			{
				__instance.SR.sprite = __instance.ColorByWorld[0];
			}

			if (!Global.Dataholder.PauseFunction.IsGamePaused)
			{
				if (Global.Dataholder.CurrentLevel == 18)
				{
					__instance.SR.sprite = __instance.ColorByEdgeCase[0];
				}

				if (Global.Dataholder.CurrentLevel == 44 || Global.Dataholder.CurrentLevel == 10)
				{
					__instance.SR.sprite = __instance.ColorByEdgeCase[1];
				}
			}

			if (__instance.SecretExitDoorPillar)
			{
				string secret_index_order_string = Core.slotData["secret_exit_order"].ToString();
				string[] secret_index_order_split = secret_index_order_string.Split([ '\n', '\r', '\t', ' ', ',' ]);
				int[] secret_index_order = new int[]
				{
					int.Parse(secret_index_order_split[4].Trim()),
					int.Parse(secret_index_order_split[9].Trim()),
					int.Parse(secret_index_order_split[14].Trim()),
					int.Parse(secret_index_order_split[19].Trim()),
					int.Parse(secret_index_order_split[24].Trim()),
					int.Parse(secret_index_order_split[29].Trim()),
					int.Parse(secret_index_order_split[34].Trim())
				};
				int levelToFindIndexOf = -1;

				Melon<Core>.Logger.Msg("Secret exit's original coin req is " + __instance.SETD.CoinReq);
				Melon<Core>.Logger.Msg("Secret exit's next room index is " + __instance.SETD.NextRoomIndex);


				switch (__instance.SETD.CoinReq)
				{
					case 10:
						levelToFindIndexOf = 0;
						break;
					case 3:
						levelToFindIndexOf = 1;
						break;
					case 15:
						if (__instance.SETD.NextRoomIndex == 4)
							levelToFindIndexOf = 2;
						else if (__instance.SETD.NextRoomIndex == 3)
							levelToFindIndexOf = 4;
						break;
					case 20:
						levelToFindIndexOf = 3;
						break;
					case 30:
						levelToFindIndexOf = 5;
						break;
					case 100:
						levelToFindIndexOf = 6;
						break;
					default:
						return false;
				}

				for (int i = 0; i < secret_index_order.Length; ++i)
				{
					if (secret_index_order[i] == levelToFindIndexOf)
					{
						string req = "secret_coin_req_" + i;
						__instance.CoinRequirement = (int)((Int64)Core.slotData[req]);
					}
				}

				__instance.CoinReqTM.text = string.Empty + __instance.CoinRequirement;
				__instance.SecretRoomRingMat.SetColor("_Color", Color.white);
			}
			return false;
		}
	}

	[HarmonyPatch(typeof(LevelSelect), "Start")]
	public static class LevelSelectPatchStart
	{
		//Put each level select object into the cache
		public static void Prefix(LevelSelect __instance)
		{
			if (!GameCache.levelSelectNameToEntranceNameDict.ContainsKey(__instance.name))
				return;

			string levelId = GameCache.levelSelectNameToEntranceNameDict[__instance.name];

			GameCache.levelSelectDict[levelId] = __instance;
		}
	}

	[HarmonyPatch(typeof(LevelSelect), "EnterLevel")]
	public static class LevelSelectPatchEnterLevel
	{
		public static bool Prefix(LevelSelect __instance)
		{
			if (!GameCache.levelSelectNameToEntranceNameDict.ContainsKey(__instance.name))
				return false;

			string levelId = GameCache.levelSelectNameToEntranceNameDict[__instance.name];

			string trueLevelId = GameCache.entranceRandoTrueEntrances[levelId];
			LevelSelect trueLevel = GameCache.levelSelectDict[trueLevelId];

			Melon<Core>.Logger.Msg("Entering entrance " + levelId + " which has been randomized to " + trueLevelId);

			//Modified level loading procedure.

			if (Global.Dataholder.EnteringLevel < 6f)
			{
				return false;
			}

			Global.Dataholder.EnteringLevel = 0f;
			Global.Dataholder.OnTheMap = false;
			Global.Dataholder.InLevelTime = 0f;
			Global.Dataholder.ClearCoinIDsThisLevel();
			TwinCameraController component = Global.Dataholder.MainCamera.transform.parent.GetComponent<TwinCameraController>();
			component.VoidCam2.ResetProjectionMatrix();
			component.VoidCam2.projectionMatrix *= Matrix4x4.Scale(new Vector3(1f, -1f, 1f));
			Global.Dataholder.FistHolder.SetActive(value: true);
			Global.Dataholder.CompletedPageInLevel = false;
			Global.Dataholder.Vivi.RB.isKinematic = false;
			Global.Dataholder.SelectLevel = trueLevel;
			Global.Dataholder.LevelSpawn = trueLevel.LevelSpawn;
			Global.Dataholder.RepawnWithHoney = trueLevel.StartHoney;
			Global.Dataholder.Vivi.IsHoneyOnRespawn = trueLevel.StartHoney;
			Global.Dataholder.Vivi.ExitIceCube = true;
			Global.Dataholder.Vivi.SR.flipX = false;
			Global.Dataholder.FistMov.RB.gameObject.SetActive(value: false);
			Global.Dataholder.FistMov.IsLevelClear = false;
			Global.Dataholder.FistMov.FinalJustReturn = false;
			CameraMovement camMov = Global.Dataholder.CamMov;
			camMov.DestPos = new Vector3((camMov.MapCenters[Mathf.RoundToInt(Global.Dataholder.MapWorld)].transform.position.x + Global.Dataholder.ViviMap.transform.position.x) / 2f, camMov.MapCenters[Mathf.RoundToInt(Global.Dataholder.MapWorld)].transform.position.y, trueLevel.transform.position.z);
			Vector3 position = camMov.Target.transform.position;
			camMov.Target.transform.position = new Vector3(0f, 0f, camMov.Target.transform.position.z);
			Vector3 vector = camMov.Target.transform.position - position;
			Global.Dataholder.LevelMap.position += vector;
			Global.Dataholder.LevelSelect = false;
			trueLevel.Level = trueLevel.GetComponent<NewLevelPath>().level;
			Global.Dataholder.CurrentLevel = Mathf.RoundToInt(trueLevel.Level);
			Global.Dataholder.CurrentPlayingLevel = Mathf.RoundToInt(trueLevel.Level);
			Global.Dataholder.FistMov.transform.position = new Vector3(0f, 0f, -20f);
			bool flag = false;
			if (Global.Dataholder.ListOfReEnterLevelRooms[Global.Dataholder.CurrentPlayingLevel] > 0)
			{
				flag = true;
			}

			flag = false;
			trueLevel.LevelWhoopObject = UnityEngine.Object.Instantiate((!flag) ? trueLevel.LevelWhoop : trueLevel.ReEnterWhoop, new Vector3(__instance.transform.position.x, __instance.transform.position.y, -45f), __instance.transform.rotation);
			Global.Dataholder.LoadingLevelWhoop = trueLevel.LevelWhoopObject;
			NewLevelEnter component2 = trueLevel.LevelWhoopObject.GetComponent<NewLevelEnter>();
			component2.customOffset = new Vector3(0f, -1.5f, 0f);
			component2.Map = trueLevel.Map;
			if (Global.Dataholder.CurrentFile == -1f)
			{
				component2.Map = trueLevel.ImportedMap;
				Global.Dataholder.LevEditBG = trueLevel.ImportedBG;
			}

			if (Global.Dataholder.TheNotebook.CurrentRadio != null)
			{
				Global.Dataholder.TheNotebook.CurrentRadio.StopRadio();
			}

			trueLevel.MusicLoopControl.pitch = 1f;
			Global.Dataholder.MusicClip = trueLevel.MusicLoopControl;
			for (int i = 0; i < Global.Dataholder.TheNotebook.Soundtrack.Length; i++)
			{
				if (Global.Dataholder.TheNotebook.Soundtrack[i].Clip == trueLevel.MusicLoopControl)
				{
					Global.Dataholder.ListOfMusic[i] = true;
					Global.Dataholder.MEM.SetMusicFound(i);
					break;
				}
			}

			if (Global.Dataholder.CurrentFile == -1f)
			{
				component2.Music = trueLevel.ImportedSong;
			}

			trueLevel.ChosenDelay = trueLevel.IntroDelay;
			if (Global.Dataholder.CurrentFile == -1f)
			{
				trueLevel.ChosenDelay = trueLevel.ImportedDelay;
			}

			trueLevel.ChosenIntro = trueLevel.LevelIntro;
			if (Global.Dataholder.CurrentFile == -1f)
			{
				trueLevel.ChosenIntro = trueLevel.ImportedIntro;
			}

			trueLevel.LevelNameObject = UnityEngine.Object.Instantiate(trueLevel.LevelName, new Vector3(0.5f, 20f, -48f), trueLevel.transform.rotation);
			Global.Dataholder.LoadingLevelName = trueLevel.LevelNameObject;
			if (trueLevel.StartHoney)
			{
				trueLevel.LevelNameObject.GetComponent<IntroFall>().Honeyed = true;
			}

			Global.Dataholder.LevelIntroHoney = trueLevel.StartHoney;
			component2.MusicDelay = 5f - trueLevel.MusicLoopControl.IntroDuration;
			if (!flag)
			{
				LevelNameHolder component3 = trueLevel.LevelNameObject.gameObject.GetComponent<LevelNameHolder>();
				if (!Global.Dataholder.GermanLanguage)
				{
					component3.Row1 = trueLevel.NameRow1;
					component3.Row2 = trueLevel.NameRow2;
					component3.Row3 = trueLevel.NameRow3;
					component3.Row4 = trueLevel.NameRow4;
					component3.Row5 = trueLevel.NameRow5;
				}
				else
				{
					component3.Row1 = trueLevel.NameRowDE1;
					component3.Row2 = trueLevel.NameRowDE2;
					component3.Row3 = trueLevel.NameRowDE3;
					component3.Row4 = trueLevel.NameRowDE4;
					component3.Row5 = trueLevel.NameRowDE5;
				}

				if (Global.Dataholder.CurrentFile == -1f)
				{
					component3.Row1 = trueLevel.ImportedRow1;
					component3.Row2 = trueLevel.ImportedRow2;
					component3.Row3 = trueLevel.ImportedRow3;
					component3.Row4 = trueLevel.ImportedRow4;
					component3.Row5 = trueLevel.ImportedRow5;
				}

				GameObject gameObject = UnityEngine.Object.Instantiate(trueLevel.IntroFallObject, new Vector3(0f, 20f, -47f), trueLevel.transform.rotation);
				gameObject.GetComponent<IntroFall>().StartHeight = trueLevel.StartHeight;
				GameObject loadingLevelParticles = UnityEngine.Object.Instantiate(Global.Dataholder.LevelEnterParticleField, Vector3.zero, trueLevel.transform.rotation);
				Global.Dataholder.LoadingLevelParticles = loadingLevelParticles;
				Global.Dataholder.LevelEnterVivi = gameObject.transform;
				Global.Dataholder.Vivi.Deathh.DiedThisStage = false;
				if (trueLevel.StartHoney)
				{
					gameObject.GetComponent<IntroFall>().Honeyed = true;
				}
			}

			return false;
		}
	}

	[HarmonyPatch(typeof(LevelInfoTab), "Generate")]
	public static class LevelInfoTabPatch
	{
		public static bool Prefix(LevelInfoTab __instance, int c)
		{
			int d = GameCache.levelIdToLevelListIndexDict[GameCache.entranceRandoTrueEntrances[GameCache.levelListIndexToLevelIdDict[c]]];

			//Modified generate code

			__instance.LevelName.text = Global.Dataholder.LevelList[d].Name.Replace("#", " ");

			if (new List<int> {7, 16, 27, 38, 43 }.Contains(c))
			{
				Int64 bossCoinReq = -1;
				switch (c)
				{
					case 7:
						bossCoinReq = (Int64)Core.slotData["boss_coin_req_0"];
						break;
					case 16:
						bossCoinReq = (Int64)Core.slotData["boss_coin_req_1"];
						break;
					case 27:
						bossCoinReq = (Int64)Core.slotData["boss_coin_req_2"];
						break;
					case 38:
						bossCoinReq = (Int64)Core.slotData["boss_coin_req_3"];
						break;
					case 43:
						bossCoinReq = (Int64)Core.slotData["boss_coin_req_4"];
						break;
				}

				int coinAmt = ItemManager.worldItems[WorldItem.COIN];
				if (coinAmt < bossCoinReq)
				{
					__instance.LevelName.text += " (" + coinAmt + "/" + bossCoinReq + " Coins)";
				}
			}
			int num = Global.Dataholder.LevelList[d].Exits.Length;
			int num2 = Global.Dataholder.LevelList[d].Coins.Length;
			int num3 = Global.Dataholder.LevelList[d].Misc.Length;
			bool flag = true;
			int i;
			for (i = 0; i < __instance.InstExits.Length; i++)
			{
				UnityEngine.Object.Destroy(__instance.InstExits[i].gameObject);
			}

			for (i = 0; i < __instance.InstCoins.Length; i++)
			{
				UnityEngine.Object.Destroy(__instance.InstCoins[i].gameObject);
			}

			for (i = 0; i < __instance.InstPages.Length; i++)
			{
				UnityEngine.Object.Destroy(__instance.InstPages[i].gameObject);
			}

			i = 0;
			__instance.InstExits = new SpriteRenderer[num];
			__instance.InstCoins = new SpriteRenderer[num2];
			__instance.InstPages = new SpriteRenderer[num3];
			float num4 = 2f;

			for (; i < num; i++)
			{
				bool flag2 = false;
				if (i < Global.Dataholder.LevelList[d].SecretExits.Length)
				{
					flag2 = Global.Dataholder.LevelList[d].SecretExits[i];
				}

				GameObject gameObject = UnityEngine.Object.Instantiate(__instance.ItemPrefab, __instance.ExitHolder.transform.position + new Vector3((float)i * num4, 0f, 0f), __instance.transform.rotation, __instance.ExitHolder.transform);
				__instance.InstExits[i] = gameObject.GetComponent<SpriteRenderer>();

				if (LocationManager.IsLocationChecked(LocationManager.exitLocationDictionary[Global.Dataholder.LevelList[d].Exits[i]]))
				{
					__instance.InstExits[i].sprite = ((!flag2) ? __instance.ExitCheck : __instance.ExitCheck_S);
					continue;
				}

				__instance.InstExits[i].sprite = __instance.ExitUncheck;
				flag = false;
			}

			for (i = 0; i < num2; i++)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(__instance.ItemPrefab, __instance.CoinHolder.transform.position + new Vector3((float)i * num4, 0f, 0f), __instance.transform.rotation, __instance.CoinHolder.transform);
				__instance.InstCoins[i] = gameObject2.GetComponent<SpriteRenderer>();
				if (Global.Dataholder.ListOfCollectedCoins[Global.Dataholder.LevelList[d].Coins[i]])
				{
					__instance.InstCoins[i].sprite = __instance.CoinCheck;
					continue;
				}

				__instance.InstCoins[i].sprite = __instance.CoinUncheck;
				flag = false;
			}

			for (i = 0; i < num3; i++)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(__instance.ItemPrefab, __instance.PageHolder.transform.position + new Vector3((float)i * num4, 0f, 0f), __instance.transform.rotation, __instance.PageHolder.transform);
				__instance.InstPages[i] = gameObject3.GetComponent<SpriteRenderer>();
				if (Global.Dataholder.ListOfPages[Global.Dataholder.LevelList[d].Misc[i]])
				{
					__instance.InstPages[i].sprite = __instance.PageCheck;
					continue;
				}

				__instance.InstPages[i].sprite = __instance.PageUnCheck;
				flag = false;
			}

			i = 0;
			float num5 = 0f;
			num5 = (float)__instance.LevelName.text.Length / 3.2f + 2f;
			if ((float)(num * 2 - 2) > num5)
			{
				num5 = num * 2 - 2;
			}

			if ((float)(num2 * 2 - 2) > num5)
			{
				num5 = num2 * 2 - 2;
			}

			if ((float)(num3 * 2 - 2) > num5)
			{
				num5 = num3 * 2 - 2;
			}

			__instance.Scale = new Vector2(num5, __instance.Scale.y);
			__instance.Ribbon.enabled = flag;
			Color color = ((!flag) ? __instance.Default : __instance.Wow);
			for (i = 0; i < __instance.Tiles.Length; i++)
			{
				__instance.Tiles[i].color = color;
			}

			if (__instance.transform.position.y - Global.Dataholder.MainCamera.transform.position.y > 6f)
			{
				__instance.Tiles[9].transform.localPosition = new Vector3(0f, 3f, 0f);
				__instance.Tiles[9].transform.localEulerAngles = new Vector3(0f, 0f, 180f);
				__instance.transform.position -= new Vector3(0f, 8f, 0f);
				__instance.Flip = true;
			}
			else
			{
				__instance.Tiles[9].transform.localPosition = new Vector3(0f, -3f, 0f);
				__instance.Tiles[9].transform.localEulerAngles = Vector3.zero;
				__instance.Flip = false;
			}

			return false;
		}
	}

	[HarmonyPatch(typeof(RoomDoor), "Start")]
	public static class RoomDoorPatch
	{
		public static void Prefix(RoomDoor __instance)
		{
			if (Global.Dataholder.CurrentWorld == 7)
				Global.Dataholder.CurrentWorld = 1;
		}
	}

	#endregion Menu

	#region Locations

	[HarmonyPatch(typeof(Notebook), "Update")]
	public static class NotebookUpdatePatch
	{
		public static void Prefix(Notebook __instance)
		{
			for (int bestiaryEntry = 0; bestiaryEntry < 11; ++bestiaryEntry)
				Global.Dataholder.ListOfBestiary[bestiaryEntry] = true;
			for (int tutorialEntry = 0; tutorialEntry < 6; ++tutorialEntry)
			{
				Global.Dataholder.ListOfPages[tutorialEntry] = true;
				Global.Dataholder.ListOfClearedPages[tutorialEntry] = LocationManager.IsLocationChecked((Location)(200 + tutorialEntry));
			}

			if (__instance.Chapter == 4)
			{
				LocationManager.MarkLocationAsChecked((Location)(__instance.CurrentPage + 270));
			}
		}
	}

	[HarmonyPatch(typeof(EnterLevelFromNotebook), "Do")]
	public static class DisableEnterLevelFromNotebookPatch
	{
		public static bool Prefix()
		{
			Core.instance.messageManager.AddMessageToQueue("Cannot enter levels through the Notebook while playing Archipelago.");
			return false;
		}
	}

	[HarmonyPatch(typeof(ReplayPageInNotebook), "Do")]
	public static class ReplayPageButtonPatch
	{
		public static void Prefix(ReplayPageInNotebook __instance)
		{
			LocationManager.MarkLocationAsChecked((Location)(__instance.Note.CurrentPage + 206));
		}
	}

	[HarmonyPatch(typeof(PagesInLevels), "Update")]
	public static class TutorialPagePatch
	{
		public static void Prefix(PagesInLevels __instance)
		{
			if (__instance.InFront && Global.Dataholder.GetReboundInputDown(KeyCode.W))
			{
				Melon<Core>.Logger.Msg("Opened tutorial pannel " + __instance.ID);

				Location location;
				switch (__instance.ID)
				{
					case 0:
						if (GameObject.FindObjectsOfType<RoomDoor>().Length == 2)
						{
							location = Location.VERTICALITY_TUTORIAL_PANEL;
						}
						else if (GameObject.FindObjectsOfType<RoomDoor>().Length == 1)
						{
							location = Location.AUTUMNAL_AETHER_TUTORIAL_PANEL;
						}
						else
						{
							Melon<Core>.Logger.Msg("Invalid tutorial pannel!");
							return;
						}
						break;
					case 1:
						location = Location.THE_LIBRARY_TUTORIAL_PANEL_1;
						break;
					case 2:
						location = Location.THE_LIBRARY_TUTORIAL_PANEL_2;
						break;
					case 3:
						location = Location.THE_LIBRARY_TUTORIAL_PANEL_3;
						break;
					case 4:
						location = Location.FORGOTTEN_ARCHIVES_TUTORIAL_PANEL;
						break;
					case 5:
						location = Location.WELCOME_TO_THE_VOID_TUTORIAL_PANEL;
						break;
					default:
						return;
				}

				LocationManager.MarkLocationAsChecked(location);
			}
		}
	}

	[HarmonyPatch(typeof(FinishLevel), "OnTriggerEnter")]
	public static class GoalPatch
	{
		public static void Prefix(Collider other, FinishLevel __instance)
		{
			if (!(other.gameObject.tag == "fist") || !__instance.Active)
			{
				return;
			}

			if (__instance.Page)
			{
				LocationManager.MarkLocationAsChecked((Location)(Global.Dataholder.PlayingInsidePageID + 200));
			}
			else if (__instance.WonAlready)
			{
				return;
			}
			else if (__instance.DoorToSecretExit)
			{
				Melon<Core>.Logger.Msg("Exit is a door to a secret exit");
			}
			else if (__instance.LoadBearingRuby)
			{
				Melon<Core>.Logger.Msg("Exit is a Load bearing collectible");
			}
			else if (__instance.BossFightDoorLock)
			{
				Melon<Core>.Logger.Msg("Exit is a boss door");
			}
			else if (__instance.W2BossBubble)
			{
				Melon<Core>.Logger.Msg("Exit is a Number Bubble");
			}
			else
			{
				Melon<Core>.Logger.Msg("Exit found: " + __instance.Exit_ID);

				if (LocationManager.exitLocationDictionary.ContainsKey(__instance.Exit_ID))
					LocationManager.MarkLocationAsChecked(LocationManager.exitLocationDictionary[__instance.Exit_ID]);

				if (__instance.Exit_ID == 49 && (Int64)Core.slotData["goal"] == 1)
					LocationManager.SetGoal();
				else if (__instance.Exit_ID == 51 && (Int64)Core.slotData["goal"] == 2)
					LocationManager.SetGoal();
			}
		}
	}

	[HarmonyPatch(typeof(FistCoin), "OnTriggerEnter")]
	public static class CoinCollectPatch
	{
		public static void Prefix(FistCoin __instance, Collider other)
		{
			if (!__instance.IsDefinitelyARealCoin || __instance.NotActuallyACoin)
			{
				return;
			}

			if ((__instance.W3BossHeart && __instance.SisterHeart.DoOnce) || !(other.gameObject.tag == "fist") || !Global.Dataholder.IsCurrentlyInALevel || __instance.DoOnce || (!(other.name == "Fist") && !(other.name == "Beam")))
			{
				return;
			}

			if (Global.Dataholder.FistMov.VectorSpeed.magnitude == 0f)
			{
				return;
			}

			Melon<Core>.Logger.Msg("Coin collected: " + __instance.ID);

			if (LocationManager.coinLocationDictionary.ContainsKey(__instance.ID))
				LocationManager.MarkLocationAsChecked(LocationManager.coinLocationDictionary[__instance.ID]);
		}
	}

	[HarmonyPatch(typeof(FistCoin), "Start")]
	public static class CoinStartPatch
	{
		public static void Prefix()
		{
			CoinLocationsUpdate.UpdateCoinLocations();
		}
	}

	[HarmonyPatch(typeof(FistCoin), "FixedUpdate")]
	public static class CoinFixedUpdatePatch
	{
		public static void Prefix()
		{
			CoinLocationsUpdate.UpdateCoinLocations();
		}
	}

	public static class CoinLocationsUpdate
	{
		public static void UpdateCoinLocations()
		{
			foreach (var v in LocationManager.coinLocationDictionary)
			{
				Global.Dataholder.ListOfCollectedCoins[v.Key] = LocationManager.IsLocationChecked(v.Value);
			}
		}
	}

	[HarmonyPatch(typeof(BossOneFinal), "NextPhase")]
	public static class BossOnePatch
	{
		public static void Prefix(BossOneFinal __instance)
		{
			LocationManager.MarkLocationAsChecked((Location)(__instance.Phase + 300));
		}
	}

	[HarmonyPatch(typeof(W2Boss_Reznor), "Update")]
	public static class BossTwoPatch
	{
		public static void Prefix(W2Boss_Reznor __instance)
		{
			if (__instance.Bulbed && __instance.Heart == null && !__instance.PreBoss)
			{
				LocationManager.MarkLocationAsChecked((Location)(__instance.BossMan.Phase + 310));
			}
		}
	}

	[HarmonyPatch(typeof(Boss3OrangeBlueHeartManager), "Update")]
	public static class BossThreePatch
	{
		public static void Prefix(Boss3OrangeBlueHeartManager __instance)
		{
			if (!__instance.PreHeart && __instance.Appearing)
			{
				Location boss3HeartLocation;
				switch (__instance.BossMan.mode)
				{
					case 0:
						boss3HeartLocation = Location.THE_THRONE_ROOM_HEART_1;
						break;
					case 1:
						boss3HeartLocation = Location.THE_THRONE_ROOM_HEART_2;
						break;
					case 2:
						boss3HeartLocation = Location.THE_THRONE_ROOM_HEART_3;
						break;
					default:
						return;
				}

				LocationManager.MarkLocationAsChecked(boss3HeartLocation);
			}
		}
	}

	[HarmonyPatch(typeof(GolfHole), "OnTriggerEnter")]
	public static class BossFourPatch
	{
		public static void Prefix (GolfHole __instance, Collider other)
		{
			if ((bool)other.gameObject.GetComponent<GolfBall>() && __instance.GolfBall == null && !Global.Dataholder.IsInLevelEditor)
			{
				LocationManager.MarkLocationAsChecked((Location)(Global.Dataholder.Room + 329));
			}
		}
	}

	[HarmonyPatch(typeof(GolfLeaderboards), "Start")]
	public static class GolfLeaderboardResetPatch
	{
		public static void Prefix()
		{
			int golfAmt = Global.Dataholder.Room == 0 ? 10 : 0;

			for (int hole = 0; hole < 9; ++hole)
			{
				PlayerPrefs.SetInt("GolfRecord_" + Global.Dataholder.CurrentFile + "_Hole:" + hole, golfAmt);
			}
		}
	}

	[HarmonyPatch(typeof(Boss5_32_Manager), "OnTriggerEnter")]
	public static class BossFivePartThirtyTwoPatch
	{
		public static void Prefix(Boss5_32_Manager __instance, Collider other)
		{
			if (!__instance.DoOnce && __instance.Health <= 0 && ((other.tag == "Fist") || (other.tag == "fist")))
			{
				LocationManager.MarkLocationAsChecked(Location.GALACTIC_CENTRAL_POINT_HEART_32);
			}
		}
	}

	[HarmonyPatch(typeof(FinalBoss_49_Manager), "OnTriggerEnter")]
	public static class BossFivePartFortyNinePatch
	{
		public static void Prefix(FinalBoss_49_Manager __instance, Collider other)
		{
			if ((!(other.tag == "Fist") && !(other.tag == "fist")) || __instance.Health > 0 || Global.Dataholder.Vivi.Deathh.PerformingDeathSequence || __instance.DoOnce)
			{
				return;
			}

			LocationManager.MarkLocationAsChecked(Location.GALACTIC_CENTRAL_POINT_HEART_49);
		}
	}

	[HarmonyPatch(typeof(Boss5_37_Bossman), "OnTriggerEnter")]
	public static class BossFivePartThirtySevenPatch
	{
		public static void Prefix(Boss5_37_Bossman __instance, Collider other)
		{
			if ((!(other.tag == "Fist") && !(other.tag == "fist")) || __instance.Health > 0 || Global.Dataholder.Vivi.Deathh.PerformingDeathSequence || __instance.DoOnce)
			{
				return;
			}

			FistMovement fistMov = Global.Dataholder.FistMov;
			if (fistMov.VectorSpeed.magnitude == 0f)
			{
				return;
			}

			LocationManager.MarkLocationAsChecked(Location.GALACTIC_CENTRAL_POINT_HEART_37);
		}
	}

	[HarmonyPatch(typeof(Boss5_FinaleHeart), "PAAAAAAAAANCH")]
	public static class BossFiveFinalePatch
	{
		public static void Prefix(Boss5_FinaleHeart __instance)
		{
			if (__instance.Health <= 1)
			{
				LocationManager.MarkLocationAsChecked(Location.GALACTIC_CENTRAL_POINT_LEVEL_CLEAR);

				if ((Int64)Core.slotData["goal"] == 0)
					LocationManager.SetGoal();
			}
		}
	}

	#endregion Locations
	/*[HarmonyPatch(typeof(LevelSelect), "EnterLevel")]
	public static class LevelSelectPatch
	{
		private static void Prefix(LevelSelect __instance)
		{
			Melon<Core>.Logger.Msg(__instance.LevelObject.name);
		}
	}*/
}
