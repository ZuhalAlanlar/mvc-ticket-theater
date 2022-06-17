using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext context;

        public ActorsController(AppDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            var allActors = context.Actors.ToList();
            return View(allActors);
        }
    }
}
