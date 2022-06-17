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
    public class ProducersController : Controller
    {
        private readonly IProducersService service;

        public ProducersController(IProducersService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var allProducers = service.GetAll();
            return View(allProducers);
        }

        #region Details

        public IActionResult Details(int id)
        {
            var producerDetails = service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);

        }

        #endregion


        public IActionResult Create()
        { return View(); }


        [HttpPost]

        public IActionResult Create([Bind("ProfilePictureURL,Bio,FullName")] Producer producer)
        {

            if (!ModelState.IsValid) return View(producer);
            service.Add(producer);
            return RedirectToAction(nameof(Index));

        }

    }
}
