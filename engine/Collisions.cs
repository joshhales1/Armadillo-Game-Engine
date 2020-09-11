using System;
using System.Collections.Generic;
namespace ArmadilloEngine
{
	public static partial class Game
	{
		static class Collisions
		{
			static List<BoxCollider> CollidersForCollision = new List<BoxCollider>();
			static void AddCollider(BoxCollider sprite) => CollidersForCollision.Add(sprite);

			static void TestColliders()
            {
				foreach (BoxCollider colliderA in CollidersForCollision)
                {
					foreach (BoxCollider colliderB in CollidersForCollision)
                    {
						if (colliderA != colliderB)
                        {
							Vector colliderAPos = colliderA.Owner.GetComponent<Transform>().Position;
							Vector colliderBPos = colliderB.Owner.GetComponent<Transform>().Position;
						}
                    }
                }
            }

			
		}
	}
}

