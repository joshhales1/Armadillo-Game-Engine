using System;

namespace ArmadilloEngine 
{
    public class BoxCollider : Component
    {
        /// <summary>
        /// The bottom right corner of the collider.
        /// </summary>
        public Vector Origin = new Vector();
        public Vector Dimensions = new Vector(1, 1);
    }
}
