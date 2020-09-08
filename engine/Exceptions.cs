using System;

namespace ArmadilloEngine
{
    [Serializable]
    class ArmadilloEngineException : Exception
    {
        public ArmadilloEngineException()
        {

        }

        public ArmadilloEngineException(string s)
            : base(s)
        {
            Debug.Error(s);
        }

    }
}