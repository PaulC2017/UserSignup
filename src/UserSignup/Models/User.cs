using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class User
    {
        // TODO 1: Add UserId, CreateDate and a few more properties of your choosing.  Update the Add and Index views 
        // TODO 1: completed
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreateDate { get; set; }
        

        public int UserId { get; set; }
        private static int nextId = 1;

        //non default constructor
        public User(string username, string email, string password) :this()
        {
            Username = username;
            Email = email;
            Password = password;
           
        }

        //default constructor
        public User()
        {
            UserId = nextId;
            nextId++;
            CreateDate = DateTime.Today.ToString("MM/dd/yyyy");
           

        }
        
    }
}





