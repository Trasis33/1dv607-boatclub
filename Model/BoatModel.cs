using System;

namespace _1dv607_boatclub
{
    public class BoatModel
    {
        private BoatTypes _type;
        private double _boatLength;
        public BoatModel(BoatTypes types, double length)
        {
            _type = types;
            _boatLength = length;
        }

        public double BoatLength
        {
            get => _boatLength;

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _boatLength = value;
            }
        }
        public BoatTypes Type
        {
            get => _type;
        }
    }
}
