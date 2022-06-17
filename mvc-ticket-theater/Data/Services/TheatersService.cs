using Microsoft.EntityFrameworkCore;
using mvc_ticket_theater.Data.Base;
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

        public Theater GetTheaterById(int id)
        {
            var theaterDetails = context.Theaters
                 .Include(s => s.Saloon).Include(p => p.Producer)
                 .Include(ta => ta.Theater_Actors).ThenInclude(a => a.Actor)
                 .FirstOrDefault(n => n.Id == id);
            return theaterDetails;
        }


    }
}
