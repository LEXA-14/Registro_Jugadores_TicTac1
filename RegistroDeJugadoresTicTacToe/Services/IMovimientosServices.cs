using System.Net.Http.Json;

using RegistroJugadoresTicTacToe.Shared;
using RegistroJugadoresTicTacToe.Shared.Dtos;

namespace RegistroDeJugadoresTicTacToe.Services;

public interface IMovimientosServices
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync();

    Task<Resource<MovimientoResponse>> GetMovimientoAsync(int partidaId);

    Task<Resource<MovimientoResponse>> PostMovimiento(int partidaId, int jugadorId, int posicionFila,int posicionColumna);

}
