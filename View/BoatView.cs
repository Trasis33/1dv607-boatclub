// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace _1dv607_boatclub{
//     class BoatView
//     {
//     public BoatModel getNewMemberCredentials()
//         {
//         string name;
//         string IDNumber;

//         Console.WriteLine("Enter your name:\n");
//         name = Console.ReadLine();

//         Console.WriteLine("Enter your personal ID number:\n");
//         IDNumber = Console.ReadLine();

//         MemberModel user = new MemberModel(name, IDNumber);
//         return user;
//         }

//         public string memberToDeleteById()
//         {
//         string number;

//         System.Console.WriteLine("What user do you wish to delete? Type ID\n");
//         number = Console.ReadLine();
//         return number;
//         }

//         public void showMembersList(List<MemberModel> users)
//         {
//             foreach (MemberModel username in users)
//             {
//             Console.WriteLine(username.ToString("V"));
//             }
//         }
//     }
// }