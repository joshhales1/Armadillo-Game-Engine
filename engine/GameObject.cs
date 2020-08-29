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
            IComponent c = new T();
            Components.Add(c);
        }
    }
    
}

