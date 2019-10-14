using System;
using System.Collections.Generic;
using System.Linq;

namespace _1dv607_boatclub
{
    class MemberController
    {
        private MemberView _memberView;
        private Storage _storage;
        public MemberController ()
        {
            _storage = new Storage ();
            _memberView = new MemberView ();
        }
        public void addMember ()
        {
            MemberModel member = new MemberModel (_memberView.getMemberName (), _memberView.getPersonalNumber ());
            _storage.saveNewUserToStorage (member);
            _memberView.displayMember (member);
        }
        public void displayMemberByID ()
        {
            MemberModel member = checkIfMemberExists ();
            _memberView.displayMember (member);

        }

        public void editMemberByID ()
        {
            MemberModel member = checkIfMemberExists ();
            editUserInformation (member);
        }
        public void deleteMemberByID ()
        {
            MemberModel member = checkIfMemberExists ();
            _storage.deleteMember (member);
        }

        public MemberModel getMemberByID ()
        {
            MemberModel member = checkIfMemberExists ();
            return member;
        }
        public MemberModel checkIfMemberExists ()
        {
            while (true)
            {
                try
                {
                    MemberModel member = _storage.getMemberByID (_memberView.getID ());
                    return member;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine ("No member found");
                }
            }
        }
        public void editUserInformation (MemberModel member)
        {
            bool success = false;
            try
            {
                bool correctMember = _memberView.confirmMemberToEdit (member);

                if (correctMember)
                {
                    MemberModel editedMember = _memberView.memberToEdit (member);
                    _storage.saveEditedUser (editedMember);
                }
                else
                {
                    editUserInformation (member);
                }

                if (member != null)
                {
                    success = true;
                }

                if (!success)
                {
                    throw new ArgumentException ();
                }
                else
                {
                    System.Console.WriteLine ("Membername: " + member.UserName + "\nPersonal number: " + member.PersonalNumber);
                }

            }
            catch (Exception)
            {
                System.Console.WriteLine ("Something went wrong when getting the user");
            }
        }
        public void showCompactList ()
        {
            _memberView.showCompactMemberList (_storage.Members);
        }

        public void showVerboseList ()
        {
            _memberView.showVerboseMemberList (_storage.Members);
        }
    }

}