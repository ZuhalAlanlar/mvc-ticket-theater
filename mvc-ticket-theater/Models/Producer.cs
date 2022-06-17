using mvc_ticket_theater.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Yönetmen İsmi")]
        public string FullName { get; set; }
        [Display(Name = "Biyografi")]
        public string Bio { get; set; }
        [Display(Name = "Fotoğraf ")]
        public string ProfilePictureURL { get; set; }

        public List<Theater> Theaters { get; set; }
    }
}
