using System;
using System.Collections.Generic;
namespace ArmadilloEngine
{
	static class Game
	{
		static List<GameObject> Objects = new List<GameObject>();

		static List<GameObject> ObjectsToAdd = new List<GameObject>();
		static List<GameObject> ObjectsToRemove = new List<GameObject>();
		static bool Running;
		public static Vector WindowDimensions { get; private set; }

		public static void Start(int xHeight = 20, int yHeight = 20)
		{
			WindowDimensions = new Vector(xHeight, yHeight);

			Running = true;

			Debug.Start();
			Input.Start();
			Renderer.Start();

			while (Running)
			{
				Time.OnFrame();
				Loop();
			}
			Debug.Log("Session ended cleanly");
			Environment.Exit(0);
		}

		static void Loop()
		{
			
			foreach (GameObject gameObject in Objects)
				foreach (Component component in gameObject.Components)                
					Component.UpdateComponent(component);

			foreach (GameObject gameObject in ObjectsToAdd)
				Objects.Add(gameObject);

			foreach (GameObject gameObject in ObjectsToRemove)
				Objects.Remove(gameObject);

			ObjectsToAdd.Clear();
			ObjectsToRemove.Clear();

			Input.PressedKey = "\0"[0];
			Renderer.Render();

		}		

		public static void Stop() => Running = false;

		public static void AddObject(GameObject gameObject)
        {
			foreach (Component component in gameObject.Components)
				Component.StartComponent(component);			
			ObjectsToAdd.Add(gameObject);
        }

		public static void RemoveObject(GameObject gameObject)
        {
			if (Objects.Contains(gameObject))
				ObjectsToRemove.Add(gameObject);
			else
				Debug.Warn($"Cannot remove {gameObject.DisplayName} because it is not in the game.");
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

