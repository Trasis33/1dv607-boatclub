using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class MemberView
    {
        private MemberModel _member;
        public MemberView (MemberModel memberModel)
        {
            _member = memberModel;
        }
        public MemberModel getNewMemberCredentials ()
        {
            string name; // new user name
            string IDNumber; // new user personal number

            Console.WriteLine ("Enter your name:\n");
            name = Console.ReadLine ();

            Console.WriteLine ("Enter your personal ID number:\n");
            IDNumber = Console.ReadLine ();

            Console.WriteLine ("Do you want to add a boat? Yes/No");

            string inputString = Console.ReadLine ();

            if (inputString.ToLower () == "yes" || inputString.ToLower () == "y")
            {
                BoatModel boat = addBoat ();
                _member = new MemberModel (name, IDNumber, boat);
            }
            else
            {
                _member = new MemberModel (name, IDNumber);
            }
            return _member;
        }

        private BoatModel addBoat ()
        {
            int value;
            int boatTypeValue = 0;
            double length;
            bool hasBoatBeenSelected = false;

            while (!hasBoatBeenSelected)
            {
                Console.WriteLine ("\n1: Sailboat\n2: Motorsailer\n3: Kayak\n4: Canoe\n5: Other");
                value = int.Parse (Console.ReadLine ());

                if (!Enum.IsDefined (typeof (BoatTypes), value))
                {
                    Console.WriteLine ("Not a valid type");
                }
                else
                {
                    hasBoatBeenSelected = true;
                }

                boatTypeValue = value;
            }

            Console.WriteLine ("Input the length of the boat\n");
            length = double.Parse (Console.ReadLine ());

            return new BoatModel ((BoatTypes) boatTypeValue, length);
        }

        public string memberToDeleteById ()
        {
            string number;

            System.Console.WriteLine ("What user do you wish to delete? Type ID\n");
            number = Console.ReadLine ();
            return number;
        }

        public void showMembersList (List<MemberModel> users)
        {
            foreach (MemberModel username in users)
            {
                if (username.hasBoat ())
                {
                    Console.WriteLine (username.ToString ("V"));
                }
                else
                {
                    Console.WriteLine (username.ToString ("U"));
                }
            }
        }
    }
}