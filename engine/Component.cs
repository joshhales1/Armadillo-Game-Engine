using System;

namespace ArmadilloEngine
{
    public class Component
    {
        public GameObject Owner;
        protected virtual void Update() { }
        protected virtual void Start() { }

        public static void UpdateComponent(Component component) => component.Update();
        public static void StartComponent(Component component) => component.Start();
    }

}
