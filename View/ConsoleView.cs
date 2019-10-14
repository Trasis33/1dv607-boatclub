using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class ConsoleView : SharedView
    {
        private int input = -1;
        public void displayMenuOptions ()
        {
            printSectionSeparationLine ();
            Console.WriteLine ("1: Add member\n2: Display member\n3: Edit member" +
                "\n4: Delete Member\n5: Add boat\n6: Edit boats" +
                "\n7: Delete boat\n8: Show compact list\n9: Show verbose list" +
                "\n0: Exit");
            printSectionSeparationLine ();
        }

        public bool hasMenuOptionBeenSelected ()
        {
            if (input > 0)
            {
                return true;
            }
            return false;
        }

        public void promptForMenuOptionSelection ()
        {
            printCustomMessage ("input menu choice: ");
            try
            {
                input = getMenuInput ();
            }
            catch (ArgumentOutOfRangeException)
            {
                input = -1;
            }
        }

        public void pressKeyToContinue ()
        {
            printCustomMessage ("Press any key to continue: ");
            getInput ();
        }

        public bool wantsToAddMember ()
        {
            return (menuSelections) input == menuSelections.addMember;
        }
        public bool wantsToDisplayMember ()
        {
            return (menuSelections) input == menuSelections.displayMember;
        }
        public bool wantsToEditMember ()
        {
            return (menuSelections) input == menuSelections.editMember;
        }
        public bool wantsToDeleteMember ()
        {
            return (menuSelections) input == menuSelections.deleteMember;
        }
        public bool wantsToAddBoat ()
        {
            return (menuSelections) input == menuSelections.addBoat;
        }
        public bool wantsToEditBoats ()
        {
            return (menuSelections) input == menuSelections.editBoats;
        }
        public bool wantsToDeleteBoat ()
        {
            return (menuSelections) input == menuSelections.deleteBoat;
        }
        public bool wantsToShowCompactList ()
        {
            return (menuSelections) input == menuSelections.showCompactList;
        }
        public bool wantsToShowVerboseList ()
        {
            return (menuSelections) input == menuSelections.showVerboseList;
        }
        public bool wantsToExit ()
        {
            return (menuSelections) input == menuSelections.exit;
        }
    }
}