using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.DTOs.AppUserDtos
{
    public class AppUserRegisterDto
    {
        //[Required(ErrorMessage ="Ad alnı zorunludur")]
        //[Display(Name ="İsim")]
        //[MaxLength(30,ErrorMessage ="en fazla 30 karakte rimelisiniz")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Confirmpassword { get; set; }
    }
}
