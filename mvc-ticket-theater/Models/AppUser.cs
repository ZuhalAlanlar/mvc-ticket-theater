using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class AppUser:IdentityUser
    {   [Display(Name="İsim Soyisim")]
        public string FullName { get; set; }


    }
}
