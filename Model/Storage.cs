using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace _1dv607_boatclub
{
    class Storage
    {
        private List<MemberModel> _members;
        private string _memberID;
        static string workingDirectory = Environment.CurrentDirectory;

        public Storage ()
        {
            Members = retrieveMembersList ();
        }
        public void saveNewUserToStorage (MemberModel member)
        {
            updateMemberID ();
            member.ID = MemberID;
            Members.Add (member);
            saveToFile (Members);

        }

        public List<MemberModel> retrieveMembersList ()
        {
            using (StreamReader reader = new StreamReader (Path.Combine (workingDirectory, "db.json")))
            {
                var json = reader.ReadToEnd ();
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

        private void updateMemberID ()
        {
            int lastUsedID = int.Parse (getMemberID ());
            lastUsedID += 1;
            MemberID = lastUsedID.ToString ();
            setNewMemberID (MemberID);
        }

        public void saveToFile (List<MemberModel> members)
        {
            StreamWriter writer = null;
            try
            {
                string Memberstring = JsonConvert.SerializeObject (members, Formatting.Indented);

                writer = new StreamWriter (Path.Combine (workingDirectory, "db.json"));
                writer.Write (Memberstring);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close ();
                }
            }
        }

        public string getNewMemberID ()
        {
            int currentID = int.Parse (getMemberID ());
            int newID = currentID + 1;
            setNewMemberID (newID.ToString ());
            return newID.ToString ();
        }

        private void setNewMemberID (string newMemberID)
        {
            StreamWriter writer = null;
            try
            {
                string ID = JsonConvert.SerializeObject (newMemberID, Formatting.Indented);

                writer = new StreamWriter (Path.Combine (workingDirectory, "memberID.json"));
                writer.Write (ID);
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
            using (StreamReader reader = new StreamReader (Path.Combine (workingDirectory, "memberID.json")))
            {
                var json = reader.ReadToEnd ();
                string ID = JsonConvert.DeserializeObject<string> (json);
                return ID;
            }
        }

        public void deleteMember (MemberModel member)
        {
            Members.Remove (member);
            // Members.Remove (Members[Members.FindIndex (i => i.Equals (member))] = member);
            saveToFile (Members);
        }

        public MemberModel getMemberByID (string memberID)
        {
            return Members.Find (u => u.ID == memberID);
        }

        public void updateMember (MemberModel member)
        {
            deleteMember (getMemberByID (member.ID));
            Members.Add (member);
            // Members[Members.FindIndex (i => i.Equals (member))] = member;
            saveToFile (Members);
        }

        public void saveEditedUser (MemberModel member)
        {
            deleteMember (member);
            Members.Add (member);
            saveToFile (Members);
        }

        public List<MemberModel> Members
        {
            get => _members;
            set => _members = value;
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