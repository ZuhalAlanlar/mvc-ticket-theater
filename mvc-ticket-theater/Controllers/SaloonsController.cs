using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class SaloonsController : Controller
    {
        private readonly AppDbContext context;

        public SaloonsController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var allSaloons = context.Saloons.ToList();
            return View(allSaloons);
        }
    }
}
