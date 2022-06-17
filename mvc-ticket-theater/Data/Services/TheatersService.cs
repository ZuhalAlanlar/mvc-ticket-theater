using Microsoft.EntityFrameworkCore;
using mvc_ticket_theater.Data.Base;
using mvc_ticket_theater.Data.ViewModels;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Services
{
    public class TheatersService:EntityBaseRepository<Theater>,ITheatersService
    {
        private readonly AppDbContext context;

        public TheatersService(AppDbContext context): base (context)
        {
            this.context = context;
        }

        public void addNewTheater(TheaterVM data)
        {
            var newTheater = new Theater() { 
            
              Name=data.Name,
              Description=data.Description,
              Price=data.Price,
              TheaterImg=data.TheaterImg,
              SaloonId=data.SaloonId,
              StartDate=data.StartDate,
              EndDate=data.EndDate,
              Category=data.Category,
              ProducerId=data.ProducerId

            };

            context.Theaters.Add(newTheater);
            context.SaveChanges();

            foreach (var actorId in data.ActorIds)
            {
                var newActorTheater = new Theater_Actor()
                {
                    TheaterId = newTheater.Id,
                    ActorId = actorId

                };

                context.Theaters_Actors.Add(newActorTheater);
            }
            context.SaveChanges();

        }

        public Theater GetTheaterById(int id)
        {
            var theaterDetails = context.Theaters
                 .Include(s => s.Saloon).Include(p => p.Producer)
                 .Include(ta => ta.Theater_Actors).ThenInclude(a => a.Actor)
                 .FirstOrDefault(n => n.Id == id);
            return theaterDetails;
        }

        #region Theater DropDown
        public TheaterDropdownsVM GetTheaterDropdownsValues()
        {
            var values = new TheaterDropdownsVM()
            {
                Actors = context.Actors.OrderBy(a => a.FullName).ToList(),
                Saloons = context.Saloons.OrderBy(a => a.Name).ToList(),
                Producers = context.Producers.OrderBy(a => a.FullName).ToList()
            };

            return values;

        }
        #endregion
        #region Update
        public void updateTheater(TheaterVM data)
        {
            #region editting
            var dbTheater = context.Theaters.FirstOrDefault(n => n.Id == data.Id);
            if (dbTheater != null)
            {




                dbTheater.Name = data.Name;
                dbTheater.Description = data.Description;
                dbTheater.Price = data.Price;
                dbTheater.TheaterImg = data.TheaterImg;
                dbTheater.SaloonId = data.SaloonId;
                dbTheater.StartDate = data.StartDate;
                dbTheater.EndDate = data.EndDate;
                dbTheater.Category = data.Category;
                dbTheater.ProducerId = data.ProducerId;

                context.SaveChanges();



            }

            #endregion


            #region delete existing data
            var existingActorsDb = context.Theaters_Actors.Where(t => t.TheaterId == data.Id).ToList();
            context.Theaters_Actors.RemoveRange(existingActorsDb);
            context.SaveChanges();

            #endregion


            #region adding actor

            foreach (var actorId in data.ActorIds)
            {
                var newActorTheater = new Theater_Actor()
                {
                    TheaterId = data.Id,
                    ActorId = actorId

                };

                context.Theaters_Actors.Add(newActorTheater);
            }
            context.SaveChanges();
            #endregion
        } 
        #endregion

    }
}
