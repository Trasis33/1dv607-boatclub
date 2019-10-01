using System;
using System.Collections.Generic;

namespace _1dv607_boatclub
{
  class Application
  {
    private LayoutView _layoutView;
    private MainController _mainController;
    private MemberController _memberController;
    private BoatController _boatController;
    private Storage _storage;
    public Application()
    {
      _storage = new Storage();
      _layoutView = new LayoutView();
      _mainController = new MainController(_storage);
      _memberController = new MemberController(_storage);
      _boatController = new BoatController(_storage);
    }
    public void run()
    {
      menuSelection();
    }

    public void menuSelection()
    {

      int value;
      bool isProgramRunning = true;

      while(isProgramRunning)
      {
        try
        {
          _layoutView.menuOptions();

          value = int.Parse(Console.ReadLine());

          if(value <= 0 || value >= 7)
          {
            throw new ArgumentOutOfRangeException();
          }

          switch(value)
          {
            case 1:
              _memberController.addMember();
              break;
            case 2:
              _memberController.showMembersList();
              break;
            case 3:
              _memberController.deleteMember();
              break;
            case 4:
              _boatController.addBoat();
              break;
            case 5:
              _boatController.showBoatsList();
              break;
            case 6:
              isProgramRunning = false;
              break;
          }
        } catch (Exception)
        {
          Console.WriteLine("\n Only valid input.\n");
        }
      }
    }
  }
}