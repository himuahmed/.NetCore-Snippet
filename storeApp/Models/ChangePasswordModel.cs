using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace storeApp.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Input current password.")]
        [Display(Name = "Current Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Input New password.")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password didn't match")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New password.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
