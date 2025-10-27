using System.Net.Http.Json;

using RegistroJugadoresTicTacToe.Shared;
using RegistroJugadoresTicTacToe.Shared.Dtos;

namespace RegistroDeJugadoresTicTacToe.Services;

public interface IMovimientosServices
{
    Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync(int partidaId);

    //Task<Resource<MovimientoResponse>> GetMovimientoAsync(int partidaId);

    Task<Resource<MovimientoResponse>> PostMovimiento(int partidaId, string jugador, int posicionFila,int posicionColumna);

}
