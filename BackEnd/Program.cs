using BackEnd.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using BackEnd.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepoEstudiante, RepoEstudiante>();
builder.Services.AddTransient<IRepoEvento, RepoEvento>();
builder.Services.AddTransient<IRepoParticipacion, RepoParticipacion>();
// Register the DbContext
builder.Services.AddSingleton<DbContext>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
            options.LoginPath = "/Home/Index";
            options.LogoutPath = "/Home/Index";  // Ruta a la página de inicio de sesión // Ruta a la acción de cierre de sesión
        });


var app = builder.Build();

// Configuración del pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Crear usuario administrador
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var repoEstudiante = services.GetRequiredService<IRepoEstudiante>();

        // Verificar si el usuario admin ya existe
        var adminUser = await repoEstudiante.ObtenerPorCorreo("admin@gmail.com");
        if (adminUser == null)
        {
            // Crear usuario admin
            var admin = new Estudiante
            {
                Nombre = "Admin",
                Apellido = "User",
                Username = "admin",
                Correo = "admin@gmail.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("123"),
                Anio = 0,
                Division = 1,
                IsAdmin = true
            };
            var adminId = await repoEstudiante.Crear(admin);
            admin.idEstudiante = adminId;
            Console.WriteLine("Usuario administrador creado con éxito.");
        }
        else
        {
            Console.WriteLine("El usuario administrador ya existe.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear el usuario administrador: {ex.Message}");
    }
}

app.Run();
