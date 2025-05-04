using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication2.Entidades;

namespace WebApplication2.Datos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected AplicationDbContext()
        {
        }
    }
}
