namespace RegistroJugadoresTicTacToe.Shared.Dtos;

public record MovimientoResponse(
    int partidaId,
    int jugadorId,
    int posicionFila,
    int posicionColumna
    );