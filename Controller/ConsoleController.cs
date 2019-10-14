using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class ConsoleController
    {
        MemberController _memberController;
        BoatController _boatController;

        public ConsoleController ()
        {
            _memberController = new MemberController ();
            _boatController = new BoatController ();
        }

        public bool run (ConsoleView consoleView)
        {
            if (consoleView.hasMenuOptionBeenSelected ())
            {
                consoleView.pressKeyToContinue ();
            }
            consoleView.displayMenuOptions ();
            consoleView.promptForMenuOptionSelection ();

            if (consoleView.wantsToAddMember ())
            {
                _memberController.addMember ();
            }
            if (consoleView.wantsToDisplayMember ())
            {
                _memberController.displayMemberByID ();
            }
            if (consoleView.wantsToEditMember ())
            {
                _memberController.editMemberByID ();
            }
            if (consoleView.wantsToDeleteMember ())
            {
                _memberController.deleteMemberByID ();
            }
            if (consoleView.wantsToAddBoat ())
            {
                _boatController.addBoatToMember (_memberController.getMemberByID ());
            }
            if (consoleView.wantsToEditBoats ())
            {
                _boatController.editBoatInformation (_memberController.getMemberByID ());
            }
            if (consoleView.wantsToDeleteBoat ())
            {
                _boatController.deleteBoat (_memberController.getMemberByID ());
            }
            if (consoleView.wantsToShowCompactList ())
            {
                _memberController.showCompactList ();
            }
            if (consoleView.wantsToShowVerboseList ())
            {
                _memberController.showVerboseList ();
            }
            if (consoleView.wantsToExit ())
            {
                return false;
            }
            return true;
        }
    }
}