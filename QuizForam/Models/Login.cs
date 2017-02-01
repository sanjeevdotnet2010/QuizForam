﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizForam.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User Name is required"), 
            StringLength(50,ErrorMessage = " UserName Can not be Greter Than 50"),
            DisplayName("User Name")]       
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required"),
           StringLength(50, ErrorMessage = " Password Can not be Greter Than 50"),
           DisplayName("Password")]
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}