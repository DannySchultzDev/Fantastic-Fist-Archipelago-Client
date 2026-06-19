using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantastic_Fist_Archipelago_Client
{
	public static class PathManager
	{
		public static Dictionary<Location, bool> pathUnlocks =
			new Dictionary<Location, bool>();

		public static void InitializePaths()
		{
			foreach (Location location in Enum.GetValues(typeof(Location)))
			{
				if ((int)location < 400 || (int)location >= 900)
					continue;

				pathUnlocks[location] = false;
			}
		}
	}
}
