using System;
using System.Collections.Generic;
using System.Text;

namespace E01.Prototype.Contracts
{
    public abstract class SandwichPrototype<T>
    {
        public abstract T ShallowCopy();

        public abstract T DeepCopy();

    }
}
