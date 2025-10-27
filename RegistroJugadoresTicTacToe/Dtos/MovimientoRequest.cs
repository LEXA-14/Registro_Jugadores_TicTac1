namespace RegistroJugadoresTicTacToe.Shared.Dtos;

public record MovimientoRequest(
    int partidaId,
    string Jugador,
    int posicionFila,
    int posicionColumna
    );