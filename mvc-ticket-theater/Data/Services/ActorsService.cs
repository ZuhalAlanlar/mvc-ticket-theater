using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext context;

        public ActorsService(AppDbContext context)
        {
            this.context = context;
        }
        
        
        public void Add(Actor actor)
        {
            context.Actors.Add(actor);
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var result = context.Actors.FirstOrDefault(n => n.Id == id);
            context.Actors.Remove(result);
            context.SaveChanges();
          
        }


        public Actor Update(int id, Actor newActor)
        {
            context.Update(newActor);
            context.SaveChanges();
            return newActor;
        }
    }
}
