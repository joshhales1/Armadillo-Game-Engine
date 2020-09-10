using System;
using System.Threading;
namespace ArmadilloEngine
{
	static class Input
	{
		/// <summary>
		/// The key currently pressed by the user.
		/// </summary>
		public static char PressedKey;
		public static void Start()
        {
			ThreadStart inputThreadStart = new ThreadStart(ReadInputThread);
			Thread inputThread = new Thread(inputThreadStart);
			inputThread.Name = "Input Thread";
			inputThread.Start();
        }
		static void ReadInputThread()
        {
			while (true)
				PressedKey = Console.ReadKey(true).KeyChar;
		}

	}
}

