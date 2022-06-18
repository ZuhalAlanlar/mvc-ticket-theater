using Microsoft.EntityFrameworkCore;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data.Card
{
    public class ShoppingCard
    {
         public AppDbContext _context { get; set; }

        public ShoppingCard(AppDbContext context)
        {
            _context = context;
        }



        public string ShoppingCardId { get; set; }


        public void AddItemToCard(Theater theater)
        {
            var shoppingcarditem = _context.ShoppingCardItems.FirstOrDefault(t => t.Theater.Id == theater.Id && t.ShoppingCardId == ShoppingCardId);

            if (shoppingcarditem == null)
            {
                shoppingcarditem = new ShoppingCardItem()
                {
                    ShoppingCardId = ShoppingCardId,
                    Theater = theater,
                    Amount = 1



                };
                _context.ShoppingCardItems.Add(shoppingcarditem);
            }

            else {

                shoppingcarditem.Amount =+ 1;
            
            }
            _context.SaveChanges();
        }
        
        
    





        public List<ShoppingCardItem> ShoppingCardItems{ get; set; }

        public List<ShoppingCardItem> GetShoppingCardItems()
        {
            return ShoppingCardItems ?? (ShoppingCardItems = _context.ShoppingCardItems.Where(sc => sc.ShoppingCardId == ShoppingCardId).Include(t => t.Theater).ToList());

        }
        public double GetShoppingCardTotal()
        {
            var total = _context.ShoppingCardItems.Where(sc => sc.ShoppingCardId == ShoppingCardId).Select(sc => sc.Theater.Price * sc.Amount).Sum();
            return total;
        
        }

    }
}
