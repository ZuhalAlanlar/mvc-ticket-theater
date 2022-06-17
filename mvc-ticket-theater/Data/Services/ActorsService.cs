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
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll()
        {
            var result = context.Actors.ToList();
            return result;
        }

        public Actor GetById(int id)
        {
            var result = context.Actors.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public Actor Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
