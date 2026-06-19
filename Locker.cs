using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class Locker
	{
		public static List<GameObject> gameObjects = new List<GameObject>();

		public static void UpdateLockAllGameObjects()
		{
			gameObjects.RemoveAll(item => item == null);

			foreach (GameObject gameObject in gameObjects)
			{
				string gameObjectName = Core.CropString(gameObject.name);
				try
				{
					switch (gameObjectName)
					{
						case "Quatrafoil_Alt":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.GRAVITY_FIELD_UP]);
							break;
						case "Quatrafoil":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.GRAVITY_FIELD_DOWN]);
							break;
						case "Reflection Honey_Infinite":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.GRAVITY_WATER_UP]);
							break;
						case "Reflection_Infinite":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.GRAVITY_WATER_DOWN]);
							break;
						case "Mod_PropBlock_Blue":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.SEMISOLID_STANDARD]);
							break;
						case "Mod_PropBlock_Pink":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.SEMISOLID_INVERTED]);
							break;
						case "Mod_PropBlock_Punch":
							gameObject.SetActive(ItemManager.itemUnlocks[ItemType.SEMISOLID_TOGGLE]);
							break;
					}
				}
				catch (Exception ex)
				{
					Melon<Core>.Logger.Error("Could not update due to this object: " + gameObjectName + "\n" + ex.Message);
				}
			} 
		}
	}
}
