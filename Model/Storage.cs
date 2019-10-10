using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace _1dv607_boatclub
{
    class Storage
    {
        private List<MemberModel> _users;
        private string _memberID;
        static string workingDirectory = Environment.CurrentDirectory;

        public Storage ()
        {
            _users = retrieveUserList ();
        }
        public void saveNewUserToStorage (MemberModel user)
        {
            updateMemberID ();
            user.ID = MemberID;
            _users.Add (user);
            saveToFile (_users);

        }
        public void deleteUser (string userID)
        {
            _users.Remove (_users.Find (u => u.PersonalNumber == userID));
        }

        public List<MemberModel> retrieveUserList ()
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader (Path.Combine (workingDirectory, "db.json")))
            {
                var json = r.ReadToEnd ();
                if (json.Length == 0)
                {
                    return new List<MemberModel> ();
                }
                else
                {
                    return JsonConvert.DeserializeObject<List<MemberModel>> (json);
                }
            }
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

        private void setNewMemberID (string newMemberID)
        {
            StreamWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject (newMemberID);
                writer = new StreamWriter (Path.Combine (workingDirectory, "memberID.json"));

                string IDString = JsonConvert.SerializeObject (newMemberID, Formatting.Indented);

                writer.Write (IDString);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close ();
                }
            }
        }

        private string getMemberID ()
        {
            string result = string.Empty;

            using (StreamReader r = new StreamReader (Path.Combine (workingDirectory, "memberID.json")))
            {
                var json = r.ReadToEnd ();
                string memberID = JsonConvert.DeserializeObject<string> (json);
                return memberID;
            }
        }

        private void updateMemberID ()
        {
            int lastUsedID = int.Parse (getMemberID ());
            lastUsedID += 1;
            MemberID = lastUsedID.ToString ();
            setNewMemberID (MemberID);
        }

        public string MemberID
        {
            get => _memberID;
            set
            {
                _memberID = value;
            }
        }
    }
}