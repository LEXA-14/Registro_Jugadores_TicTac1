using Registro_Jugadores_TicTac1.Dto;
using Registro_Jugadores_TicTac1.Models;

namespace Registro_Jugadores_TicTac1.Services;



    public class PartidasApiServices(HttpClient httpClient)
    {
        public async Task<Resource<List<PartidasResponse>>> GetPartidasAsync()
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<List<PartidasResponse>>("api/Partidas");
                return new Resource<List<PartidasResponse>>.Success(response ?? []);
            }
            catch (Exception ex)
            {
                return new Resource<List<PartidasResponse>>.Error(ex.Message);
            }

        }
        public async Task<Resource<PartidasResponse>> GetPartidaAsync(int partidaId)
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<PartidasResponse>($"api/Partidas/{partidaId}");
                return new Resource<PartidasResponse>.Success(response!);

            }
            catch (Exception ex)
            {
                return new Resource<PartidasResponse>.Error(ex.Message);

            }

        }

        public async Task<Resource<PartidasResponse>> PostPartida(int jugador1, int? jugador2)
        {

            var request = new PartidasRequest(jugador1, jugador2);
        Console.WriteLine($"Jugador1Id: {request.Jugador1Id}, Jugador2Id: {request.Jugador2Id}");


        try
        {
                var response = await httpClient.PostAsJsonAsync("api/Partidas", request);
                response.EnsureSuccessStatusCode();

                var created = await response.Content.ReadFromJsonAsync<PartidasResponse>();
              
                return new Resource<PartidasResponse>.Success(created!);
            }
            catch (HttpRequestException ex)
            {
                return new Resource<PartidasResponse>.Error($"Error de red: {ex.Message}");
            }
            catch (NotSupportedException)
            {
                return new Resource<PartidasResponse>.Error("Respuesta invalida del servidor");
            }

        }

        public async Task<Resource<PartidasResponse>> PutPartida(int partidaId, int jugador1, int? jugador2)
        {
            var request = new PartidasRequest(jugador1, jugador2);

            try
            {
                var response = await httpClient.PutAsJsonAsync($"/api/Partidas/{partidaId}", request);
                response.EnsureSuccessStatusCode();

                return new Resource<PartidasResponse>.Success(null!);
            }
            catch (HttpRequestException ex)
            {
                return new Resource<PartidasResponse>.Error($"Error de red:{ex.Message}");

            }
            catch (NotSupportedException)
            {
                return new Resource<PartidasResponse>.Error("Respuesta invalida del servidor");
            }
        }
    }

