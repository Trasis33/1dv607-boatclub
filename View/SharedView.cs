using System;

namespace _1dv607_boatclub
{
    abstract class SharedView
    {
        public static void printSectionSeparationLine ()
        {
            Console.WriteLine ("");
            Console.WriteLine ("--------------------------------");
            Console.WriteLine ("");
        }

        public static void printCustomMessage (string message)
        {
            Console.WriteLine (message);
        }

        public static int getMenuInput ()
        {
            return int.Parse (Console.ReadLine ());
        }

        public static string getInput ()
        {
            return Console.ReadLine ();
        }
    }
}