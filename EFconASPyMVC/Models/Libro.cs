namespace EFconASPyMVC.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor {  get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuarios { get; set; }

        public List<LibroCategoria> LibroCategorias { get; set; }
    }
}
