namespace EFconASPyMVC.Models
{
    public class Membresia
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
