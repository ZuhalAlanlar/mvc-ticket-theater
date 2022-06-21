using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class TheatersController : Controller
    {
        private readonly ITheatersService service;

        public TheatersController(ITheatersService service)
        {
            
            this.service = service;
        }
       
        
        
        [AllowAnonymous]
        public IActionResult Index()
        {

            var allTheaters = service.GetAll(n=>n.Saloon);
            return View(allTheaters);
        }
        [AllowAnonymous]
        public IActionResult Filter(string searchString)
        {

            var allTheaters = service.GetAll(n => n.Saloon);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allTheaters.Where(t => t.Name.Contains(searchString) || t.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index",allTheaters);
        }

        #region Details
      [AllowAnonymous]
        public IActionResult Details(int id)
        {


            var theaterDetails = service.GetTheaterById(id);
            return View(theaterDetails);


        }
        #endregion
        #region Create

        public IActionResult Create()
        {
            var theaterDropdownsValue = service.GetTheaterDropdownsValues();

            ViewBag.Saloons = new SelectList(theaterDropdownsValue.Saloons, "Id", "Name");
            ViewBag.Producers = new SelectList(theaterDropdownsValue.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(theaterDropdownsValue.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(TheaterVM theater)
        {

            if(!ModelState.IsValid)
            {
                var theaterDropdownsValue = service.GetTheaterDropdownsValues();

                ViewBag.Saloons = new SelectList(theaterDropdownsValue.Saloons, "Id", "Name");
                ViewBag.Producers = new SelectList(theaterDropdownsValue.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(theaterDropdownsValue.Actors, "Id", "FullName");

                return View();

            }

            service.addNewTheater(theater);
            return RedirectToAction(nameof(Index));

            
        }


        #endregion
        public IActionResult Edit(int id)
        {
            var theaterDetails = service.GetTheaterById(id);
            if (theaterDetails == null) return View("NotFound");

            var values = new TheaterVM()
            {
                Id = theaterDetails.Id,
                ProducerId = theaterDetails.ProducerId,
                ActorIds = theaterDetails.Theater_Actors.Select(a => a.ActorId).ToList(),
                SaloonId = theaterDetails.SaloonId,
                Price = theaterDetails.Price,
                TheaterImg = theaterDetails.TheaterImg,
                StartDate = theaterDetails.StartDate,
                EndDate=theaterDetails.EndDate,
                Category=theaterDetails.Category,
                Name=theaterDetails.Name,
                Description=theaterDetails.Description,
                








            }; 

            var theaterDropdownsValue = service.GetTheaterDropdownsValues();

            ViewBag.Saloons = new SelectList(theaterDropdownsValue.Saloons, "Id", "Name");
            ViewBag.Producers = new SelectList(theaterDropdownsValue.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(theaterDropdownsValue.Actors, "Id", "FullName");

            return View(values);
        }

        [HttpPost]
        public IActionResult Edit(int id,TheaterVM theater)
        {   if(id!=theater.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var theaterDropdownsValue = service.GetTheaterDropdownsValues();

                ViewBag.Saloons = new SelectList(theaterDropdownsValue.Saloons, "Id", "Name");
                ViewBag.Producers = new SelectList(theaterDropdownsValue.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(theaterDropdownsValue.Actors, "Id", "FullName");

                return View(theater);
            }

            service.updateTheater(theater);
            return RedirectToAction(nameof(Index));


        }






    }
}
