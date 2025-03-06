namespace EFconASPyMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<LibroCategoria> LibroCategorias { get; set; }
    }
}
