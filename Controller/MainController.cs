using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class MainController
    {
        LayoutView _layoutView;
        MemberController _memberController;

        public MainController ()
        {
            _layoutView = new LayoutView ();
            _memberController = new MemberController ();
        }

        public void run ()
        {
            menuSelection ();
        }

        public void menuSelection ()
        {

            int value;
            bool isProgramRunning = true;

            while (isProgramRunning)
            {
                _layoutView.menuOptions ();

                try
                {

                    value = int.Parse (Console.ReadLine ());

                    if (value <= 0 || value >= 6)
                    {
                        throw new ArgumentOutOfRangeException ();
                    }

                    switch (value)
                    {
                        case 1:
                            _memberController.addMember ();
                            break;
                        case 2:
                            _memberController.showMembersList ();
                            break;
                        case 3:
                            _memberController.deleteMember ();
                            break;
                        case 4:
                            _memberController.editUserInformation ();
                            break;
                        case 5:
                            isProgramRunning = false;
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine ("Only valid input.\n");
                }
            }
        }
    }
}