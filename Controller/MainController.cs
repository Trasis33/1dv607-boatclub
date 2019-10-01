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
          if(value <= 0 || value >= 5)
          {
            throw new ArgumentOutOfRangeException();
          }
          switch(value)
          {
            case 1:
              user = _layoutView.getNewMemberCredentials();
              _userStorage.saveNewUserToStorage(user);
              break;
            case 2:
              var users = _userStorage.retrieveUserList();
              _layoutView.showMembersList(users);
              break;
            case 3:
              string userID = _layoutView.memberToDeleteById();
              _userStorage.deleteUser(userID);
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