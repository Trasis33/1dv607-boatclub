using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class BoatController
    {
        BoatView _boatView;
        Storage _storage;
        public BoatController ()
        {
            _boatView = new BoatView ();
            _storage = new Storage ();
        }

        public void addBoatToMember (MemberModel member)
        {
            member.addBoat (new BoatModel (_boatView.getBoatType (), _boatView.getBoatLength ()));
            _storage.updateMember (member);
        }
        public void editBoatInformation (MemberModel member)
        {
            if (member.Boat.Count == 0)
            {
                Console.WriteLine ("No boats found");
            }

            int index = _boatView.getIndexOfBoats (member.Boat);
            BoatModel boat = member.GetBoat (index);
            BoatTypes boatType = _boatView.getBoatType ();
            double boatLength = _boatView.getBoatLength ();

            boat.Type = boatType;
            boat.BoatLength = boatLength;
            _storage.updateMember (member);
        }
        public void deleteBoat (MemberModel member)
        {
            int index = _boatView.getIndexOfBoats (member.Boat);
            BoatModel boat = member.Boat[index];
            member.deleteBoat (boat);
            _storage.updateMember (member);
        }
    }
}