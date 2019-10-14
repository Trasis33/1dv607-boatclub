using System;

namespace _1dv607_boatclub
{
    public class BoatModel
    {
        private BoatTypes _type;
        private double _boatLength;
        // private string _ID;
        public BoatModel (BoatTypes types, double length)
        {
            // _ID = ID;
            _type = types;
            _boatLength = length;
        }

        public double BoatLength
        {
            get => _boatLength;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException ();
                }

                _boatLength = value;
            }
        }
        public BoatTypes Type
        {
            get => _type;
            set => _type = value;
        }
    }
}