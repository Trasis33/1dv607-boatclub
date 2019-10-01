using System;
using System.Collections.Generic;
using System.Linq;
namespace _1dv607_boatclub
{
  class LayoutView
  {
    // MainController mainController = new MainController();
    public LayoutView()
    {
    }
    public void menuOptions () {
      Console.WriteLine("\n1: Add member\n2: Display members\n3: Delete member\n4 Exit\n");
    }
    public UserModel getNewMemberCredentials()
    {
      string name;
      string IDNumber;
      Console.WriteLine("Enter your name:\n");
      name = Console.ReadLine();
      Console.WriteLine("Enter your personal ID number:\n");
      IDNumber = Console.ReadLine();
      UserModel user = new UserModel(name, IDNumber);
      return user;
    }
    public string memberToDeleteById()
    {
      string number;
      System.Console.WriteLine("What user do you wish to delete? Type ID\n");
      number = Console.ReadLine();
      return number;
    }
    public void showMembersList(List<UserModel> users)
    {
        foreach (UserModel username in users)
        {
          Console.WriteLine(username.ToString("V"));
        }
    }
    public void render(string input) {
      var ret = "";
      ret += input;
      Console.WriteLine(ret);
    }
  }
}