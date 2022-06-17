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


        #region Create
        public IActionResult Create()
        { return View(); }


        [HttpPost]

        public IActionResult Create([Bind("ProfilePictureURL,Bio,FullName")] Producer producer)
        {

            if (!ModelState.IsValid) return View(producer);
            service.Add(producer);
            return RedirectToAction(nameof(Index));

        }
        #endregion
        #region Edit
        public IActionResult Edit(int id)
        {
            var producerDetails = service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);

        }


        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {

                return View(producer);

            }

            if (id == producer.Id)
            {
                service.Update(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        #endregion

        public IActionResult Delete(int id)
        {
            var producerDetails = service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);

        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails = service.GetById(id);
            if (producerDetails == null) return View("NotFound");
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
