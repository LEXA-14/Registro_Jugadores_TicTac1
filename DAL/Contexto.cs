using RegistroJugadores.Models;
using Microsoft.EntityFrameworkCore;
using Registro_Jugadores_TicTac1.Models;

namespace RegistroJugadores.DAL
{

    public class contexto : DbContext
    {
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Partidas> Partidas { get; set; }
        public contexto(DbContextOptions<contexto> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            // clave foranea para Jugador1
            modelBuilder.Entity<Partidas>()
                .HasOne(p => p.Jugador1)
                .WithMany()
                .HasForeignKey(p => p.Jugador1Id)
                .OnDelete(DeleteBehavior.NoAction);

            // clave foranea para Jugador2
            modelBuilder.Entity<Partidas>()
                .HasOne(p => p.Jugador2)
                .WithMany()
                .HasForeignKey(p => p.Jugador2Id)
                .OnDelete(DeleteBehavior.NoAction);

            // clave foranea para Ganador
            modelBuilder.Entity<Partidas>()
                .HasOne(p => p.Ganador)
                .WithMany()
                .HasForeignKey(p => p.GanadorId)
                .OnDelete(DeleteBehavior.NoAction);

            // clave foranea para turno de jugador
            modelBuilder.Entity<Partidas>()
                .HasOne(p => p.TurnoJugador)
                .WithMany()
                .HasForeignKey(p => p.TurnoJugadorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

       
    
