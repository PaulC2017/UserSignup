using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSignup.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;




namespace UserSignup.ViewModels
{
    public class AddUserViewModel  
    {

        [Required(ErrorMessage = "A User Name is Required")]
        [Display(Name = "User Name")]
         public string Username { get; set; }

        [Required(ErrorMessage = "A Password of at least 6 characters is Required")]
        [Display(Name = "Password")]
        [StringLength(10, MinimumLength = 6)]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Verify Password Must Match Password")]
        [Display(Name = "Verify Password")]
        [Compare("Password")]
        public string Verify { get; set; }

        [Display(Name = "Email (Optional)")]
        [EmailAddress]
        public string Email { get; set; }
 
        public string CreateDate { get; set; }

        public int UserId { get; set; }

    }
}
