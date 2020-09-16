using System;
using System.Collections.Generic;
namespace ArmadilloEngine
{
	public static partial class Game
	{
		static List<GameObject> Objects = new List<GameObject>(); // GameObjects currently active in the scene.

		// GameObjects are added to these lists for removal or addition at the end the Update() loop.
		// Enumeration were caused by directly editing Objects by scripts in Components		
		static List<GameObject> ObjectsToAdd = new List<GameObject>();
		static List<GameObject> ObjectsToRemove = new List<GameObject>();
		
		static bool Running;

		/// <summary>
		/// Starts the game.
		/// </summary>
		/// <param name="xwidth">The width of the game window.</param>
		/// <param name="yHeight">The height of the game window.</param>
		/// <param name="renderMode">Whether to use single render mode or double render mode.</param>
		public static void Start(int xwidth = 20, int yHeight = 20, int renderMode = 2)
		{
			Running = true;
			
			Debug.Start();
			Input.Start();
			Renderer.Start(new Vector(xwidth, yHeight), renderMode);

			while (Running)
			{
				Time.OnFrame();
				Loop();
			}
			Debug.Log("Session ended cleanly.");
			Environment.Exit(0);
		}

		/// <summary>
		/// Stops the game cleanly.
		/// </summary>
		public static void Stop() => Running = false;

		static void Loop()
		{			
			foreach (GameObject gameObject in Objects)
				foreach (Component component in gameObject.Components)
                {
					Component.UpdateComponent(component);

					//Special components
					if (component is SpriteRenderer)
						Renderer.AddSprite(component as SpriteRenderer);
				}            
					

			foreach (GameObject gameObject in ObjectsToAdd)
				Objects.Add(gameObject);

			foreach (GameObject gameObject in ObjectsToRemove)
				Objects.Remove(gameObject);

			ObjectsToAdd.Clear();
			ObjectsToRemove.Clear();

			Input.PressedKey = "\0"[0];
			Renderer.Render();
		}

		/// <summary>
		/// Add a GameObject to the game. GameObjects in the game will run their update functions each frame.
		/// </summary>
		/// <param name="gameObject">The GameObject to add.</param>
		public static void AddObject(GameObject gameObject)
        {
			foreach (Component component in gameObject.Components)
				Component.StartComponent(component);			
			ObjectsToAdd.Add(gameObject);
        }

		/// <summary>
		/// Remove a GameObjects from the game. GameObjects will no longer be rendered, updated etc.
		/// </summary>
		/// <param name="gameObject">The GameObject to remove.</param>
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
			/// <summary>
			/// The time passed since the last frame.
			/// </summary>
			public static float DeltaTime { get; private set; }
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

