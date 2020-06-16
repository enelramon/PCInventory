using Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public  class Contexto : DbContext
    {
        public DbSet<Equipos> Equipos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Inventory.db");
        }
    }
}
