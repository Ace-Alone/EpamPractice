using System;
using System.Collections.Generic;
using System.Text;

namespace Summer_Practice
{
    public abstract class Ground : Transport
    {
        protected Ground(string model, double speed, double maxLoad) : base(model, speed, maxLoad)
        {
        }

        public override string TypeInfo()
        {
            return String.Format("{0}, Ground", base.TypeInfo());
        }
    }
}
