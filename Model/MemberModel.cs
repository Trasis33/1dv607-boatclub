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
        private List<BoatModel> _boats = new List<BoatModel> ();
        Regex rx = new Regex ("^[0-9]+$");

        public MemberModel (string name, string personalNumber, string ID = "")
        {
            ID = "";
            UserName = name;
            PersonalNumber = personalNumber;
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
            get => _boats;
            set => _boats = value;
        }
        public void addBoat (BoatModel boat)
        {
            _boats.Add (boat);
        }
        public BoatModel GetBoat (int boat)
        {
            return Boat[boat];
        }
        public void deleteBoat (BoatModel boat)
        {
            _boats.Remove (boat);
        }
    }
}