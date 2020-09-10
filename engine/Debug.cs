using System;
using System.IO;
namespace ArmadilloEngine
{	
	static class Debug
	{
		static bool HasStarted;
		public static string RecentMessage = "";

		/// <summary>
		/// Logs a message to the log file as well as displaying it at the top of the game screen.
		/// </summary>
		/// <param name="s">The message to log.</param>
		public static void Log(string s)
        {
			File.WriteAllText("log.txt", $"{File.ReadAllText("log.txt")}[{DateTime.Now.ToString()}] {s}\n");
			RecentMessage = "Debug: " + s;
		}

		/// <summary>
		/// Logs a warning to the log file as well as displaying it at the top of the game screen.
		/// </summary>
		/// <param name="s">The message to log.</param>
		public static void Warn(string s)
        {
			Log("[Warning] " + s);
        }

		/// <summary>
		/// Logs an error to the log file as well as displaying it at the top of the game screen. 
		/// </summary>
		/// <param name="s">The message to log.</param>
		public static void Error(string s)
        {
			Log("[Error] " + s);
        }

		public static void Start()
        {
			File.WriteAllText("log.txt", "");
			HasStarted = true;
		}
	}
}

