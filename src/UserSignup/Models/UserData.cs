using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UserSignup.Models
{
    public class UserData
    {

        //TODO 2: instantiate a few new users in code here and add them to your users list
        //then write methods to add users to your list, return all users and return a user by UserId
        // Completed


        // add users to the list as part of this program
        static private List<User> users = new List<User>
        {

         new User("User1", "user1@email.com", "user1password"),
         new User("User2", "user2@email.com", "user2password"),
         new User("User3", "user3@email.com", "user3password"),
         new User("User4", "user4@email.com", "user4password"),
         new User("User5", "user5@email.com", "user5password"),
         new User("User6", "user6@email.com", "user6password")
        };

        
       
        public static void AddUserFromText(string userName, string userEmail, string password)
        {
             users.Add(new User(userName, userEmail, password));
        }

        public  static void AddUser(User userToAdd)
        {
            users.Add(userToAdd);
        }



        public static List<User> GetAll()
        {
            return users;
        }

        public static  User GetById(int UserId)
        {
             
            return users.Single(user => user.UserId == UserId);
        }

       


    }
}
