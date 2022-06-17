using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext context;

        public ProducersController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var allProducers = context.Producers.ToList();
            return View(allProducers);
        }
    }
}
