using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegistroDeJugadoresTicTacToe;
using RegistroDeJugadoresTicTacToe.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IPartidasServices, PartidasApiServices>();
builder.Services.AddScoped<IMovimientosServices,MovimientoApiService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/") });

await builder.Build().RunAsync();


