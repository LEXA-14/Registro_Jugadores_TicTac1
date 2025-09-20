using Registro_Jugadores_TicTac1.Models;
using Microsoft.EntityFrameworkCore;


namespace Registro_Jugadores_TicTac1.DAL
{

    public class contexto : DbContext
    {
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Partidas> Partidas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
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

            //movimientos a partidas

            modelBuilder.Entity<Movimientos>()
                .HasOne(m => m.Partidas)
                .WithMany(p => p.MovimientosPartidas)
                .HasForeignKey(m => m.PartidaId);

            //movimientos jugador

            modelBuilder.Entity<Movimientos>()
                .HasOne(m => m.Jugadores)
                .WithMany(j => j.Movimientos)
                .HasForeignKey(j => j.JugadorId);
        }
    }
}

       
    
