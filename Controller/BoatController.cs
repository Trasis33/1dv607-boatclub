using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class BoatController
    {
        BoatView _boatView;
        Storage _storage;
        const int RETURN_TO_MENU = -1;
        public BoatController ()
        {
            _boatView = new BoatView ();
            _storage = new Storage ();
        }

        public void addBoatToMember (MemberModel member)
        {
            if (member == null)
            {
                return;
            }
            member.addBoat (new BoatModel (_boatView.getBoatType (), _boatView.getBoatLength ()));
            _storage.updateMember (member);
        }
        public void editBoatInformation (MemberModel member)
        {
            if (member == null)
            {
                return;
            }
            if (member.Boat.Count == 0)
            {
                Console.WriteLine ("No boats found");
            }

            int index = _boatView.getIndexOfBoats (member.Boat);
            if (index == RETURN_TO_MENU)
            {
                return;
            }
            BoatModel boat = member.GetBoat (index);
            BoatTypes boatType = _boatView.getBoatType ();
            double boatLength = _boatView.getBoatLength ();

            boat.Type = boatType;
            boat.BoatLength = boatLength;
            _storage.updateMember (member);
        }
        public void deleteBoat (MemberModel member)
        {
            if (member == null)
            {
                return;
            }
            int index = _boatView.getIndexOfBoats (member.Boat);
            if (index == RETURN_TO_MENU)
            {
                return;
            }
            BoatModel boat = member.Boat[index];
            member.deleteBoat (boat);
            _storage.updateMember (member);
        }
    }
}