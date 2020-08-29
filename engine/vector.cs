using System;
namespace ArmadilloEngine
{
	/// <summary>
	/// A type for dealing with 2 and 3 dimensional vectors.
	/// </summary>
	public class Vector
	{
		public float x;
		public float y;
		public float z;
		///<summary>
		///The magnitude of the vector. The total length of the vector
		///</summary>
		public float Magnitude
		{
			get => (float)Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)));
		}
		public Vector(float xComponent = 0, float yComponent = 0, float zComponent = 0f)
		{
			x = xComponent;
			y = yComponent;
			z = zComponent;
		}
		///<summary>
		///Makes the magnitude of the vector equal to one.
		///</summary>
		public void Normalize()
		{
			float divisor = Magnitude / 1;
			x /= divisor;
			y /= divisor;
			z /= divisor;
		}

		public static Vector operator +(Vector a, Vector b) =>
			new Vector(a.x + b.x, a.y + b.y, a.z + b.z);

		public static Vector operator -(Vector a, Vector b) =>
			a + b * -1f;

		public static Vector operator *(Vector a, float b) =>
			new Vector(a.x * b, a.y * b, a.z * b);

		public static Vector operator /(Vector a, float x) =>
			a * (float)Math.Pow(x, -1);
	}
}
