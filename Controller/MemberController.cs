using System;

namespace _1dv607_boatclub
{
    class MemberController
    {
        private MemberView _memberView;
        private MemberModel _memberModel;
        private Storage _storage;
        public MemberController ()
        {
            _storage = new Storage ();
            _memberModel = new MemberModel ();
            _memberView = new MemberView (_memberModel);
        }
        public void addMember ()
        {
            MemberModel user = _memberView.getNewMemberCredentials ();
            _storage.saveNewUserToStorage (user);
        }

        public void deleteMember ()
        {
            string memberID = _memberView.memberToDeleteById ();
            _storage.deleteMember (memberID);
        }

        public void showMembersList ()
        {
            var users = _storage.retrieveMembersList ();
            _memberView.showMembersList (users);
        }

        public void editUserInformation ()
        {
            // MemberModel member = _memberView.memberToEdit();
            // member = _memberModel.retriveMemberToEdit();
            // MemberModel editedMember = _memberView.showEditMemberMenu(member);
            // _storage.saveUser(editedMember);
            Console.WriteLine ("DU är i edit usermenyn");
        }

    }

}