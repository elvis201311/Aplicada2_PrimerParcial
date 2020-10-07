using Microsoft.EntityFrameworkCore;
using PrimerParcialBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialBlazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\ProductosDB.db" );
        }
    }
}