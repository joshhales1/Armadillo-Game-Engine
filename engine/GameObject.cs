using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
	public class GameObject
	{
        public List<IComponent> Components = new List<IComponent>();

        public T GetComponent<T>()
        {
            foreach (IComponent component in Components)
                if (component is T)
                    return (T) component;
            return default;
        }
        public void AddComponent<T>() where T : IComponent, new()
        {
            IComponent component = new T();
            AddComponent(component);
            return (T) component;
        }

        public void AddNewComponent<T>(T c)
        {
            if (c is IComponent)
            {
                IComponent component = c as IComponent;
                AddComponent(component);
            } else
            {
                throw new Exception("ArmadilloEngine: Provided component does not implement IComponent.");
            }
        }

        private void AddComponent(IComponent component)
        {
            component.Owner = this;
            Components.Add(component);
        }
    }
    
}

