using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.ViewModels
{
    public class TheaterDropdownsVM
    {
        public TheaterDropdownsVM()
        {
            Actors = new List<Actor>();
            Producers = new List<Producer>();
            Saloons = new List<Saloon>();
        }

        public List<Actor> Actors { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Saloon> Saloons { get; set; }

    }
}
