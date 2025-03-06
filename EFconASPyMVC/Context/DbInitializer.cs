using EFconASPyMVC.Context;
using EFconASPyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EF_en_ASP.NET_Core_MVC_con_Scaffolding_y_NN_con_NET_7.Context
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.EnsureCreated(); //este método nos crea automáticamente la base de datos sin necesidad de migraciones

            // Comprueba si hay algún usuario
            if (context.Usuarios.Any())
            {
                return;   // BD ya ha sido inicializada
            }

            //Añado usuarios
            var usus = new Usuario[]
            {
            new Usuario{Nombre="Miguel", Email="miguel@biblio.com"},
            new Usuario{ Nombre="Andrés", Email="andres@biblio.com"},
            new Usuario{ Nombre="Juan", Email="juan@biblio.com"},
            new Usuario{ Nombre="Marcos", Email="marcos@biblio.com"},

            };
            foreach (Usuario u in usus)
            {
                context.Usuarios.Add(u);
            }
            context.SaveChanges();


            //Añado membresias
            var membre = new Membresia[]
            {
                new Membresia{Tipo="Free", FechaExpiracion = DateTime.Parse("20/04/2025"), UsuarioId=1},
                new Membresia{Tipo="PlanA", FechaExpiracion = DateTime.Parse("05/12/2026"), UsuarioId=2},
                new Membresia{Tipo="Free", FechaExpiracion = DateTime.Parse("15/03/2024"), UsuarioId=3},
                new Membresia{Tipo="PlanB", FechaExpiracion = DateTime.Parse("26/12/2026"), UsuarioId=4},
            };


            foreach (Membresia m in membre)
            {
                context.Membresias.Add(m);
            }
            context.SaveChanges();

            //Añado libros
            var libros = new Libro[]
            {
                new Libro{ Titulo="Cien años de soledad", Autor="Gabriel García Márquez", UsuarioId = 1 },
                new Libro{ Titulo="1984", Autor="George Orwell", UsuarioId = 2 },
                new Libro{ Titulo="El gran Gatsby", Autor="F. Scott Fitzgerald", UsuarioId = 3 },
                new Libro{ Titulo="Matar a un ruiseñor", Autor="Harper Lee", UsuarioId = 4 },
            };


            foreach (Libro l in libros)
            {
                context.Libros.Add(l);
            }
            context.SaveChanges();

            //Añado categorías
            var categ = new Categoria[]
            {
            new Categoria{Nombre ="Ficción"},
            new Categoria{ Nombre ="No Ficción"},
            new Categoria{ Nombre ="Ciencia Ficción"},
            new Categoria{ Nombre ="Misterio y Terror"}
            };
            foreach (Categoria c in categ)
            {
                context.Categorias.Add(c);
            }
            context.SaveChanges();


            //Añado LibroCategoria
            var lc = new LibroCategoria[]
            {
                new LibroCategoria{LibroId=1, CategoriaId=1},
                new LibroCategoria{LibroId=2, CategoriaId=2},
                new LibroCategoria{LibroId=3, CategoriaId=3},
                new LibroCategoria{LibroId=4, CategoriaId=4},
            };
            foreach (LibroCategoria libCat in lc)
            {
                context.LibroCategorias.Add(libCat);
            }
            context.SaveChanges();
        }

    }

}
