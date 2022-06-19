using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_ticket_theater.Data;
using mvc_ticket_theater.Data.Services;
using mvc_ticket_theater.Data.Static;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        
        private readonly IActorsService service;

        public ActorsController(IActorsService service)
        {
            
            this.service = service;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var allActors = service.GetAll();
            return View(allActors);
        }



        #region Create

        public IActionResult Create()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {

                return View(actor);

            }
            service.Add(actor);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details

        public IActionResult Details(int id)
        {
            var actorDetails = service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }

        #endregion

        #region Edit Update
        public IActionResult Edit(int id)
        {
            var actorDetails = service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }


        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {

                return View(actor);

            }
            service.Update(id, actor);
            return RedirectToAction(nameof(Index)); 
        }
        #endregion
        #region Delete
        public IActionResult Delete(int id)
        {
            var actorDetails = service.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);

        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {




            var actorDetails = service.GetById(id);
            if (actorDetails == null) return View("NotFound");

            service.Delete(id);


            return RedirectToAction(nameof(Index));
        } 
        #endregion

    }
}
