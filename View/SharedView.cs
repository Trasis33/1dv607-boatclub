using System;

namespace _1dv607_boatclub
{
    abstract class SharedView
    {
        public void printSectionSeparationLine ()
        {
            Console.WriteLine ("");
            Console.WriteLine ("--------------------------------");
            Console.WriteLine ("");
        }

        public void printCustomMessage (string message)
        {
            Console.WriteLine (message);
        }

        public int getMenuInput ()
        {
            return int.Parse (Console.ReadLine ());
        }

        public string getInput ()
        {
            return Console.ReadLine ();
        }
    }
}