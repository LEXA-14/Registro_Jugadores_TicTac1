using Registro_Jugadores_TicTac1.Components;
using RegistroJugadores.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroJugadoresServices;


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

            //constructor para el contexto
            var ConStr = builder.Configuration.GetConnectionString("SqlConstr");
            //contexto 
            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));
            //inyeccion
            builder.Services.AddScoped<JugadoresServicios>();

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
        
    

