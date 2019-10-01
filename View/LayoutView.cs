using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class LayoutView
  {
    public LayoutView()
    {
    }
    public void menuOptions () {
      Console.WriteLine("\n1: Add member\n2: Display members\n3: Delete member\n4 Exit\n");
    }

    public void render(string input) {
      var ret = "";
      ret += input;
      Console.WriteLine(ret);
    }
  }
}