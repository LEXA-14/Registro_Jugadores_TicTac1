namespace RegistroJugadoresTicTacToe.Shared.Dtos;

public record MovimientoRequest(
    int partidaId,
    int jugadorId,
    int posicionFila,
    int posicionColumna
    );