using MelonLoader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[assembly: MelonInfo(typeof(Fantastic_Fist_Archipelago_Client.Core), "Fantastic Fist Archipelago Client", "1.0.0", "WaluigiGoesWa", null)]
[assembly: MelonGame("100th Coin", "Fantastic Fist")]

namespace Fantastic_Fist_Archipelago_Client
{
    public class Core : MelonMod
    {
		//Melon Loader Wiki: https://melonwiki.xyz/#/

		public static Core instance = null;

        //List that can be set by pressing P or O.
        //Can be used by pressing V to get components of a specific object (object name in clipboard).
        public List<GameObject> gameObjectsInScene = new List<GameObject>();

        private bool debugMode = false;

        public static int debugValue = 0;

        public static bool useTestItems;
        public static readonly string useTestItemsKey = "Software\\Fantastic Fist Archipelago Client\\Test Item Types";

		private Vector3 gateway = Vector3.zero;

        private MessageManager messageManager = new MessageManager();

		public override void OnInitializeMelon()
        {
            instance = this;

            LoggerInstance.Msg("Melonloader has initialized.");

            if (Registry.CurrentUser.OpenSubKey(useTestItemsKey, true) != null)
            {
                LoggerInstance.Msg("Using test items.");
                RevertTestItems();
			}
            else
            {
				foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
				{
                    ItemManager.itemUnlocks[itemType] = false;
				}
			}

            LocationManager.InitializeLocations();
		}

		private int GetTestItemTypeValueFromRegistry(ItemType itemType)
        {
			RegistryKey key = Registry.CurrentUser.OpenSubKey(useTestItemsKey, true);

            int keyValue = (int)key.GetValue(itemType.ToString(), 0);

            key.SetValue(itemType.ToString(), keyValue);

            return keyValue;
        }

        private void RevertTestItems()
        {
			LoggerInstance.Msg("Reverting items.");
            messageManager.AddMessageToQueue("Reverting Items.");
            ItemManager.itemUnlocks.Clear();
			foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
			{
				int itemTypeValue = GetTestItemTypeValueFromRegistry(itemType);
				ItemManager.itemUnlocks.Add(itemType, itemTypeValue == 11);
			}
		}

		public override void OnFixedUpdate()
		{
			Locker.UpdateLockAllGameObjects();

            messageManager.UpdateSimulator();
		}

		public override void OnUpdate()
		{
		}

		public override void OnLateUpdate()
        {
            //Print out objects in the active room.
            //Stores game objects for later use.
            if (Input.GetKeyDown(KeyCode.I))
            {
                PrintOutAndStoreActiveRoom("ActiveRoom");
            }

            //Print out solids in the active room.
            //Stores game objects for later use.
            if (Input.GetKeyDown(KeyCode.K))
            {
                PrintOutAndStoreActiveRoom("ActiveRoomSolids");
            }

            //Print out active objects.
            //Stores game objects for later use.
            if (Input.GetKeyDown(KeyCode.P))
            {
                PrintOutAndStoreGameObjects(false);
            }
            //Print out all objects.
            //Stores game objects for later use.
            if (Input.GetKeyDown(KeyCode.O))
            {
                PrintOutAndStoreGameObjects(true);
            }

            //Gets the components of the object in your clipboard.
            if (Input.GetKeyDown(KeyCode.V))
            {
                PrintComponentsFromClipboardObject(false);
            }

            //Gets the components of the object in your clipboard.
            //Also gets the children and children's components of the object.
            if (Input.GetKeyDown(KeyCode.B))
            {
                PrintComponentsFromClipboardObject(true);
            }

            //Toggle the active state of the objects in your clipboard.
            if (Input.GetKeyDown(KeyCode.T))
            {
                ToggleClipboardObject();
            }

            //Enable Debug Mode
            if (Input.GetKeyDown(KeyCode.Period))
            {
                if (!debugMode)
                {
					LoggerInstance.Msg("Turned debug mode on");
                    messageManager.AddMessageToQueue("Turned debug mode on");
					GameObject.Find("Player").GetComponent<Vivi_movement>().Deathh.DebugInvuln = true;
                    debugMode = true;
				}
                else
                {
                    LoggerInstance.Msg("Turned debug mode off");
					messageManager.AddMessageToQueue("Turned debug mode off");
					GameObject.Find("Player").GetComponent<Vivi_movement>().Deathh.DebugInvuln = false;
                    debugMode = false;
                }
            }

            //Gateway
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
				GameObject.Find("Player").transform.position = gateway;
				LoggerInstance.Msg("Gateway used");
                messageManager.AddMessageToQueue("Gateway used");
			}
            if (Input.GetKeyDown (KeyCode.DownArrow))
            {
                gateway = GameObject.Find("Player").transform.position;
				LoggerInstance.Msg("Gateway set");
                messageManager.AddMessageToQueue("Gateway set");
			}

            //Change Debug Value
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ++debugValue;
                LoggerInstance.Msg("Debug value is now " + debugValue);
                messageManager.AddMessageToQueue("Debug value is now " + debugValue);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                --debugValue;
                LoggerInstance.Msg("Debug value is now " + debugValue);
				messageManager.AddMessageToQueue("Debug value is now " + debugValue);
			}

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                ToggleItems(0);
            }
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				ToggleItems(1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				ToggleItems(2);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				ToggleItems(3);
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				ToggleItems(4);
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				ToggleItems(5);
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				ToggleItems(6);
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				ToggleItems(7);
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				ToggleItems(8);
			}
			if (Input.GetKeyDown(KeyCode.Alpha9))
			{
				ToggleItems(9);
			}
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                RevertTestItems();
            }
		}

        private void ToggleItems(int toggleValue)
        {
			LoggerInstance.Msg("Toggling items of value " + toggleValue.ToString() + ".");
			foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
			{
				int itemTypeValue = GetTestItemTypeValueFromRegistry(itemType);
				if (itemTypeValue == toggleValue)
                {
                    LoggerInstance.Msg("Turning " + itemType.ToString() + " " + (ItemManager.itemUnlocks[itemType] ? "off" : "on"));
                    messageManager.AddMessageToQueue("Turning " + itemType.ToString() + " " + (ItemManager.itemUnlocks[itemType] ? "off" : "on"));
                    ItemManager.itemUnlocks[itemType] = !ItemManager.itemUnlocks[itemType];
                }
			}
		}

        private void PrintOutAndStoreActiveRoom(string target)
        {
            gameObjectsInScene.Clear();
            GameObject activeRoom = GameObject.Find(target);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Printing all objects in the active room:");
			for (int gameObjectID = 0;  gameObjectID < activeRoom.transform.childCount; ++gameObjectID)
			{
                GameObject gameObject = activeRoom.transform.GetChild(gameObjectID).gameObject;
                gameObjectsInScene.Add(gameObject);
                sb.AppendLine(CropString(gameObject.name));
			}
			LoggerInstance.Msg(sb.ToString());
		}

        private void PrintOutAndStoreGameObjects(bool all)
        {
            gameObjectsInScene.Clear();

			GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Printing all objects in the active scene:");
			foreach (GameObject gameObject in gameObjects)
			{
				GetAndStoreRecursiveChildren(gameObject, sb, 0, all);
			}
			LoggerInstance.Msg(sb.ToString());
		}

        public void StoreGameObjects(bool all = true)
        {
			gameObjectsInScene.Clear();

			GameObject[] gameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
			foreach (GameObject gameObject in gameObjects)
			{
				GetAndStoreRecursiveChildren(gameObject, null, 0, all);
			}
		}

        private void GetAndStoreRecursiveChildren(GameObject gameObject, StringBuilder sb, int depth, bool all)
        {
            if (!all && !gameObject.activeSelf)
                return;

            gameObjectsInScene.Add(gameObject);

            if (sb != null)
            {
                sb.AppendLine();
                for (int spaces = 0; spaces < depth; ++spaces)
                {
                    sb.Append("|");
                }
                sb.Append("Name: " + CropString(gameObject.name) + " Position: " + gameObject.transform.position.ToString());
            }
            for (int childID = 0; childID < gameObject.transform.childCount; ++childID)
            {
                GetAndStoreRecursiveChildren(gameObject.transform.GetChild(childID).gameObject, sb, depth + 1, all);
            }
        }

        private void PrintComponentsFromClipboardObject(bool includeChildren)
        {
            string clipboardValue = GUIUtility.systemCopyBuffer;
            LoggerInstance.Msg("Printing components of " + clipboardValue);
            if (clipboardValue == null)
                return;

            foreach(GameObject gameObject in gameObjectsInScene)
            {
                if (gameObject == null)
                    continue;

                if (clipboardValue.Equals(CropString(gameObject.name)))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(CropString(gameObject.name) + " contains:");
                    foreach (Component component in gameObject.GetComponents<Component>())
                    {
                        sb.AppendLine(component.ToString());
                    }
                    if (includeChildren)
                    {
                        for (int childId = 0; childId < gameObject.transform.childCount; ++childId)
                        {
                            GetRecursiveChildComponents(gameObject.transform.GetChild(childId).gameObject,
                                sb, childId.ToString());
                        }
                    }

                    LoggerInstance.Msg(sb.ToString());
                }
            }
		}

        private void GetRecursiveChildComponents(GameObject gameObject, StringBuilder sb, string gameObjectId)
        {
            sb.AppendLine("Child: " + gameObjectId + " Name: " + CropString(gameObject.name));
			foreach (Component component in gameObject.GetComponents<Component>())
			{
				sb.AppendLine(component.ToString());
			}

			for (int childId = 0; childId < gameObject.transform.childCount; ++childId)
			{
                GetRecursiveChildComponents(gameObject.transform.GetChild(childId).gameObject, 
                    sb, gameObjectId + "." + childId.ToString());
			}
		}

        private void ToggleClipboardObject()
        {
			string clipboardValue = GUIUtility.systemCopyBuffer;
			LoggerInstance.Msg("Toggling " + clipboardValue);
			if (clipboardValue == null)
				return;

			foreach (GameObject gameObject in gameObjectsInScene)
			{
				if (gameObject == null)
					continue;

				if (clipboardValue.Equals(CropString(gameObject.name)))
				{
					if (gameObject.activeSelf)
                    {
                        LoggerInstance.Msg("Turning off " + CropString(gameObject.name));
                        gameObject.SetActive(false);
                    }
                    else
                    {
						LoggerInstance.Msg("Turning on " + CropString(gameObject.name));
						gameObject.SetActive(true);
					}
				}
			}
		}

        public static string CropString(string uncroppedString)
        {
            return uncroppedString.Split('(')[0].Trim();
		}
	}
}