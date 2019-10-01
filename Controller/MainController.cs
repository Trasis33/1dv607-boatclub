using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class MainController
  {
    LayoutView _layoutView;
    UserStorage _userStorage;

    public MainController(UserStorage userStorage)
    {
      _layoutView = new LayoutView();
      _userStorage = userStorage;
    }    
  }
}