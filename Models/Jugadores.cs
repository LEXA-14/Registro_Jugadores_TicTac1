using System.ComponentModel.DataAnnotations;

namespace RegistroJugadores.Models
{

    public class Jugadores
    {
        [Key]
        public int JugadorId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]

        public required string Nombres { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int Victorias { get; set; }

        public int Derrotas { get; set; }
        public int Empates { get; set; }

    }
}