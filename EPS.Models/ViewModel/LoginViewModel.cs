using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EPS.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Please enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Please enter password")]
        public string Password { get; set; }

        public string TimezoneOffset { get; set; }

        public string Remember { get; set; }

        public string ReturnUrl { get; set; }
    }
}
