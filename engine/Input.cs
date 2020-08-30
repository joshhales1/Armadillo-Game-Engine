using System;
using System.Threading;
using System.Collections.Generic;
namespace ArmadilloEngine
{
	public static class Input
	{
		public static char PressedKey;
		public static void Start()
        {
			Console.WriteLine("Starting input...");
			ThreadStart inputThreadStart = new ThreadStart(ReadInputThread);
			Thread inputThread = new Thread(inputThreadStart);
			inputThread.Start();
        }
		static void ReadInputThread()
        {
			while (true)
            {
				PressedKey = Console.ReadKey().KeyChar;
				Renderer.RequestRender();
			}			
        }

	}
}

