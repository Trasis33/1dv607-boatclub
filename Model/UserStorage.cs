using System;
using System.Collections.Generic;
using System.Linq;
namespace _1dv607_boatclub
{
  class UserStorage
  {
  private List<UserModel> _users = new List<UserModel>();
    public void saveNewUserToStorage(UserModel user)
    {
      _users.Add(user);
    }
    public void deleteUser(string userID)
    {
      _users.Remove(_users.Find(u => u.IDNumber == userID));
    }
    public List<UserModel> retrieveUserList()
    {
      return _users;
    }
  }
}