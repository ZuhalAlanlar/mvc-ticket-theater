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
    public class TheaterVM
    {

        [Display(Description ="Tiyatro Adı")]
        public string Name { get; set; }
        [Display(Description = "Açıklama")]
        public string Description { get; set; }
        [Display(Description = "Fotoğraf URL")]
        public string TheaterImg { get; set; }
      
        [Display(Description = "Fiyat")]
        public double Price { get; set; }

        [Display(Description = "Kategori seçiniz")]
        public Category Category { get; set; }
        [Display(Description = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Description = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Description = "Salon Adı")]
        public int SaloonId { get; set; }

        [Display(Description = "Yönetmenler")]
        public int ProducerId { get; set; }

        [Display(Description = "Oyuncular")]
        public List<int> ActorIds { get; set; }

    }
}
