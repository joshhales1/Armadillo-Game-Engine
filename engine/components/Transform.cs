﻿using System;

namespace ArmadilloEngine
{
    public class Transform : IComponent
    {
        public Vector Position = new Vector();
        public Vector Rotation = new Vector();
        public GameObject Parent;
        

        public void Update() { }
        public void Start() { }
        public GameObject Owner { get; set; }

    }
}
