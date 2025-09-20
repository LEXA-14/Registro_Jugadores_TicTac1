using Registro_Jugadores_TicTac1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Registro_Jugadores_TicTac1.Models;


namespace RegistroJugadoresServices
{

    public class JugadoresServicios(IDbContextFactory<contexto> DbFactory)
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
            await using var contexto = await DbFactory.CreateDbContextAsync();

            return await contexto.Jugadores.OrderBy(J => J.Victorias).ToListAsync();
        }

        public async Task<List<Jugadores>> JugadoresMayorAMenor()
        {
            using var contexto =await DbFactory.CreateDbContextAsync();

            return await contexto.Jugadores.OrderByDescending(J => J.Victorias).ToListAsync();
        }

        public async Task<List<Jugadores>> GetList(Expression<Func<Jugadores, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.Where(criterio).ToListAsync();
        }
        //modificar, buscar y eliminar

        public async Task<Jugadores?> Buscar(string nombre)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores
                .AsNoTracking()
                .FirstOrDefaultAsync(j => j.Nombres.ToLower() == nombre.ToLower());
        }

        public async Task<bool> Modificar(Jugadores jugador)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(jugador);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int JugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.Where(j => j.JugadorId == JugadorId).ExecuteDeleteAsync() > 0;

        }

        public async Task<Jugadores>BuscarId(int JugadorId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Jugadores.AsNoTracking().FirstOrDefaultAsync(j => j.JugadorId == JugadorId);
        }
    }
}

