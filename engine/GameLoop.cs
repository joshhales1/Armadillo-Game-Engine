using System;
using System.Collections.Generic;
using System.Threading;
namespace ArmadilloEngine
{
	public static class Game
	{
		static List<GameObject> Objects = new List<GameObject>();
		static bool Running;
		public static Vector WindowDimensions { get; private set; }


		public static void Start(int xHeight = 20, int yHeight = 20)
		{
			WindowDimensions = new Vector(xHeight, yHeight);

			Running = true;

			Input.Start();
			Renderer.Start();

			ThreadStart gameLoopThreadStart = new ThreadStart(TrueStart);
			Thread gameLoopThread = new Thread(gameLoopThreadStart);
			gameLoopThread.Start();
		}

		private static void TrueStart()
		{
			while (Running)
			{
				Time.OnFrame();
				Loop();
			}
		}

		static void Loop()
        {
			foreach (GameObject gameObject in Objects)
				foreach (Component component in gameObject.Components)                
					Component.UpdateComponent(component);                
			
			Input.PressedKey = "\0"[0];
			Renderer.Render();
		}		

		public static void Stop() => Running = false;

		public static void AddObject(GameObject gameObject)
        {
			foreach (Component component in gameObject.Components)
				Component.StartComponent(component);			
			Objects.Add(gameObject);
        }

		public static class Time
		{
			static DateTimeOffset LastFrame = DateTimeOffset.UtcNow;
			public static float DeltaTime;
			internal static void OnFrame()
            {				
				DateTimeOffset now = DateTimeOffset.UtcNow;
				TimeSpan ts = now.Subtract(LastFrame);
				DeltaTime = (float)ts.TotalSeconds;
				LastFrame = DateTimeOffset.UtcNow;
			}
		}

	}
	

}

