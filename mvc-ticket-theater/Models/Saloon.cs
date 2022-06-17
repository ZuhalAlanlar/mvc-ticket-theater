using mvc_ticket_theater.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class Saloon:IEntityBase
    {
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "Salon")]
        public string Name { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Display(Name = "Fotoğraf")]
        public string SaloonImg { get; set; }

        public List<Theater> Theaters { get; set; }
    }
}
