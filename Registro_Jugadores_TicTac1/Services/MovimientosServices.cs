using Registro_Jugadores_TicTac1.Migrations;
using Registro_Jugadores_TicTac1.Models;
using Registro_Jugadores_TicTac1.DAL;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Movimientos = Registro_Jugadores_TicTac1.Models.Movimientos;

namespace Registro_Jugadores_TicTac1.Services;

public class MovimientosServices(IDbContextFactory<contexto> DbFactory)
{
    
    public async Task<bool>Insertar(Movimientos movimientos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        if(movimientos != null)
        {
            await contexto.Movimientos.AddAsync(movimientos);
            await contexto.SaveChangesAsync();
            return true;


        }
        return false;
    }
}
