using Registro_Jugadores_TicTac1.Components;
using RegistroJugadores.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroJugadores.Models;


namespace RegistroJugadoresServices
{

    public class JugadoresServicios(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Registrar(Jugadores jugador)
        {
            if (!await Existe(jugador.Nombres))
            {
                return await Insertar(jugador);
            }
            else
            {
                throw new InvalidOperationException("Error de Duplicacion: Nombre ya Existe");

            }

        }

        private async Task<bool> Existe(string Nombres)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.AnyAsync(J => J.Nombres == Nombres);
        }

        private async Task<bool> Insertar(Jugadores jugador)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Jugadores.Add(jugador);
            return await contexto.SaveChangesAsync() > 0;
        }

        //Filtros de mayor a menor y menor a mayor

        public async Task<List<Jugadores>> JugadoresMenorAMayor()
        {
            await using var contexto =await DbFactory.CreateDbContextAsync();

            return await contexto.Jugadores.OrderBy(J=> J.Partidas).ToListAsync();
        }

        public async Task<List<Jugadores>> JugadoresMayorAMenor()
        {
            using var contexto = DbFactory.CreateDbContext();

            return await contexto.Jugadores.OrderByDescending(J => J.Partidas).ToListAsync();
        }

        public async Task<List<Jugadores>>GetList(Expression<Func<Jugadores,bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.Where(criterio).ToListAsync();
        }

    }
}

