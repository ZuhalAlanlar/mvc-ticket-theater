using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;

        public EntityBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Set<T>().FirstOrDefault(n => n.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            context.SaveChanges();


        }
      

        public IEnumerable<T> GetAll()
        {
            var result = context.Set<T>().ToList();
            return result;
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProp) => current.Include(includeProp));
            return query.ToList();
        }

        public T GetById(int id)
        {
            var result = context.Set<T>().FirstOrDefault(n => n.Id == id);
            return result;
        }





        public void Update(int id,T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();
            
         
        }
    }
}
