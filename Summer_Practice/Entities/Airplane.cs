using System;
using System.Collections.Generic;
using System.Text;

namespace Summer_Practice.Entities
{
    public class Airplane : Air
    {
        public Airplane(string model, double speed, double maxLoad) : base(model, speed, maxLoad)
        {
        }

        public Airplane(string model, double speed, double maxLoad, int staff, int passengers) : base(model, speed, maxLoad)
        {
            Staff = staff;
            Passengers = passengers;
        }

        public override string TypeInfo()
        {
            return String.Format("{0}, Airplane", base.TypeInfo());
        }

        public void Transportation(object cargo, string destination)
        {
            //here we work with transportation classes
            //but yet
            throw new NotImplementedException("Not implemented yet");
        }
    }
}
