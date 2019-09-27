using System;
using System.Collections.Generic;
namespace _1dv607_boatclub
{
  class Application
  {
    private LayoutView layoutView;
    private UserStorage userStorage;
    private MainController mainController;
    public Application()
    {
    }
    public void run()
    {
      layoutView = new LayoutView();
      userStorage = new UserStorage();
      mainController = new MainController(layoutView, userStorage);
      mainController.menuSelection();
    }
  }
}