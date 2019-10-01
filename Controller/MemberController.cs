using System;

namespace _1dv607_boatclub
{
    class MemberController
    {
        private MemberView _memberView;
        private UserStorage _userStorage;
        public MemberController(UserStorage userStorage)
        {
            _userStorage = userStorage;
            _memberView = new MemberView();
        }
        public void addMember()
        {
            MemberModel user = _memberView.getNewMemberCredentials();
            _userStorage.saveNewUserToStorage(user);
        } 

        public void deleteMember()
        {
            string userID = _memberView.memberToDeleteById();
            _userStorage.deleteUser(userID);
        }

        public void showMembersList()
        {
            var users = _userStorage.retrieveUserList();
            _memberView.showMembersList(users);
        }

    }   

}