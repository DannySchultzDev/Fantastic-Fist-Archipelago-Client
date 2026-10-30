using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class DeathlinkManager
	{
		public static DeathLinkService service = null;

		public static bool deathlinkEnabled = false;
		public static Int64 deathlinkAmnesty = 0;
		public static Int64 amnestyUsed = 0;

		public static bool storeDeath = false;

		private static List<string> reasons = [
			"hurt their knuckles",
			"pulled a finger",
			"broke a finger",
			//"pet a Gorb",
			//"pet a Gube",
			//"touched a skull block",
			//"is exploring a bottemless pit",
			"is no longer with us",
			"leaped before they looked",
			"probably shouldn't have done that",
			"forgot how coyote time worked",
			//"was crushed by a sliding block",
			//"was crushed by a block launcher",
			//"lost a fight with The Wizzard",
			"has seen better days",
			//"tried to do something out of logic"
		];


		public static void DeathlinkReceived(DeathLink deathLink)
		{
			Melon<Core>.Logger.Msg("Deathlink Received");
			//Amnesty is going to be incremented by the death, but being killed
			//by someone else shouldn't cause you to send your own deathlink.
			if (deathlinkEnabled)
			{
				storeDeath = true;
			}
		}

		public static void PlayerDeath()
		{
			if (!deathlinkEnabled || service == null) 
				return;

			++amnestyUsed;

			if (amnestyUsed > deathlinkAmnesty)
			{
				string reason = reasons[new Random().Next(reasons.Count)];
				service.SendDeathLink(new DeathLink(Core.instance.name, Core.instance.name + " " + reason));
				Core.instance.messageManager.AddMessageToQueue("DeathLink Sent!");
				amnestyUsed = 0;
			}
			else if (amnestyUsed == deathlinkAmnesty)
			{
				Core.instance.messageManager.AddMessageToQueue("Last amnesty used, next death sends a DeathLink!");
			}
			else
			{
				Core.instance.messageManager.AddMessageToQueue(deathlinkAmnesty - amnestyUsed + " amnesty remaining.");
			}
		}
	}
}
