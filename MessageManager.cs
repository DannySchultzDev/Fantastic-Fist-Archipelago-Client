using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Fantastic_Fist_Archipelago_Client
{
	public class MessageManager
	{
		private Text label = null;

		private Queue<string> messageQueue = new Queue<string>();
		private string currMessage = null;
		private DateTime currMessageStartTime = DateTime.MinValue;

		public MessageManager() { }

		public void UpdateSimulator()
		{
			if (label == null)
			{
				GameObject canvasObj = new GameObject("Fantastic Fist Archipelago Client Message Canvas");

				GameObject[] roots = SceneManager.GetActiveScene().GetRootGameObjects();
				if (roots == null || roots.Length <= 0)
					return;
				else
					canvasObj.transform.parent = roots[0].transform;

				Canvas canvas = canvasObj.AddComponent<Canvas>();
				canvas.renderMode = RenderMode.ScreenSpaceOverlay;
				canvasObj.AddComponent<CanvasScaler>();
				canvasObj.AddComponent<GraphicRaycaster>();

				GameObject textObj = new GameObject("Label");
				textObj.transform.SetParent(canvasObj.transform);
				label = textObj.AddComponent<Text>();
				label.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				label.fontSize = 48;
				label.color = Color.white;
				label.alignment = TextAnchor.MiddleCenter;

				RectTransform rect = label.GetComponent<RectTransform>();
				rect.anchorMin = new Vector2(0.5f, 0f);
				rect.anchorMax = new Vector2(0.5f, 0f);
				rect.pivot = new Vector2(.5f, .5f);
				rect.sizeDelta = new Vector2(1400, 200);
				rect.anchoredPosition = new Vector2(0, 100);
			}

			float alpha = 0f;

			if (currMessage == null)
			{
				if (messageQueue.Count > 0)
				{
					currMessage = messageQueue.Dequeue();
					label.text = currMessage;
					currMessageStartTime = DateTime.Now;
					if (Core.fantasticFistFont != null &&
						label.font != Core.fantasticFistFont)
						label.font = Core.fantasticFistFont;
				}
			}
			
			if (currMessage != null)
			{
				int totalLifespan = -1;
				int fadeDur = -1;
				if (messageQueue.Count > 40)
				{
					totalLifespan = 100;
					fadeDur = 0;
				}
				else if (messageQueue.Count > 30)
				{
					totalLifespan = 250;
					fadeDur = 75;
				}
				else if (messageQueue.Count > 20)
				{
					totalLifespan = 500;
					fadeDur = 100;
				}
				else if (messageQueue.Count > 10)
				{
					totalLifespan = 1000;
					fadeDur = 150;
				}
				else if (messageQueue.Count > 5)
				{
					totalLifespan = 1500;
					fadeDur = 200;
				}
				else
				{
					totalLifespan = 2000;
					fadeDur = 200;
				}


				TimeSpan currTime = DateTime.Now - currMessageStartTime;
				int totalTimeMiliseconds = (currTime.Seconds * 1000) + currTime.Milliseconds;
				if (totalTimeMiliseconds < fadeDur)
					alpha = totalTimeMiliseconds / (float)fadeDur;
				else if (totalTimeMiliseconds > totalLifespan)
				{
					alpha = 0;
					currMessage = null;
				}
				else if (totalTimeMiliseconds > totalLifespan - fadeDur)
					alpha = (totalLifespan - totalTimeMiliseconds) / (float)fadeDur;
				else
					alpha = 1;
			}

			label.color = new Color(1f, 1f, 1f, alpha);
		}

		public void AddMessageToQueue(string message)
		{
			messageQueue.Enqueue(message);
			//Prevent a flood of messages.
			//if (messageQueue.Count > 15)
			//	messageQueue.Dequeue();
		}

		public void ClearQueue()
		{
			messageQueue.Clear();
		}
	}
}
