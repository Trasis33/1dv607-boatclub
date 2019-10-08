using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace _1dv607_boatclub
{
    class Storage
    {
        private List<MemberModel> _users = new List<MemberModel> ();
        static string workingDirectory = Environment.CurrentDirectory;
        public void saveNewUserToStorage (MemberModel user)
        {
            _users.Add (user);
            saveToFile (_users);

        }
        public void deleteUser (string userID)
        {
            _users.Remove (_users.Find (u => u.IDNumber == userID));
        }

        public List<MemberModel> retrieveUserList ()
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader (Path.Combine (workingDirectory, "db.json")))
            {
                var json = r.ReadToEnd ();
                List<MemberModel> users = JsonConvert.DeserializeObject<List<MemberModel>> (json);
                _users = users;
                return _users;
            }
            // return _users;
        }

        public void saveToFile (List<MemberModel> members)
        {
            StreamWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject (members);
                writer = new StreamWriter (Path.Combine (workingDirectory, "db.json"));

                string userString = JsonConvert.SerializeObject (members, Formatting.Indented);

                writer.Write (userString);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close ();
                }
            }
        }

        // public void saveNewBoatToStorage(BoatModel boat)
        // {
        //   _boats.Add(boat);
        // }

        // public List<BoatModel> retrieveBoatList()
        // {
        //   return _boats;
        // }

    }
}