using System.Net.Http.Json;
using RegistroJugadoresTicTacToe.Shared;
using RegistroJugadoresTicTacToe.Shared.Dtos;
using System.Net.Http.Json;



namespace RegistroDeJugadoresTicTacToe.Services;

public class MovimientoApiService(HttpClient httpClient) : IMovimientosServices
{
    public async Task<Resource<MovimientoResponse>> GetMovimientoAsync(int partidaId)
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<MovimientoResponse>($"api/Movimientos/{partidaId}");
            return new Resource<MovimientoResponse>.Success(response!);
        }
        catch (Exception ex)
        {
            return new Resource<MovimientoResponse>.Error(ex.Message);
        }
    }

    public async Task<Resource<List<MovimientoResponse>>> GetMovimientosAsync()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<MovimientoResponse>>("api/Movimientos");
            return new Resource<List<MovimientoResponse>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            return new Resource<List<MovimientoResponse>>.Error(ex.Message);
        }
    }

    public async Task<Resource<MovimientoResponse>> PostMovimiento(int partidaId, int jugadorId, int posicionFila, int posicionColumna)
    {
        var request = new MovimientoRequest(partidaId, jugadorId, posicionFila, posicionColumna);
        try
        {
            var response = await httpClient.PostAsJsonAsync($"api/Movimientos", request);
            response.EnsureSuccessStatusCode();

            var movimiento = await response.Content.ReadFromJsonAsync<MovimientoResponse>();

            if (movimiento == null)
                return new Resource<MovimientoResponse>.Error("Error al leer la respuesta");
            else
            {
                return new Resource<MovimientoResponse>.Success(movimiento);
            }

        }
        catch (HttpRequestException ex)
        {
            return new Resource<MovimientoResponse>.Error($"Error de red: {ex.Message}");

        }
    }
}

