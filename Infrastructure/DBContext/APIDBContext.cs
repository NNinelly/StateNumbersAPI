using Application;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {

        }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<BookNumbers>()
            .HasOne<Numbers>(s => s.Numbers)
            .WithMany(r => r.BookNumbers)
            .HasForeignKey(s => s.NumberId);
         modelBuilder.Entity<OrderNumbers>()
           .HasOne<Numbers>(s => s.Numbers)
           .WithMany(r => r.OrderNumbers)
           .HasForeignKey(s => s.NumberId);
      }

        public DbSet<Numbers> Number { get; set; }
        public DbSet<BookNumbers> BookNumbers { get; set; }
        public DbSet<OrderNumbers> OrderNumbers { get; set; }
   }
}
