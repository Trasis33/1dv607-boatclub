using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class BoatView : SharedView
    {
        const int DEFAULT_BOAT_VALUE = 0;
        const int DEFAULT_BOAT_LENGTH = 0;
        const int RETURN_TO_MENU = -1;
        public BoatView ()
        {

        }
        public BoatTypes getBoatType ()
        {
            int value;
            int boatTypeValue = DEFAULT_BOAT_VALUE;
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
                return DEFAULT_BOAT_LENGTH;
            }
            length = double.Parse (input);
            return length;
        }
        public int getIndexOfBoats (List<BoatModel> boats)
        {
            if (boats.Count == 0)
            {
                printCustomMessage ("Member has no registered boats, returning to menu");
                return RETURN_TO_MENU;
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
                return RETURN_TO_MENU;
            }
            else
            {
                input = int.Parse (stringInput);
                if (input > boats.Count)
                {
                    printCustomMessage ("Boat does not exist, returning to menu");
                    return RETURN_TO_MENU;
                }
                return input;
            }

        }
    }
}