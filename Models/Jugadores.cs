
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Jugadores_TicTac1.Models
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

        //[InverseProperty(nameof(Movimientos.Jugadores))]
        [InverseProperty(nameof(Models.Movimientos.Jugadores))]
        public virtual ICollection<Movimientos> Movimientos{ get; set; }

    }
}