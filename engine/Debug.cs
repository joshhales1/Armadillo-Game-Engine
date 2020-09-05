using System;
using System.Diagnostics;
using System.IO;
namespace ArmadilloEngine
{
	
	public static class Debug
	{
		static bool HasStarted;
		public static void Log(string s)
        {
			if (!HasStarted)
				StartDebug();
			File.WriteAllText("log.txt", $"{File.ReadAllText("log.txt")}[{DateTime.Now.ToString()}] {s}\n");
		}

		static void StartDebug()
        {
			File.WriteAllText("log.txt", "");
			HasStarted = true;
		}
	}
}

