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
            _members = retrieveMembersList ();
        }
        public void saveNewMemberToStorage (MemberModel member)
        {
            updateMemberID ();
            member.ID = _memberID;
            Members.Add (member);
            saveToFile (Members);

        }

        private List<MemberModel> retrieveMembersList ()
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
            _memberID = lastUsedID.ToString ();
            setNewMemberID (_memberID);
        }

        private void saveToFile (List<MemberModel> members)
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
            saveToFile (Members);
        }

        public MemberModel getMemberByID (string memberID)
        {
            MemberModel member = Members.Find (u => u.ID == memberID);
            if (member != null)
            {
                return member;
            }
            return null;
        }
        public void updateMember (MemberModel member)
        {
            deleteMember (getMemberByID (member.ID));
            Members.Add (member);
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
        }
    }
}