using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Base
{
   public interface IEntityBaseRepository<T> where T:class,IEntityBase,new()
    {

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T,object>>[] includeProperties);

        T GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);

        void Delete(int id);
    }
}
