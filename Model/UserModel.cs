using System;

namespace _1dv607_boatclub
{

  class UserModel
  {
      private string _userName;
      private string _userPassword;
      private string _userID;

      public UserModel(string name, string password)
      {
          UserName = name;
          Password = password;
      }

      public string UserName
      {
          get => _userName;
          set
          {
              if(String.IsNullOrWhiteSpace(value))
              {
                  throw new ArgumentException();
              }

              _userName = value;
          }
      }

      public string Password
      {
          get => _userPassword;
          set
          {
              if(String.IsNullOrWhiteSpace(value))
              {
                  throw new ArgumentException();
              }

              _userPassword = value;
          }
      }
  }
}
