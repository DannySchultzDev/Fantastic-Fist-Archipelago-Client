using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using MelonLoader;
using Microsoft.Win32;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Selectable;

[assembly: MelonInfo(typeof(Fantastic_Fist_Archipelago_Client.Core), "Fantastic Fist Archipelago Client", "0.0.3", "WaluigiGoesWa", null)]
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

        public MessageManager messageManager = new MessageManager();

        private bool testMode = false;

        public static Font fantasticFistFont = null;
        public static Material[] fantasticFistFontMaterials = null;

        public static GameObject titleScreenTransitionObject = null;

        public static GameObject apSetupPanel = null;
        public static int apSetupSelectedIndex = 0;
        public static readonly string AP_SETUP_FOLDERPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FantasticFistArchipelagoClient");
        public static readonly string AP_SETUP_FILEPATH = Path.Combine(AP_SETUP_FOLDERPATH, "Connection Info.txt");

        public static bool hasSession = false;
        private static bool gettingSession = false;
        public static ArchipelagoSession session = null;
        public static Dictionary<string, System.Object> slotData = new Dictionary<string, System.Object>();
        private string address = "";
        public string name = "";
        private string password = "";
        private int currRetry = -1;
        private float timeBeforeRetry = -1;

        public static bool viviMapInitialMove = false;

		public override void OnInitializeMelon()
        {
            instance = this;

            LoggerInstance.Msg("Melonloader has initialized.");

            if (Registry.CurrentUser.OpenSubKey(useTestItemsKey, true) != null)
            {
                LoggerInstance.Msg("Using test items.");
                testMode = true;
                RevertTestItems();
			}
            else
            {
                ItemManager.InitializeItems();
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

			if (hasSession && (session == null || !session.Socket.Connected))
			{
				hasSession = false;
				messageManager.AddMessageToQueue("Connection lost");
                if (!TryConnection())
                {
                    currRetry = 0;
                    timeBeforeRetry = 30.0f;
                }
			}

            if (currRetry > -1)
            {
                timeBeforeRetry -= Time.deltaTime;
                if (timeBeforeRetry < 0)
                {
                    if (!TryConnection())
                    {
                        ++currRetry;
                        timeBeforeRetry = 30.0f * Mathf.Pow(2, currRetry);
                    }
                }
            }
		}

		public override void OnUpdate()
		{
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //Test action.

                //messageManager.ClearQueue();

				LoggerInstance.Msg("Test action completed successfully");
			}

			if (apSetupPanel != null)
				HandleApSetupPanel();
		}

		private void HandleApSetupPanel()
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (apSetupSelectedIndex != 0)
                {
                    GameObject oldSelect;
                    GameObject newSelect;
                    switch (apSetupSelectedIndex)
                    {
                        case 1:
                            oldSelect = apSetupPanel.transform.GetChild(3).gameObject;
                            newSelect = apSetupPanel.transform.GetChild(1).gameObject;
                            break;
                        case 2:
							oldSelect = apSetupPanel.transform.GetChild(5).gameObject;
							newSelect = apSetupPanel.transform.GetChild(3).gameObject;
							break;
						case 3:
							oldSelect = apSetupPanel.transform.GetChild(6).gameObject;
							newSelect = apSetupPanel.transform.GetChild(5).gameObject;
                            break;
                        default:
                            throw new Exception();
					}
                    oldSelect.GetComponent<TextMesh>().color = UnityEngine.Color.white;
                    newSelect.GetComponent<TextMesh>().color = UnityEngine.Color.yellow;
                    
                    --apSetupSelectedIndex;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
				if (apSetupSelectedIndex != 3)
				{
					GameObject oldSelect;
					GameObject newSelect;
					switch (apSetupSelectedIndex)
					{
						case 0:
							oldSelect = apSetupPanel.transform.GetChild(1).gameObject;
							newSelect = apSetupPanel.transform.GetChild(3).gameObject;
							break;
						case 1:
							oldSelect = apSetupPanel.transform.GetChild(3).gameObject;
							newSelect = apSetupPanel.transform.GetChild(5).gameObject;
							break;
						case 2:
							oldSelect = apSetupPanel.transform.GetChild(5).gameObject;
							newSelect = apSetupPanel.transform.GetChild(6).gameObject;
							break;
						default:
							throw new Exception();
					}
					oldSelect.GetComponent<TextMesh>().color = UnityEngine.Color.white;
					newSelect.GetComponent<TextMesh>().color = UnityEngine.Color.yellow;

					++apSetupSelectedIndex;
				}
			}
            else if (apSetupSelectedIndex == 3)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                {
					address = apSetupPanel.transform.GetChild(1).gameObject.GetComponent<TextMesh>().text;
					name = apSetupPanel.transform.GetChild(3).gameObject.GetComponent<TextMesh>().text;
					password = apSetupPanel.transform.GetChild(5).gameObject.GetComponent<TextMesh>().text;

					TryConnection();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                TextMesh textMesh;
                switch (apSetupSelectedIndex)
                {
                    case 0:
                        textMesh = apSetupPanel.transform.GetChild(1).gameObject.GetComponent<TextMesh>();
                        break;
					case 1:
						textMesh = apSetupPanel.transform.GetChild(3).gameObject.GetComponent<TextMesh>();
						break;
					case 2:
						textMesh = apSetupPanel.transform.GetChild(5).gameObject.GetComponent<TextMesh>();
						break;
					default:
                        throw new Exception();
                }

                //Can't backspase an empty string
                if (textMesh.text.Length == 0)
                    return;

                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                    textMesh.text = string.Empty;
                else
                    textMesh.text = textMesh.text.Substring(0, textMesh.text.Length - 1);
            }
            else if (Input.anyKeyDown && !string.IsNullOrEmpty(Input.inputString))
            {
                char typedChar = Input.inputString[0];

                if (char.IsLetterOrDigit(typedChar) || typedChar == ':' || typedChar == '.')
                {
					TextMesh textMesh;
					switch (apSetupSelectedIndex)
					{
						case 0:
							textMesh = apSetupPanel.transform.GetChild(1).gameObject.GetComponent<TextMesh>();
							break;
						case 1:
							textMesh = apSetupPanel.transform.GetChild(3).gameObject.GetComponent<TextMesh>();
							break;
						case 2:
							textMesh = apSetupPanel.transform.GetChild(5).gameObject.GetComponent<TextMesh>();
							break;
						default:
							throw new Exception();
					}

                    textMesh.text = textMesh.text + typedChar;
				}
            }
		}

		private bool TryConnection()
		{
            if (session != null)
            {
                session.Socket.Disconnect();
                session = null;
            }

            session = ArchipelagoSessionFactory.CreateSession(address);

            session.Items.ItemReceived += ItemReceived;
            ItemManager.InitializeItems();
            LocationManager.InitializeLocations();

            gettingSession = true;

            LoginResult loginResult = session.TryConnectAndLogin(
                "Fantastic Fist",
                name,
                Archipelago.MultiClient.Net.Enums.ItemsHandlingFlags.AllItems,
                new System.Version(0, 6, 7),
                null,
                null,
                password,
                true);

            gettingSession = false;

            messageManager.AddMessageToQueue("Connection " + (loginResult.Successful ? "successful" : "unsuccessful"));
            
            if (!loginResult.Successful)
                return false;

            string dataToSave = address + "\r\n" + name + "\r\n" + password;

            Directory.CreateDirectory(AP_SETUP_FOLDERPATH);
            File.WriteAllText(AP_SETUP_FILEPATH, dataToSave);

            slotData = ((LoginSuccessful)loginResult).SlotData;
            GameCache.UpdateEntranceRando();

            if (Global.Dataholder.OnTheTitle)
            {
				Global.Dataholder.OnTheTitle = false;
				Global.Dataholder.EnteringNewFile = false;
				Global.Dataholder.ValidSpeedrun = false;

				UnityEngine.Object.Instantiate(titleScreenTransitionObject, Vector3.zero, Quaternion.identity, Global.Dataholder.MainCamera.transform);

                //Move Vivi to level 1
                viviMapInitialMove = true;

				Global.Dataholder.CurrentFile = 4;
				Global.Dataholder.ReturningToMap = true;
				Global.Dataholder.PauseFunction.IsGamePaused = false;
				Global.Dataholder.PauseFunction.PauseUnpauseFix = false;

			}

			hasSession = true;
            currRetry = -1;
            timeBeforeRetry = -1;

            LocationManager.PrecheckedLocations(session.Locations.AllLocationsChecked.ToArray());
            //LocationManager.roomsanity = (bool)slotData["roomsanity"];
            //LocationManager.checkpointsanity = (bool)slotData["checkpointsanity"];

            PathManager.goalIsHome = (Int64)slotData["goal"] == 2;
            PathManager.openWorldType = (OpenWorldType)(((Int64)slotData["open_world"]));

			session.Locations.ScoutLocationsAsync(LocationManager.ScoutedMissingLocations, HintCreationPolicy.None, session.Locations.AllMissingLocations.ToArray());

			return true;
		}

		private void ItemReceived(ReceivedItemsHelper helper)
		{
            while (helper.PeekItem() != null)
            {
                ItemInfo itemInfo = helper.DequeueItem();
                if (!gettingSession)
                    messageManager.AddMessageToQueue("Received your " + itemInfo.ItemName);
                ItemManager.ReceivedWorldItem((WorldItem)itemInfo.ItemId);
            }
		}

		public override void OnLateUpdate()
        {
            if (!testMode)
                return;

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

            //Move the first copy of a selected object to the players position.
            if (Input.GetKeyDown(KeyCode.M))
            {
                MoveClipboardObject(true);
            }
            //Move the first copy of a selected object to the gateways position.
            if (Input.GetKeyDown(KeyCode.N))
            {
                MoveClipboardObject(false);
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

        private void MoveClipboardObject(bool toPlayer)
        {
			string clipboardValue = GUIUtility.systemCopyBuffer;
			LoggerInstance.Msg("Moving " + clipboardValue);
			if (clipboardValue == null)
				return;

            StoreGameObjects(toPlayer);
            GameObject gameObjectToMove = null;
            foreach (GameObject gameObject in gameObjectsInScene)
            {
                if (gameObject == null)
                    continue;

                if (clipboardValue.Equals(CropString(gameObject.name)))
                {
                    gameObjectToMove = gameObject;
                    break;
                }
            }
            Vector3 targetPos = toPlayer ? GameObject.Find("Player").transform.position : gateway;

            gameObjectToMove.transform.position = targetPos;
		}


		public static string CropString(string uncroppedString)
        {
            return uncroppedString.Split('(')[0].Trim();
		}
	}
}