using System;

namespace _1dv607_boatclub
{
  class BoatController
  {
    private BoatView _boatView;
    private Storage _storage;

    public BoatController(Storage storage)
    {
      _boatView = new BoatView();
      _storage = storage;
    }

    public void addBoat()
        {
            BoatModel boat = _boatView.getNewBoatInformation();

            _storage.saveNewBoatToStorage(boat);
        }

        // public void deleteBoat()
        // {
        //     string boatID = _boatView.boatToDeleteById();
        //     _storage.deleteUser(boatID);
        // }

        public void showBoatsList()
        {
            var boats = _storage.retrieveBoatList();
            _boatView.showBoatsList(boats);
        }
  }
}