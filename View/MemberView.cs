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
            string name; // new member name
            string IDNumber; // new member personal number

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

        public BoatModel addBoat ()
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

        public void showMembersList (List<MemberModel> members)
        {
            foreach (MemberModel member in members)
            {
                if (member.hasBoat ())
                {
                    Console.WriteLine (member.ToString ("V"));
                    Console.WriteLine ("\n");
                }
                else
                {
                    Console.WriteLine (member.ToString ("U"));
                    Console.WriteLine ("\n");
                }
            }
        }

        public string memberToEditByID ()
        {
            System.Console.WriteLine ("What user do you wish to edit? Type ID\n");
            string member = Console.ReadLine ();
            return member;
        }

        public bool confirmMemberToEdit (MemberModel member)
        {
            bool userconfirmed = false;
            string inputString = "";
            System.Console.WriteLine (member.ToString ("U"));

            System.Console.WriteLine ("Is this the member you would like to edit? y/n \n");

            while (!userconfirmed)
            {
                inputString = Console.ReadLine ();

                if (inputString.ToLower () == "yes" || inputString.ToLower () == "y")
                {
                    userconfirmed = true;
                    return true;
                }
                else
                {
                    userconfirmed = true;
                }
            }
            return false;
        }

        public MemberModel memberToEdit (MemberModel member)
        {
            MemberModel oldMember = member;

            string newMemberName;
            string newPersonalNumber;
            // BoatModel newBoat;

            Console.WriteLine ("Press Enter to keep old user name or enter a new name\n");
            newMemberName = Console.ReadLine ();

            if (newMemberName == "")
            {
                newMemberName = oldMember.UserName;
            }

            Console.WriteLine ("Press Enter to keep old peronal number or enter a number:\n");
            newPersonalNumber = Console.ReadLine ();

            if (newPersonalNumber == "")
            {
                newPersonalNumber = oldMember.PersonalNumber;
            }

            // Console.WriteLine ("Do you want to add a boat? Yes/No");

            // string inputString = Console.ReadLine ();

            // if (inputString.ToLower () == "yes" || inputString.ToLower () == "y")
            // {
            //     BoatModel boat = addBoat ();
            //     _member = new MemberModel (name, IDNumber, boat);
            // }
            // else
            // {
            //     _member = new MemberModel (name, IDNumber);
            // }

            oldMember.UserName = newMemberName;
            oldMember.PersonalNumber = newPersonalNumber;

            return oldMember;
        }
    }
}