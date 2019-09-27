using System;
using System.Collections.Generic;

namespace _1dv607_boatclub
{
  class Application
  {
    // public BoatModel _boat;
    public void start()
    {
      bool MemberOrAdmin = menu();
      // _boat = new BoatModel(BoatTypes.Motorsailer, 21);
    }

    public bool menu()
    {

      int value;
      bool isAdmin = false;

      while(true)
      {
        try
        {

          Console.WriteLine("\n1: Add member\n2: Display members\n3 Exit\n");
          value = int.Parse(Console.ReadLine());

          if(value <= 0 || value >= 3)
          {
            throw new ArgumentOutOfRangeException();
          }

          switch(value)
          {
            case 1:
              addMember();
              break;
            // case 2:
            //   displayMembers();
            //   break;
            case 2:
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

    public void addMember()
    {
      string name;
      string IDNumber;

      Console.WriteLine("Enter your name:\n");
      name = Console.ReadLine();

      Console.WriteLine("Enter your personal ID number:\n");
      IDNumber = Console.ReadLine();

      UserModel user = new UserModel(name, IDNumber);
      displayMembers(user);
      return;
    }

    public void displayMembers(UserModel user)
    {
      Console.WriteLine(user.ToString("V"));
    }
  }
}