using System;
using System.Collections.Generic;
namespace ArmadilloEngine 
{
    public class BoxCollider : Component
    {
        /// <summary>
        /// The top left corner of the collider.
        /// </summary>
        public Vector Origin = new Vector();
        public Vector Dimensions = new Vector(1, 1);
        public bool JustCollided;

    }
}
