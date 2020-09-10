using System;

namespace ArmadilloEngine
{
    public class Component
    {
        public GameObject Owner;
        /// <summary>
        /// Update() is called every frame.
        /// </summary>
        protected virtual void Update() { }

        /// <summary>
        /// Start() is called when the object is added to the game. If the object is added before the game has started it is called when the game starts.
        /// </summary>        
        protected virtual void Start() { }

        public static void UpdateComponent(Component component) => component.Update();
        public static void StartComponent(Component component) => component.Start();
    }

}
