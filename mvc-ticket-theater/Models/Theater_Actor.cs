using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Models
{
    public class Theater_Actor
    {
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }



        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
