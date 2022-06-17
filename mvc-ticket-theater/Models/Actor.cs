using mvc_ticket_theater.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
      
        [Display(Name = "Oyuncu İsmi")]
        [Required(ErrorMessage = "Oyuncu İsmini Giriniz")]
        public string FullName { get; set; }
      
        [Display(Name = "Biyografi")]

        public string Bio { get; set; }

        
        [Display(Name ="Fotoğraf")]
        [Required(ErrorMessage ="Fotoğraf URL Giriniz")]
        public string ProfilePictureURL { get; set; }

        public List<Theater_Actor> Theater_Actors { get; set; }
    }
}
