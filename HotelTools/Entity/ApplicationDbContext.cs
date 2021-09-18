using Microsoft.EntityFrameworkCore;
using System;

namespace HotelTools.Core.Models.Enitities
{
    class ApplicationDbContext : DbContext
    {

        public DbSet<Room> Room { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        public string DbPath { get; private set; }


        public ApplicationDbContext()
        {

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"Database.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
