using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace storeApp.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Please enter email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [Compare("ConfirmPassword",ErrorMessage = "Password didn't match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }
    }
}
