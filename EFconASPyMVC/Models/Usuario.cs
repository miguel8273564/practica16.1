namespace EFconASPyMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        //Propiedad navegacional
        public Membresia Membresia { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
