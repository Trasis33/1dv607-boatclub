using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class MainController
  {
    LayoutView _layoutView;
    UserStorage _userStorage;

    public MainController(LayoutView layoutView, UserStorage userStorage)
    {
      _layoutView = layoutView;
      _userStorage = userStorage;
    }

    public void menuSelection()
    {

        int value;
        bool isProgramRunning = true;

        UserModel user;

      while(isProgramRunning)
      {
        try
        {
          _layoutView.menuOptions();

          value = int.Parse(Console.ReadLine());

          if(value <= 0 || value >= 4)
          {
            throw new ArgumentOutOfRangeException();
          }

          switch(value)
          {
            case 1:
              user = _layoutView.addMember();
              _userStorage.saveToStorage(user);
              var users = new List<UserModel>();
              users = _userStorage.retrieveUserList();
              foreach (UserModel username in users)
              {
                Console.WriteLine(username.ToString("V"));
              }
              break;
            case 2:

              break;
            case 3:
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