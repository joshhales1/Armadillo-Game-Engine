using System;

namespace ArmadilloEngine
{
    public class Component
    {
        public GameObject Owner;

        protected virtual void Update() {
            //Debug.Log("Updating component.");
        }
        protected virtual void Start() 
        {
            Debug.Log(this.Owner.DisplayName + " - Starting component");
        }

        public static void UpdateComponent(Component component)
        {
            component.Update();
        }

        public static void StartComponent(Component component) => component.Start();
    }

}
