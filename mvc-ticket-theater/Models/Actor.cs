using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
      
        [Display(Name = "Oyuncu İsmi")]
        public string FullName { get; set; }
        [Display(Name = "Biyografi")]
        public string Bio { get; set; }

        
        [Display(Name ="Fotoğraf")]
        public string ProfilePictureURL { get; set; }

        public List<Theater_Actor> Theater_Actors { get; set; }
    }
}
