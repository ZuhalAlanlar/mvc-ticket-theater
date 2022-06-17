using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using mvc_ticket_theater.Data.Services;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    public class ActorsController : Controller
    {
        
        private readonly IActorsService service;

        public ActorsController(IActorsService service)
        {
            
            this.service = service;
        }


        public IActionResult Index()
        {
            var allActors = service.GetAll();
            return View(allActors);
        }




        public IActionResult Create()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {  
            if(!ModelState.IsValid)
            {

                return View(actor);

            }
            service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
