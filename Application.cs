using System;
using System.Collections.Generic;

namespace _1dv607_boatclub
{
  class Application
  {
    public void start()
    {
      bool MemberOrAdmin = menu();
    }

    private bool menu()
    {
      int value;
      bool isAdmin = false;

      while(true)
      {
        try
        {
          Console.WriteLine("\n1: Member login\n2: Admin login\n3 Exit\n");
          value = int.Parse(Console.ReadLine());

          if(value <= 0 || value >= 3)
          {
            throw new ArgumentOutOfRangeException();
          }

          switch(value)
          {
            case 1:
              isAdmin = false;
              break;
            case 2:
              isAdmin = true;
              break;
            case 3:
              Environment.Exit(0);
              break;
          }
          return isAdmin;

        } catch (Exception)
        {
          Console.WriteLine("\n Only valid input.\n");
        }
      }

    }

    // static bool query()
    // {

    // }
  }
}