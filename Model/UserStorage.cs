using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
  class UserStorage
  {
  private List<UserModel> _users = new List<UserModel>();

    public void saveToStorage(UserModel user)
    {
      _users.Add(user);
    }

    public List<UserModel> retrieveUserList()
    {
      return _users;
    }
  }
}