using mvc_ticket_theater.Data.Base;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>,IActorsService
    {
      
        public ActorsService(AppDbContext context) : base(context) { }
    
    }
}
