using System.Net.Http.Json;

using RegistroJugadoresTicTacToe.Shared;
using RegistroJugadoresTicTacToe.Shared.Dtos;

namespace RegistroDeJugadoresTicTacToe.Services;

public interface IPartidasServices
{

    Task<Resource<List<PartidaResponse>>>GetPartidasAsync();

    Task<Resource<PartidaResponse>>GetPartidaAsync(int partidaId);

    Task<Resource<PartidaResponse>> PostPartida(int jugador1, int jugador2);
}
