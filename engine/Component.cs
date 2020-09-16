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

        /// <summary>
        /// Update a component out of the usual game loop.
        /// </summary>
        /// <param name="component">Component to update.</param>
        public static void UpdateComponent(Component component) => component.Update();

        /// <summary>
        /// Start a component again.
        /// </summary>
        /// <param name="component">Component to update.</param>
        public static void StartComponent(Component component) => component.Start();
    }

}
