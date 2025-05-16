using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Business.Dtos.AppUserDtos
{
   public class AdminLoginViewModel
    {
        //fluent senden uzr isteyirem...(
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
