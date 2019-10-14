using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class MemberView : SharedView
    {
        public MemberView ()
        {

        }

        public string getMemberName ()
        {
            printCustomMessage ("Enter your name:\n");
            return getInput ();
        }

        public string getPersonalNumber ()
        {
            printCustomMessage ("Enter your personal number:\n");
            return getInput ();
        }

        public string getID ()
        {
            printCustomMessage ("Enter ID: ");
            return getInput ();
        }

        public void displayMember (MemberModel member)
        {
            printSectionSeparationLine ();
            printCustomMessage ("ID: " + member.ID + ", Name: " + member.UserName + ", Personal number: " + member.PersonalNumber);
            printSectionSeparationLine ();
        }

        public string memberToDeleteById ()
        {
            string member;

            System.Console.WriteLine ("What user do you wish to delete? Type ID\n");
            member = Console.ReadLine ();
            return member;
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
        public void showCompactMemberList (List<MemberModel> members)
        {
            foreach (MemberModel member in members)
            {
                printCustomMessage ("ID: " + member.ID + ", Name: " + member.UserName + ", Number of boats: " + member.Boat.Count);
            }
        }

        public void showVerboseMemberList (List<MemberModel> members)
        {
            foreach (MemberModel member in members)
            {
                printCustomMessage ("ID: " + member.ID + ", Name: " + member.UserName +
                    ", Personal number: " + member.PersonalNumber + ", Number of boats: " + member.Boat.Count);
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

            oldMember.UserName = newMemberName;
            oldMember.PersonalNumber = newPersonalNumber;

            return oldMember;
        }

    }
}