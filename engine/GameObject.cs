using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
	public class GameObject
	{
        public List<Component> Components = new List<Component>();
        public string DisplayName = "Unnamed";

        public T GetComponent<T>() where T : Component, new()
        {
            foreach (Component component in Components)
                if (component is T && component is Component)
                    return (T) component;
            return default;
        }
        public T AddComponent<T>() where T : Component, new()
        {
            Component component = new T();
            AddComponent(component);
            return (T) component;
        }

        public void AddNewComponent<T>(T c)
        {
            if (c is Component)
            {
                Component component = c as Component;
                AddComponent(component);
            } else
            {
                throw new Exception("ArmadilloEngine: Provided component does not implement IComponent.");
            }
        }

        private void AddComponent(Component component)
        {
            component.Owner = this;
            Components.Add(component);
        }
    }
    
}

