using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ViewModels.Users
{
    public class AccountRegisterVm
    {
        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Please enter ypur {0}")]
        public string FullName { get; set; }
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Your {0} Is not Correct")]
        [Required(ErrorMessage ="Please enter your {0}")]
        public string Email { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Please enter your {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Please {0}")]
        [Compare(nameof(Password) , ErrorMessage ="{0} is not correct")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [Display(Name ="Mobile")]
        public string Mobile { get; set; }
    }

    public class AccountLoginVm
    {
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Your {0} Is not Correct")]
        [Required(ErrorMessage = "Please enter your {0}")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool IsRemember { get; set; }
    }
}
