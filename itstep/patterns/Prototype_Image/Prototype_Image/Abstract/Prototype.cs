using System;

namespace Prototype_Image
{
    [Serializable]
    public abstract class Prototype
    {
        public abstract Prototype Clone();
        public abstract Prototype DeepCopy();
    }
}