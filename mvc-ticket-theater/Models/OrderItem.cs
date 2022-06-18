using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price  { get; set; }
        public int TheaterId { get; set; }
        [ForeignKey("TheaterId")]
        public  Theater Theater { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("TheaterId")]
        public Order Order { get; set; }
    }
}
