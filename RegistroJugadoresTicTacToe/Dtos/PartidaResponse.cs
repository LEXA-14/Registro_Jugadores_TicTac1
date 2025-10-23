namespace RegistroJugadoresTicTacToe.Shared.Dtos;


public record PartidaResponse(
    int partidaId,
    int jugador1Id,
    int jugador2Id
    );