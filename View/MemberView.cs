using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class MemberView : SharedView
    {
        const int MIN_NAME_LENGTH = 3;
        const int MIN_PERSONAL_NUMBER_LENGTH = 10;
        const int MAX_PERSONAL_NUMBER_LENGTH = 12;
        public MemberView () { }

        public string getMemberName ()
        {
            string name;

            while (true)
            {
                printCustomMessage ("Enter your name:\n");
                name = getInput ();

                if (name.Length >= MIN_NAME_LENGTH && containsOnlyLetters (name))
                {
                    return name;
                }
                else
                {
                    printCustomMessage ("Name must be more than 3 characters and not contain any numbers\n");
                }
            }
        }

        public string getPersonalNumber ()
        {
            string personalNumber;

            while (true)
            {
                printCustomMessage ("Enter your personal number:\n");
                personalNumber = getInput ();

                if (personalNumber.Length >= MIN_PERSONAL_NUMBER_LENGTH && personalNumber.Length <= MAX_PERSONAL_NUMBER_LENGTH)
                {
                    if (containsOnlyNumbers (personalNumber))
                    {
                        return personalNumber;
                    }
                    else
                    {
                        printCustomMessage ("Your personal number must only contain numbers");
                    }
                }
                else
                {
                    printCustomMessage ("Your personal number must contain between 10 and 12 numbers");
                }
            }
        }

        public string getID ()
        {
            while (true)
            {
                printCustomMessage ("Enter ID: ");
                string ID = getInput ();

                if (containsOnlyNumbers (ID))
                {
                    return ID;
                }
                else
                {
                    printCustomMessage ("ID must contain only numbers");
                }
            }
        }

        public string memberToDeleteById ()
        {
            string member;

            System.Console.WriteLine ("What user do you wish to delete? Type ID\n");
            member = getInput ();
            return member;
        }

        public string memberToEditByID ()
        {
            System.Console.WriteLine ("What user do you wish to edit? Type ID\n");
            string member = getInput ();
            return member;
        }

        public bool confirmMemberToEdit (MemberModel member)
        {
            bool userconfirmed = false;
            string inputString = "";
            System.Console.WriteLine (member.UserName);

            System.Console.WriteLine ("Is this the member you would like to edit? y/n \n");

            while (!userconfirmed)
            {
                inputString = getInput ();

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

            Console.WriteLine ("Press Enter to keep old user name or enter a new name\n");
            newMemberName = getInput ();

            if (newMemberName == "")
            {
                newMemberName = oldMember.UserName;
            }

            Console.WriteLine ("Press Enter to keep old peronal number or enter a number:\n");
            newPersonalNumber = getInput ();

            if (newPersonalNumber == "")
            {
                newPersonalNumber = oldMember.PersonalNumber;
            }

            oldMember.UserName = newMemberName;
            oldMember.PersonalNumber = newPersonalNumber;

            return oldMember;
        }

        public void displayNotFoundMessage ()
        {
            printCustomMessage ("\nMember not found, returning to menu.");
            printSectionSeparationLine ();
        }

        public bool containsOnlyNumbers (string input)
        {
            if (input.Any (char.IsLetter))
            {
                return false;
            }
            return true;
        }
        public bool containsOnlyLetters (string input)
        {
            if (input.Any (char.IsDigit))
            {
                return false;
            }
            return true;
        }
        public void displayMember (MemberModel member)
        {
            printSectionSeparationLine ();
            printCustomMessage ("ID: " + member.ID + ", Name: " + member.UserName + ", Personal number: " + member.PersonalNumber);
            printSectionSeparationLine ();
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
                printCustomMessage ("Name: " + member.UserName + "\nPersonal number: " + member.PersonalNumber +
                    "\nID: " + member.ID + "\n" + getVerboseBoatList (member.Boat));
            }
        }

        public string getVerboseBoatList (List<BoatModel> boats)
        {
            string boatInformation = "";

            for (var i = 0; i < boats.Count (); i++)
            {
                boatInformation += "\nBoat: " + (i + 1) + "\n  Boat type: " + boats[i].Type + "\n" + "  Boat length: " +
                    boats[i].BoatLength + "\n";
            }

            return boatInformation;
        }

    }
}