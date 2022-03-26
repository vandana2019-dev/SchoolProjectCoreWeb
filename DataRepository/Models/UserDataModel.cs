using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class UserDataModel
    {
        [DisplayName("Email")]
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Write(false)]
        public string ConfirmPassword { get; set; }
    }
}
