using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "İsim Soyisim")]
        [Required]
        public string FullName { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Mail adresini giriniz.")]

        public string EmailAdress { get; set; }

        [Required]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Parola Onayla")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Farklı Parola Girdiniz")]
        public string ConfirmPassword { get; set; }
  



    }
}
