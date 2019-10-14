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

        // public void deleteMember ()
        // {
        //     string memberID = _memberView.memberToDeleteById ();
        //     _storage.deleteMember (memberID);
        // }
        public void displayMemberByID ()
        {
            MemberModel member = _storage.getMemberByID (_memberView.getID ());
            _memberView.displayMember (member);
        }
        public void editMemberByID ()
        {
            MemberModel member = _storage.getMemberByID (_memberView.memberToEditByID ());
            editUserInformation (member);
        }
        public void deleteMemberByID ()
        {
            MemberModel member = _storage.getMemberByID (_memberView.memberToDeleteById ());
            _storage.deleteMember (member);
        }

        public MemberModel getMemberByID ()
        {
            MemberModel member = _storage.getMemberByID (_memberView.getID ());

            return member;
        }

        // public void showMembersList ()
        // {
        //     var users = _storage.retrieveMembersList ();
        //     _memberView.showMembersList (users);
        // }

        public void editUserInformation (MemberModel member)
        {
            bool success = false;
            // string memberID = _memberView.memberToEditByID ();
            try
            {
                // MemberModel member = _storage.getMemberByID (memberID);
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
                    System.Console.WriteLine (member);
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
    }

}