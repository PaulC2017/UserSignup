using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModels;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        //public IActionResult Index(User user)
        {
            //TODO 3: update this to get all users from your UserData class
            // and return it to the view.  Update the view to display some user data.

            // List<User> users = new List<User>(UserData.GetAll());
            // List<User> users = new List<User>();
            // users = UserData.GetAll();
            // return View(users);

            //List<User> users = new List<User>();
            //users = UserData.GetAll();

            List<User> users = UserData.GetAll();

            return View(users);

            /* if (users.Count == 0)
             {
                 user = new User();
                 //use with the else statement
                 List<User> newUser = new List<User>();
                 newUser.Add(user);
                // ViewBag.newUserName = user.Username;
                 return View(newUser);  
             }
             //return View(user);  // used if the else statement is   commented out

             else
              {

                 //var  users = from allUsers in UserData.GetAll()
                 // select allUsers;

                 //List<User> users = new List<User>();
                // users = UserData.GetAll();


                 return View(users);

              }
              */
        }

        // TODO 4: add a details controller and view that takes a single userid,
        // gets that user object from UserData, returns it to the details view
        // where it is displayed

        [HttpGet]
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);
        }

        [HttpPost]
        [Route("/User/Add")]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                User newUser = new User(addUserViewModel.Username, addUserViewModel.Email, addUserViewModel.Password);
                /* {
                     Username = addUserViewModel.Username,
                     Email = addUserViewModel.Email,
                     Password = addUserViewModel.Password

                 };
                 */
                UserData.AddUser(newUser);

                // return RedirectToAction("Index", new { id = newUser.UserId} );
                ViewData["name"] = newUser.Username;
                return Redirect("/User");
            }
            /*else
            {
                ViewBag.PasswordError = user.Password != verify ? "Your passwords must match" : "";
                ViewBag.UsernameError = String.IsNullOrEmpty(user.Username) ? "You must enter a username" : "";
                ViewBag.users = UserData.GetAll();
                return View(user);
            }
            */

            /*
             * string test = "Aasdf345ÅÄÖåäöéÉóÓüÜïÏôÔ";
            if (test.All(Char.IsLetterOrDigit)) { ... }
             * 
             * userName.All(Char.IsLetter))
             * 
             * */
            return View(addUserViewModel);
        }

        public bool CheckUserName(User checkMe)
        {
            if ((checkMe.Username.Length < 5 || checkMe.Username.Length > 15) || !checkMe.Username.All(Char.IsLetter))
            {
                ViewBag.UserNameContentError = "The User Name Must contain only letters and be Between 5 and 15 characters long";
                return false;
            }
            return true;
        }

        
        public IActionResult Detail(int id)
        {
           ViewBag.user = UserData.GetById(id);
            ViewBag.title = "Member Detail";
            return View();
        }
    }
}