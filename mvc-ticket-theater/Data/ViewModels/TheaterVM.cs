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

        [Display(Name ="Tiyatro Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Fotoğraf URL")]
        public string TheaterImg { get; set; }
      
        [Display(Name = "Fiyat")]
        public double Price { get; set; }

        [Display(Name = "Kategori seçiniz")]
        public Category Category { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Salon Adı")]
        public int SaloonId { get; set; }

        [Display(Name = "Yönetmenler")]
        public int ProducerId { get; set; }

        [Display(Name = "Oyuncular")]
        public List<int> ActorIds { get; set; }

    }
}
