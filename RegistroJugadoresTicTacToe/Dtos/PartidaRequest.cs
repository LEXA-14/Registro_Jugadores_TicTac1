namespace RegistroJugadoresTicTacToe.shared.Dtos;

public record PartidaRequest(
    int jugador1Id,
    int? jugador2Id
    );