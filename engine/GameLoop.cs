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
            {
				foreach (IComponent component in gameObject.Components)
                {
					component.Execute();
                }
			}

			Renderer.Render();
		}

		public static void Start()
        {
			Running = true;
			while (Running)
            {
				Loop();
            }
		}

		public static void Stop()
        {
			Running = false;
        }

		public static void AddObject(GameObject gameObject)
        {
			Objects.Add(gameObject);
        }

	}

	

}

