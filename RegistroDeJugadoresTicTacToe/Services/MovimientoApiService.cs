using System.Net.Http.Json;
using RegistroJugadoresTicTacToe.Shared;
using RegistroJugadoresTicTacToe.Shared.Dtos;
using System.Net.Http.Json;



namespace RegistroDeJugadoresTicTacToe.Services;

public class MovimientoApiService(HttpClient httpClient) : IMovimientosServices
{
    //public async Task<Resource<MovimientoResponse>> GetMovimientoAsync(int partidaId)
    //{
    //    try
    //    {
    //        var response = await httpClient.GetFromJsonAsync<MovimientoResponse>($"api/Movimientos/{partidaId}");
    //        return new Resource<MovimientoResponse>.Success(response!);
    //    }
    //    catch (Exception ex)
    //    {
    //        return new Resource<MovimientoResponse>.Error(ex.Message);
    //    }
    //}

    ////mine
    public async Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync(int PartidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<MovimientoResponse>>($"api/Movimientos/{PartidaId}");
            return new Resource<List<MovimientoResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<MovimientoResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<MovimientoResponse>> PostMovimiento(int PartidaId, string Jugador, int PosicionFila, int PosicionColumna)
    {
        
        var request = new MovimientoRequest(PartidaId, Jugador, PosicionFila, PosicionColumna);
        try
        {
            var response = await httpClient.PostAsJsonAsync($"api/Movimientos", request);
            response.EnsureSuccessStatusCode();

            return new Resource<MovimientoResponse>.Success(null!);
        }  
        catch (HttpRequestException ex)
        {
            return new Resource<MovimientoResponse>.Error($"Error de red: {ex.Message}");

        }
        catch (NotSupportedException)
        {
            return new Resource<MovimientoResponse>.Error("Respuesta invalida del servidor");
        }
    }

}

