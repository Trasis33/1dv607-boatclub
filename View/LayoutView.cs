using System;

namespace _1dv607_boatclub
{
  class LayoutView
  {

    MainController mainController = new MainController();
    public LayoutView()
    {

    }

    public void menu()
    {
        int value;
        bool isProgramRunning = true;
      while(isProgramRunning)
      {
        try
        {

          Console.WriteLine("\n1: Add member\n2: Display members\n3 Exit\n");
          value = int.Parse(Console.ReadLine());

          if(value <= 0 || value >= 4)
          {
            throw new ArgumentOutOfRangeException();
          }

          switch(value)
          {
            case 1:
              mainController.menuSelection(1);
              break;
            case 2:
              mainController.menuSelection(2);
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