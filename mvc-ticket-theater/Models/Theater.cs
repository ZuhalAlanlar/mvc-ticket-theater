using mvc_ticket_theater.Data.Base;
using mvc_ticket_theater.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class Theater:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string TheaterImg { get; set; }
        public double Price { get; set; }

        public Category Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int SaloonId { get; set; }
        [ForeignKey("SaloonId")]
        public Saloon Saloon { get; set; }
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

        public List<Theater_Actor> Theater_Actors { get; set; }

    }
}
