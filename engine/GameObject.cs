using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
	public class GameObject
	{
        public List<Component> Components = new List<Component>();
        public string DisplayName = "Unnamed object";

        /// <summary>
        /// Returns the first Component of the specified type.
        /// </summary>
        /// <typeparam name="T">The class of Component. E.g. "Transform".</typeparam>
        /// <returns>The first Component of the specified type.</returns>
        public T GetComponent<T>() where T : Component, new()
        {
            foreach (Component component in Components)
                if (component is T && component is Component)
                    return (T) component;
            return default;
        }

        /// <summary>
        /// Add a new Component of the specified type to the GameObject.
        /// </summary>
        /// <typeparam name="T">The class of Component. E.g. "Transform".</typeparam>
        /// <returns>A reference to the newly created Component.</returns>
        public T AddComponent<T>() where T : Component, new()
        {
            Component component = new T();
            AddComponent(component);
            return (T) component;
        }

        /// <summary>
        /// Add an already instantiated Component to the GameObject.
        /// </summary>
        /// <typeparam name="T">The class of Component. E.g. "Transform".</typeparam>
        /// <param name="c">The Component to be added.</param>
        public void AddExistingComponent<T>(T c)
        {
            if (c is Component)
            {
                Component component = c as Component;
                AddComponent(component);
            } else
            {
                throw new Exception("ArmadilloEngine: Provided component does not inherit from Component.");
            }
        }
        /// <summary>
        /// Remove a Component from the GameObject.
        /// </summary>
        /// <typeparam name="T">The class of component. E.g. "Transform".</typeparam>
        /// <param name="c">A reference to the Component to remove.</param>
        public void RemoveComponent<T>(T c)
        {
            Component component = c as Component;
            if (Components.Contains(component))
            {
                Components.Remove(component);
            } else
            {
                Debug.Warn("Cannot remove component, is not on GameObject.");
            }
        }

        private void AddComponent(Component component)
        {
            component.Owner = this;
            Components.Add(component);
        }
    }
    
}

