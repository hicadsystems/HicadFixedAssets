using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.ViewModels
{
    public class LoginViewModel
    {
        public string EmailAddress { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Client { get; set; }

        public string MacAddress { get; set; }
    }
}
