using System;

namespace ArmadilloEngine
{
	public interface IComponent
    {
        void Update();
        void Start();
        GameObject Owner { get; set; }
    }

}
