using EFconASPyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFconASPyMVC.Context
{
    public class MyDbContext : DbContext
    {
        //Implementación del constructor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Con esto estamos utilizando ApiFluent y le estamos diciendo que la entidad
            //Libro Categoría va a tener una clave primaria compuesta por LibroId y CategoriaId
            modelBuilder.Entity<LibroCategoria>().HasKey(x => new { x.LibroId, x.CategoriaId });
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<LibroCategoria> LibroCategorias { get; set; }
    }
}

