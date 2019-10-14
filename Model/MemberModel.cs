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
        private List<BoatModel> _boat = new List<BoatModel> ();
        Regex rx = new Regex ("^[0-9]+$");

        public MemberModel () {}
        public MemberModel (string name, string personalNumber, string ID = "")
        {
            ID = "";
            UserName = name;
            PersonalNumber = personalNumber;
        }

        public void addBoatToExistingMember (MemberModel member, BoatModel boat)
        {
            member.Boat.Add (boat);
        }

        public string getID ()
        {
            return ID;
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

        public List<BoatModel> Boat
        {
            get => _boat;
            set => _boat = value;
        }

        public void addBoat (BoatModel boat)
        {
            _boat.Add (boat);
        }
        public BoatModel GetBoat (int boat)
        {
            return Boat[boat];
        }
        public void deleteBoat (BoatModel boat)
        {
            _boat.Remove (boat);
        }
    }
}