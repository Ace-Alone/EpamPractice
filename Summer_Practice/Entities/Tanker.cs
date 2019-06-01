using System;
using System.Collections.Generic;
using System.Text;

namespace Summer_Practice.Entities
{
    public class Tanker : Water
    {
        public Tanker(string model, double speed, double maxLoad) : base(model, speed, maxLoad)
        {
        }

        public Tanker(string model, double speed, double maxLoad, int staff, int passengers) : base(model, speed, maxLoad)
        {
            Staff = staff;
            Passengers = passengers;
        }

        public override string TypeInfo()
        {
            return String.Format("{0}, Tanker", base.TypeInfo());
        }

        public void Transportation(object cargo, string destination)
        {
            //here we work with transportation classes
            //but yet
            throw new NotImplementedException("Not implemented yet");
        }
    }
}
