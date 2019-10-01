using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class MainController
  {
    LayoutView _layoutView;
    Storage _storage;

    public MainController(Storage storage)
    {
      _layoutView = new LayoutView();
      _storage = storage;
    }
  }
}