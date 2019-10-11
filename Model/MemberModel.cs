using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1dv607_boatclub
{

    class MemberModel
    {
        private string _userName;
        private string _personalNumber;
        private string _ID;
        private BoatModel _boat;
        Regex rx = new Regex ("^[0-9]+$");

        public MemberModel ()
        {

        }
        public MemberModel (string name, string personalNumber, string ID = "")
        {
            ID = "";
            UserName = name;
            PersonalNumber = personalNumber;
        }
        public MemberModel (string name, string personalNumber, BoatModel boat, string ID = "")
        {
            ID = "";
            UserName = name;
            PersonalNumber = personalNumber;
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

        public string PersonalNumber
        {
            get => _personalNumber;
            set
            {
                if (String.IsNullOrWhiteSpace (value) && !rx.IsMatch (value))
                {
                    throw new ArgumentException ();
                }

                _personalNumber = value;
            }
        }

        public string ID
        {
            get => _ID;
            set
            {
                if (String.IsNullOrWhiteSpace (value))
                {
                    throw new ArgumentException ();
                }

                _ID = value;
            }
        }

        public BoatModel Boat
        {
            get => _boat;
            set => _boat = value;
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
                    // return string.Format ("Member ID: {0} \nMember: {1} \nBoat type: {2} \nBoat lengh: {3}", ID, UserName);
                    return string.Format ("Member ID: {0} \nMember: {1} \nBoat type: {2} \nBoat lengh: {3}", ID, UserName, Boat.Type, Boat.BoatLength);
                case "V":
                    // return string.Format ("Member ID: {0} \nMember: {1} \nPersonal number: {3}", ID, UserName, PersonalNumber);
                    return string.Format ("Member ID: {0} \nMember: {1} \nPersonal number: {3} \nBoat type: {2} \nBoat length: {4}", ID, UserName, PersonalNumber, Boat.Type, Boat.BoatLength);
                case "U":
                    return string.Format ("Member ID: {0} \nMember: {1} \nPersonal number {2}", ID, UserName, PersonalNumber);
                default:
                    string msg = string.Format ("'{0}' is an invalid format string.", format);
                    throw new ArgumentException (msg);
            }
        }
    }
}