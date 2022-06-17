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
    public class SaloonsController : Controller
    {
        private readonly ISaloonsService service;

        public SaloonsController(ISaloonsService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var allSaloons = service.GetAll();
            return View(allSaloons);
        }

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create([Bind("Name,Adress,SaloonImg")] Saloon saloon)
        {
            if (!ModelState.IsValid) return View(saloon);
            service.Add(saloon);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            var saloonDetails = service.GetById(id);
            if (saloonDetails == null) return View("NotFound");
            return View(saloonDetails);
        }


        #endregion
        #region Edit
        public IActionResult Edit(int id)
        {
            var saloonDetails = service.GetById(id);
            if (saloonDetails == null) return View("NotFound");
            return View(saloonDetails);
        }

        [HttpPost]

        public IActionResult Edit(int id, [Bind("Id,Name,Adress,SaloonImg")] Saloon saloon)
        {
            if (!ModelState.IsValid) return View(saloon);
            service.Update(id, saloon);
            return RedirectToAction(nameof(Index));
        }
        #endregion
        public IActionResult Delete(int id)
        {
            var saloonDetails = service.GetById(id);
            if (saloonDetails == null) return View("NotFound");
            return View(saloonDetails);
        }

        [HttpPost,ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            var saloonDetails = service.GetById(id);
            if (saloonDetails == null) return View("NotFound");
            service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
