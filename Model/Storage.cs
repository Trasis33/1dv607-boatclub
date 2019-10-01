using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class Storage
  {
  private List<MemberModel> _users = new List<MemberModel>();
  private List<BoatModel> _boats = new List<BoatModel>();

    public void saveNewUserToStorage(MemberModel user)
    {
      _users.Add(user);
    }
    public void deleteUser(string userID)
    {
      _users.Remove(_users.Find(u => u.IDNumber == userID));
    }

    public List<MemberModel> retrieveUserList()
    {
      return _users;
    }

    public void saveNewBoatToStorage(BoatModel boat)
    {
      _boats.Add(boat);
    }

    public List<BoatModel> retrieveBoatList()
    {
      return _boats;
    }

  }
}