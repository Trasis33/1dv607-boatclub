using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class UserStorage
  {
  private List<MemberModel> _users = new List<MemberModel>();

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

  }
}