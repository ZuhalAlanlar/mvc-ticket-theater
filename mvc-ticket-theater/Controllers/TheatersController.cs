using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_ticket_theater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class TheatersController : Controller
    {
        private readonly AppDbContext context;

        public TheatersController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var allTheaters = context.Theaters.Include(s=>s.Saloon).ToList();
            return View(allTheaters);
        }
    }
}
