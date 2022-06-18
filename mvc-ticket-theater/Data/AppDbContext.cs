using Microsoft.EntityFrameworkCore;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theater_Actor>().HasKey(ta => new
            {

                ta.TheaterId,
                ta.ActorId
            });

            modelBuilder.Entity<Theater_Actor>().HasOne(t => t.Theater).WithMany(ta => ta.Theater_Actors).HasForeignKey(t => t.TheaterId);
            modelBuilder.Entity<Theater_Actor>().HasOne(a => a.Actor).WithMany(ta => ta.Theater_Actors).HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Theater_Actor> Theaters_Actors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }

    }
}
