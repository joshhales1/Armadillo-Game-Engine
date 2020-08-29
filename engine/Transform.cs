using System;

namespace ArmadilloEngine
{
    public class Transform : IComponent
    {
        public Vector Position;
        public Vector Rotation;
        public GameObject Parent;

        public void Execute() { }

    }
}
