using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class BoatView : SharedView
    {
        public BoatView ()
        {

        }
        public BoatTypes getBoatType ()
        {
            int value;
            int boatTypeValue = 0;
            bool hasBoatBeenSelected = false;

            while (!hasBoatBeenSelected)
            {
                Console.WriteLine ("\n1: Sailboat\n2: Motorsailer\n3: Kayak\n4: Canoe\n5: Other\n (leaving empty sets boat to 'other')");
                string input = getInput ();
                if (input == "")
                {
                    return (BoatTypes) 5;
                }
                value = int.Parse (input);

                if (!Enum.IsDefined (typeof (BoatTypes), value))
                {
                    Console.WriteLine ("Not a valid type");
                }
                else
                {
                    hasBoatBeenSelected = true;
                }

                boatTypeValue = value;
            }
            return (BoatTypes) boatTypeValue;
        }

        public double getBoatLength ()
        {
            double length;

            Console.WriteLine ("Input the length of the boat\n");
            string input = getInput ();
            if (input == "")
            {
                return 0;
            }
            length = double.Parse (input);
            return length;
        }
        public int getIndexOfBoats (List<BoatModel> boats)
        {
            if (boats.Count == 0)
            {
                printCustomMessage ("Member has no registered boats, returning to menu");
                return -1;
            }
            for (int i = 0; i < boats.Count; i++)
            {
                printCustomMessage (i + ": Boat type: " + boats[i].Type);
            }

            string stringInput = getInput ();
            int input;
            if (stringInput.Any (char.IsLetter) || stringInput == "")
            {
                printCustomMessage ("Invalid input, needs to be a number. Returning to menu");
                return -1;
            }
            else
            {
                input = int.Parse (stringInput);
                if (input > boats.Count)
                {
                    printCustomMessage ("Boat does not exist, returning to menu");
                    return -1;
                }
                return input;
            }

        }
    }
}