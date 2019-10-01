using System;
using System.Collections.Generic;

namespace _1dv607_boatclub
{
  class Application
  {
    private LayoutView _layoutView;
    private MainController _mainController;
    private MemberController _memberController;
    private UserStorage _userStorage;
    public Application()
    {
      _userStorage = new UserStorage();
      _layoutView = new LayoutView();
      _mainController = new MainController(_userStorage);
      _memberController = new MemberController(_userStorage);
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

          if(value <= 0 || value >= 5)
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