using PrimerParcial.Models;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcialBlazor.DAL

 {
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source= Data\Parcial.db");
        }
    }
}