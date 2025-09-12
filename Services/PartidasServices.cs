using RegistroJugadores.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroJugadores.Models;
using Registro_Jugadores_TicTac1.Models;

namespace Registro_Jugadores_TicTac1.Services;

public class PartidasServices(IDbContextFactory<Contexto> DbFactory)
{
    //Crear Partida
    public async Task<bool>Registrar(Partidas partidas,Jugadores jugador1,Jugadores jugador2)
    {
        if (jugador1 == null)
        {
            return false;
        }
        else if(await DiferenciaJ1_J2(jugador1, jugador2))
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
    

    //QUE EL JUGADOR 1 Y EL JUGADOR 2 SEAN DIFERENTES

    private async Task<bool> DiferenciaJ1_J2(Jugadores jugador1, Jugadores jugador2)
    {
        if (jugador1.Nombres == jugador2.Nombres)
        {
            return false;
        }
        return true;

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
        return await contexto.Partidas.Where(criterio).ToListAsync();

    }
    //Eliminar
    public async Task<bool>Eliminar(int PartidaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Partidas.Where(p => p.PartidaId == PartidaId).ExecuteDeleteAsync() > 0;
    }
    

    

    

    }


