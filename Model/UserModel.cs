using System;
using System.Text.RegularExpressions;

namespace _1dv607_boatclub
{

  class UserModel
  {
      private string _userName;
      private string _IDNumber;
      Regex rx = new Regex("^[0-9]+$");
      // private string _userID;

      public UserModel(string name, string ID)
      {
          UserName = name;
          IDNumber = ID;
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

      public string IDNumber
      {
          get => _IDNumber;
          set
          {
              if(String.IsNullOrWhiteSpace(value) && !rx.IsMatch(value))
              {
                  throw new ArgumentException();
              }

              _IDNumber = value;
          }
      }

      public override string ToString()
    {
      return ToString("C");
    }

    public string ToString(string format)
    {
      if(string.IsNullOrWhiteSpace(format))
      {
        format = "C";
      }

      switch (format)
      {
        case "C":
          return string.Format("{0}", UserName);
        case "V":
          return string.Format("{0} {1}", UserName, IDNumber);
        default:
        string msg = string.Format("'{0}' is an invalid format string.", format);
        throw new ArgumentException(msg);
      }
    }
  }
}
