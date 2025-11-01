using Registro_Jugadores_TicTac1.Dto;

namespace Registro_Jugadores_TicTac1.Services;

public class MovimientosApiService(HttpClient httpClient)
{
       
        public async Task<Resource<List<MovimientosResponse>>> GetMovimientosAsync(int PartidaId)
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<MovimientosResponse>>($"api/Movimientos/{PartidaId}");
                return new Resource<List<MovimientosResponse>>.Success(response ?? []);
            }
            catch (Exception ex)
            {
                return new Resource<List<MovimientosResponse>>.Error(ex.Message);
            }
        }

        public async Task<Resource<MovimientosResponse>> PostMovimiento(int PartidaId, string Jugador, int PosicionFila, int PosicionColumna)
        {

            var request = new MovimientosRequest(PartidaId, Jugador, PosicionFila, PosicionColumna);
            try
            {
                var response = await httpClient.PostAsJsonAsync($"api/Movimientos", request);
                response.EnsureSuccessStatusCode();

                return new Resource<MovimientosResponse>.Success(null!);
            }
            catch (HttpRequestException ex)
            {
                return new Resource<MovimientosResponse>.Error($"Error de red: {ex.Message}");

            }
            catch (NotSupportedException)
            {
                return new Resource<MovimientosResponse>.Error("Respuesta invalida del servidor");
            }
        }

    }

