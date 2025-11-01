namespace Registro_Jugadores_TicTac1.Dto;

public record MovimientosRequest
(
    int PartidaId,
    string Jugador,
    int PosicionFila,
    int PosicionColumna
    );

