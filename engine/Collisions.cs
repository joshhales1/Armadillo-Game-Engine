using System;
using System.Collections.Generic;
namespace ArmadilloEngine
{
	public static partial class Game
	{
		static class Collisions
		{
			static List<BoxCollider> CollidersForCollision = new List<BoxCollider>();
			static List<BoxCollider> CollisionsToManage = new List<BoxCollider>();
			public static void AddCollider(BoxCollider sprite) => CollidersForCollision.Add(sprite);

			public static void TestColliders()
            {
				foreach (BoxCollider colliderA in CollidersForCollision)
                {
					foreach (BoxCollider colliderB in CollidersForCollision)
                    {
						if (colliderA != colliderB)
                        {
							Vector colliderAPos = colliderA.Owner.GetComponent<Transform>().Position;
							Vector colliderBPos = colliderB.Owner.GetComponent<Transform>().Position;

							if (IsPointInCollider(colliderBPos, colliderA) || 
								IsPointInCollider(colliderBPos + new Vector(colliderB.Dimensions.x, 0), colliderA) ||
								IsPointInCollider(colliderBPos + new Vector(0, colliderB.Dimensions.y), colliderA) ||
								IsPointInCollider(colliderBPos + colliderB.Dimensions, colliderA)
								) 
							{
								CollisionsToManage.Add(colliderA);
								CollisionsToManage.Add(colliderB);
							} else
                            {
								colliderA.Owner.GetComponent<Transform>().LastSafePosition = colliderA.Owner.GetComponent<Transform>().Position;
								colliderB.Owner.GetComponent<Transform>().LastSafePosition = colliderB.Owner.GetComponent<Transform>().Position;
							}

						}
                    }
                }
				CollidersForCollision.Clear();
            }

			public static void ShiftTransforms()
            {
				foreach (BoxCollider bc in CollisionsToManage)
                {
					Debug.Log("test");
					bc.Owner.GetComponent<Transform>().Position = bc.Owner.GetComponent<Transform>().LastSafePosition;
				}
				CollisionsToManage.Clear();
            }

			public static bool IsPointInCollider(Vector point, BoxCollider bc)
            {				
				Vector pointA = bc.Owner.GetComponent<Transform>().Position;
				Vector pointB = pointA + bc.Dimensions;
				Debug.Log((point.x > pointA.x && point.y > pointA.y && point.x > pointB.x && point.y > pointB.y).ToString());
				return point.x > pointA.x && point.y > pointA.y && point.x > pointB.x && point.y > pointB.y;
            }
			
		}
	}
}

