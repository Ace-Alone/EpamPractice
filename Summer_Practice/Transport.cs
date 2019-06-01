using System;
using System.Collections.Generic;
using System.Text;

namespace Summer_Practice
{
    public abstract class Transport
    {
        private double speed;
        private double maxLoad;
        private string model;
        private int staff;
        private int passengers;

        private bool isStaffSet;
        private bool isPassangersSet;


        protected Transport(string model, double speed, double maxLoad)
        {
            Model = model;
            Speed = speed;
            MaxLoad = maxLoad;
            isStaffSet = false;
            isPassangersSet = false;
        }

        public double Speed
        {
            get => speed;
            set
            {
                if (value > 0)
                {
                    speed = value;
                }
                else throw new ArgumentException();
            }
        }
        public double MaxLoad
        {
            get => maxLoad;
            set
            {
                if (value > 0)
                {
                    maxLoad = value;
                }
                else throw new ArgumentException();
            }
        }
        public string Model
        {
            get => model;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    model = value;
                }
                else throw new ArgumentException();
            }
        }
        public int Staff
        {
            get => staff;
            set
            {
                if (value >= 0)
                {
                    staff = value;
                    isStaffSet = true;
                }
                else throw new ArgumentException();
            }
        }
        public int Passengers
        {
            get => passengers;
            set
            {
                if (value >= 0)
                {
                    passengers = value;
                    isPassangersSet = true;
                }
                else throw new ArgumentException();
            }
        }

        public virtual string TypeInfo()
        {
            return "Transport";
        }

        protected string PrimaryInfo()
        {
            string staffInfo = isStaffSet ? Staff.ToString() : "not set";
            string passInfo = isPassangersSet ? Passengers.ToString() : "not set";

            return String.Format(
                "Model: {0};\nSpeed: {1} mph;\nMaximum load: {2} tons;\nStaff: {3};\nPassengers: {4}.",
                Model, Speed, MaxLoad, staffInfo, passInfo);
        }

        public string FullInfo()
        {
            string type = TypeInfo();
            string primaryInfo = PrimaryInfo();
            return String.Format("Type: {0}\n{1}", type, primaryInfo);
        }



    }
}
