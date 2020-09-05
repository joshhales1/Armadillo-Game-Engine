using System;

namespace ArmadilloEngine
{
	public class ObjectController : Component
	{
		Transform transform;

		protected override void Start()
		{
			transform = Owner.GetComponent<Transform>();
		}

		protected override void Update()
        {
			Vector NextMove = new Vector();
			if (Input.PressedKey == char.Parse("w")) NextMove = Vector.Up;
			if (Input.PressedKey == char.Parse("a")) NextMove = Vector.Left;
			if (Input.PressedKey == char.Parse("s")) NextMove = Vector.Down;
			if (Input.PressedKey == char.Parse("d")) NextMove = Vector.Right;

			transform.Position += Vector.RotateToWorld(NextMove);
		}
	}

}
