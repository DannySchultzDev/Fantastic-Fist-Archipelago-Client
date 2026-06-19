using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using static MelonLoader.MelonLogger;

namespace Fantastic_Fist_Archipelago_Client
{
	//Test message statement:
	//Melon<Core>.Logger.Msg("TEST MESSAGE");

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
				case "W41x1H":
					type = ItemType.PHYSICS_BLOCK_STANDARD;
					break;
				case "W41x1":
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
			else if (type == ItemType.BALLOON_LEAD ||  type == ItemType.BALLOON_TOGGLE)
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

			for (int childId = 0; childId < __instance.transform.childCount; ++childId )
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

	/*[HarmonyPatch(typeof(LevelSelect), "EnterLevel")]
	public static class LevelSelectPatch
	{
		private static void Prefix(LevelSelect __instance)
		{
			Melon<Core>.Logger.Msg(__instance.LevelObject.name);
		}
	}*/
}
