using System;

namespace _1dv607_boatclub
{
    class MemberController
    {
        private MemberView _memberView;
        private Storage _storage;
        public MemberController(Storage storage)
        {
            _storage = storage;
            _memberView = new MemberView();
        }
        public void addMember()
        {
            MemberModel user = _memberView.getNewMemberCredentials();
            _storage.saveNewUserToStorage(user);
        }

        public void deleteMember()
        {
            string userID = _memberView.memberToDeleteById();
            _storage.deleteUser(userID);
        }

        public void showMembersList()
        {
            var users = _storage.retrieveUserList();
            _memberView.showMembersList(users);
        }

        public void editUserInformation() {
            // MemberModel member = _memberView.memberToEdit();
            // member = _memberModel.retriveMemberToEdit();
            // MemberModel editedMember = _memberView.showEditMemberMenu(member);
            // _storage.saveUser(editedMember);
            Console.WriteLine("DU är i edit usermenyn");
        }

    }

}