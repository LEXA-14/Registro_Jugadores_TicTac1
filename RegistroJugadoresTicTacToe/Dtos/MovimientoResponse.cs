namespace RegistroJugadoresTicTacToe.Shared.Dtos;

public record MovimientoResponse(
    int partidaId,
    string Jugador,
    int posicionFila,
    int posicionColumna
    );