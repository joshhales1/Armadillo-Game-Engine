using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
	public static class Game
	{
		static List<GameObject> Objects = new List<GameObject>();
		static bool Running;
		static void Loop()
        {
			foreach (GameObject gameObject in Objects)
				foreach (Component component in gameObject.Components)                
					Component.UpdateComponent(component);                
			
			Input.PressedKey = "\0"[0];
			Renderer.Render();
		}

		public static void Start()
        {
			Running = true;	
			
			Input.Start();
			Renderer.Start();
			while (Running)
            {
				Time.OnFrame();
				Loop();				
            }
		}

		public static void Stop()
        {
			Running = false;
        }

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

