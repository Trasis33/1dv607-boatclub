using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class LayoutView : SharedView
    {
        public LayoutView () { }
        public void menuOptions ()
        {
            SharedView.printSectionSeparationLine ();
            Console.WriteLine ("1: Add member\n2: Display members\n3: Delete member\n4: Edit Member\n5: Exit");
            SharedView.printSectionSeparationLine ();
        }

        public void render (string input)
        {
            var ret = "";
            ret += input;
            Console.WriteLine (ret);
        }
    }
}