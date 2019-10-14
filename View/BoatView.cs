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

        public void addBoat (BoatModel boat)
        {
            int value;
            int boatTypeValue = 0;
            double length;
            bool hasBoatBeenSelected = false;

            while (!hasBoatBeenSelected)
            {
                Console.WriteLine ("\n1: Sailboat\n2: Motorsailer\n3: Kayak\n4: Canoe\n5: Other");
                value = int.Parse (Console.ReadLine ());

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

            Console.WriteLine ("Input the length of the boat\n");
            length = double.Parse (Console.ReadLine ());

            // return new BoatModel ((BoatTypes) boatTypeValue, length);
        }

        public BoatTypes getBoatType ()
        {
            int value;
            int boatTypeValue = 0;
            bool hasBoatBeenSelected = false;

            while (!hasBoatBeenSelected)
            {
                Console.WriteLine ("\n1: Sailboat\n2: Motorsailer\n3: Kayak\n4: Canoe\n5: Other");
                value = int.Parse (Console.ReadLine ());

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
            length = double.Parse (Console.ReadLine ());
            return length;
        }
        public int getIndexOfBoats (List<BoatModel> boats)
        {
            for (int i = 0; i < boats.Count; i++)
            {
                printCustomMessage (i + ": Boat type: " + boats[i].Type);
            }

            return int.Parse (getInput ());
        }
    }
}