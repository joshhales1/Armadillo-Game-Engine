using System;

namespace ArmadilloEngine
{
	public interface IComponent
    {
        void Execute();
        GameObject Owner { get; set; }
    }

}
