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

        public void addBoat ()
        {
            string member = _memberView.memberToEditByID ();
            MemberModel memberToEdit = _storage.getMemberByID (member);

            BoatModel boat = _memberView.addBoat ();

            MemberModel updatedMember = _memberModel.addBoatToExistingMember (memberToEdit, boat);
            _storage.saveEditedUser (updatedMember);
        }

        public void showMembersList ()
        {
            var users = _storage.retrieveMembersList ();
            _memberView.showMembersList (users);
        }

        public void editUserInformation ()
        {
            bool success = false;
            string memberID = _memberView.memberToEditByID ();
            try
            {
                MemberModel member = _storage.getMemberByID (memberID);
                bool correctMember = _memberView.confirmMemberToEdit (member);

                if (correctMember)
                {
                    MemberModel editedMember = _memberView.memberToEdit (member);
                    _storage.saveEditedUser (editedMember);
                }
                else
                {
                    editUserInformation ();
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

    }

}