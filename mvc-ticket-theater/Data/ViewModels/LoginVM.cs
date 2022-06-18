using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.ViewModels
{
    public class LoginVM
    {   
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Mail adresini giriniz.")]

        public string EmailAdress { get; set; }
  
        [Required]
        [Display(Name ="Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
