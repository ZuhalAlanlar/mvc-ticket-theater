using mvc_ticket_theater.Data.Base;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Services
{
    public class SaloonsService:EntityBaseRepository<Saloon>,ISaloonsService
    {

        public SaloonsService(AppDbContext context):base(context)
        {

        }
    }
}
