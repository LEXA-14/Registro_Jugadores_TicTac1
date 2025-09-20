using Registro_Jugadores_TicTac1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Registro_Jugadores_TicTac1.Models;

namespace Registro_Jugadores_TicTac1.Services;

public class PartidasServices(IDbContextFactory<contexto> DbFactory)
{
    //Crear Partida
    public async Task<bool>Registrar(Partidas partidas)
    {
      

        if (partidas.Jugador1Id != 0 && partidas.Jugador1Id != partidas.Jugador2Id)
        {
            return await Insertar(partidas);
        }
        return false;
    }


    //Insertar

    private async Task<bool> Insertar(Partidas partidas)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Partidas.Add(partidas);
        return await contexto.SaveChangesAsync() > 0;

    }
    


    //Modificar
    public async Task<bool>Modificar(Partidas partidas)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(partidas);
        return await contexto.SaveChangesAsync() > 0;
    }
    //Listar
    public async Task<List<Partidas>> GetListPartidas(Expression<Func<Partidas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.Include(p => p.Jugador1).Include(p=>p.Jugador2).Where(criterio).ToListAsync();

    }
    //Eliminar
    public async Task<bool>Eliminar(int PartidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.Where(p => p.PartidaId == PartidaId).ExecuteDeleteAsync() > 0;
    }

    //Buscar

    public async Task<Partidas?>Buscar(int partidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.FirstOrDefaultAsync(p => p.PartidaId == partidaId);
    }
    

    

    

    }


