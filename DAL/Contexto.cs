using RegistroJugadores.Models;
using Microsoft.EntityFrameworkCore;
using Registro_Jugadores_TicTac1.Models;

namespace RegistroJugadores.DAL
{

    public class Contexto : DbContext
    {
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Partidas> Partidas { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

       
    }
}