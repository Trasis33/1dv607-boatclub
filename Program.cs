using System;

namespace _1dv607_boatclub
{
    class Program
    {
        static void Main (string[] args)
        {
            ConsoleView consoleView = new ConsoleView ();
            ConsoleController consoleController = new ConsoleController ();

            while (consoleController.run (consoleView));
        }
    }
}