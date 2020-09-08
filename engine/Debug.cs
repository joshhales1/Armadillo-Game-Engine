using System;
using System.Diagnostics;
using System.IO;
namespace ArmadilloEngine
{
	
	public static class Debug
	{
		static bool HasStarted;
		public static string RecentMessage = "";
		public static void Log(string s)
        {
			if (!HasStarted)
				StartDebug();
			File.WriteAllText("log.txt", $"{File.ReadAllText("log.txt")}[{DateTime.Now.ToString()}] {s}\n");
			RecentMessage = s;
		}

		public static void Warn(string s)
        {
			Log("[Warning] " + s);
        }

		public static void Error(string s)
        {
			Log("[Error]" + s);
        }

		static void StartDebug()
        {
			File.WriteAllText("log.txt", "");
			HasStarted = true;
		}
	}
}

