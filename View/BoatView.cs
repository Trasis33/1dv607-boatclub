using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub{
    class BoatView
    {
    public BoatModel getNewBoatInformation()
        {
        int type; // choose type
        double length;  // enter length

        BoatTypes newBoat = BoatTypes.Other;
        bool hasBoatBeenSelected = false;

            selectBoatTypes();
            while(!hasBoatBeenSelected)
            {
            type = int.Parse(Console.ReadLine());

            var boats = Enum.GetValues(typeof(BoatTypes));

            foreach(BoatTypes boatType in boats)
            {
              if(type == ((int)boatType))
              {
                newBoat = boatType;
                hasBoatBeenSelected = true;
              }
            }
            }

          Console.WriteLine("Input the length of the boat\n");
          length = double.Parse(Console.ReadLine());

          BoatModel boat = new BoatModel(newBoat, length);
          return boat;

        }

        public void selectBoatTypes () {
        Console.WriteLine("\n1: Sailboat\n2: Motorsailer\n3: Kayak\n4: Canoe\n5: Other");
        }

        public string boatToDeleteById()
        {
        string number;

        System.Console.WriteLine("What user do you wish to delete? Type ID\n");
        number = Console.ReadLine();
        return number;
        }

        public void showBoatsList(List<BoatModel> boats)
        {
            foreach (BoatModel boat in boats)
            {
            Console.WriteLine(boat.showBoat());
            }
        }
    }
}