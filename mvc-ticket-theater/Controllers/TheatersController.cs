using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_ticket_theater.Data;
using mvc_ticket_theater.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class TheatersController : Controller
    {
        private readonly ITheatersService service;

        public TheatersController(ITheatersService service)
        {
            
            this.service = service;
        }
        public IActionResult Index()
        {

            var allTheaters = service.GetAll(n=>n.Saloon);
            return View(allTheaters);
        }
    }
}
