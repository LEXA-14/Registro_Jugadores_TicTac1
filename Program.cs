using Registro_Jugadores_TicTac1.Components;
using Registro_Jugadores_TicTac1.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroJugadoresServices;
using Registro_Jugadores_TicTac1.Services;


var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = AppContext.BaseDirectory,
    WebRootPath = Path.Combine(AppContext.BaseDirectory, "wwwroot")
});
//var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseWebRoot(Path.Combine(builder.Environment.ContentRootPath, "wwwroot"));


// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

           
            var ConStr = builder.Configuration.GetConnectionString("SqlConstr");
        
            builder.Services.AddDbContextFactory<contexto>(o => o.UseSqlServer(ConStr));
         
            builder.Services.AddScoped<JugadoresServicios>();
          
        builder.Services.AddScoped<PartidasServices>();

builder.Services.AddScoped<MovimientosServices>();

builder.Services.AddScoped<JuegosServices>();


builder.Services.AddScoped<PartidasApiServices>();
builder.Services.AddScoped<MovimientosApiService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://gestionhuacalesapi.azurewebsites.net/") });


var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        
    

