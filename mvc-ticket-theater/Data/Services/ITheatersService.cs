using mvc_ticket_theater.Data.Base;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Services
{
    public interface ITheatersService:IEntityBaseRepository<Theater>
    {

       public Theater GetTheaterById(int id);
    }
}
