using Registro_Jugadores_TicTac1.Components;
using RegistroJugadores.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroJugadores.Models;


namespace Jugadores.Services;

public class JugadoresServicios(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool>Registrar(Jugadores jugador)
    {
        if(!await Existe(jugador.Nombres))
        {
            return await Insertar(jugador);
        }
        else
        {
            throw new InvalidOperationException("Error de Duplicacion: Nombre ya Existe");
          
        }

    }

    private async Task<bool>Existe(string Nombres)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Jugadores.AnyAsync(J => J.Nombres == Nombres);
    }

    private async Task<bool>Insertar(Jugadores jugador)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.jugador.Add(jugador);
        return await contexto.SaveChangesAsync() > 0;
    }

}

