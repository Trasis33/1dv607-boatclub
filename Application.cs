using System;
using System.Collections.Generic;

namespace _1dv607_boatclub
{
  class Application
  {
    private LayoutView _layoutView;
    private MainController _mainController;
    private MemberController _memberController;
    private Storage _storage;
    public Application()
    {
      _storage = new Storage();
      _layoutView = new LayoutView();
      _mainController = new MainController(_storage);
      _memberController = new MemberController(_storage);
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
        _mainController.runMainMenu();
        
        try
        {

          value = int.Parse(Console.ReadLine());

          if(value <= 0 || value >= 6)
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
              _memberController.editUserInformation();
              break;
            case 5:
              isProgramRunning = false;
              break;
          }
        } catch (Exception)
        {
          Console.WriteLine("Only valid input.\n");
        }
      }
    }
  }
}