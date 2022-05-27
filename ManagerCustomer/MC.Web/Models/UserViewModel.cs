using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MC.Web.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "User Name")]
        //[Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
    }
}
