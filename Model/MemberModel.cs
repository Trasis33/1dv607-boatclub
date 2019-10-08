using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1dv607_boatclub
{

    class MemberModel
    {
        private string _userName;
        private string _IDNumber;
        private BoatModel _boat;
        Regex rx = new Regex ("^[0-9]+$");

        public MemberModel ()
        {

        }
        public MemberModel (string name, string ID)
        {
            UserName = name;
            IDNumber = ID;
        }
        public MemberModel (string name, string ID, BoatModel boat)
        {
            UserName = name;
            IDNumber = ID;
            _boat = boat;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (String.IsNullOrWhiteSpace (value))
                {
                    throw new ArgumentException ();
                }

                _userName = value;
            }
        }

        public string IDNumber
        {
            get => _IDNumber;
            set
            {
                if (String.IsNullOrWhiteSpace (value) && !rx.IsMatch (value))
                {
                    throw new ArgumentException ();
                }

                _IDNumber = value;
            }
        }

        public BoatModel Boat
        {
            get => _boat;
        }

        public bool hasBoat ()
        {
            if (Boat != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString ()
        {
            return ToString ("C");
        }

        public string ToString (string format)
        {
            if (string.IsNullOrWhiteSpace (format))
            {
                format = "C";
            }

            switch (format)
            {
                case "C":
                    return string.Format ("{0} {1} {3} {2}", UserName, _boat.BoatLength, _boat.Type);
                case "V":
                    return string.Format ("{0} {1} {3} {2}", UserName, IDNumber, _boat.BoatLength, _boat.Type);
                case "U":
                    return string.Format ("{0} {1}", UserName, IDNumber);
                default:
                    string msg = string.Format ("'{0}' is an invalid format string.", format);
                    throw new ArgumentException (msg);
            }
        }
    }
}