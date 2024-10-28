using BackEnd.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using BackEnd.Models;
using System.Security.Claims;
using BCrypt.Net;

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

// Crear usuarios y eventos predeterminados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var repoEstudiante = services.GetRequiredService<IRepoEstudiante>();
        var repoEvento = services.GetRequiredService<IRepoEvento>();
        var repoParticipacion = services.GetRequiredService<IRepoParticipacion>();

        // Lista de usuarios predeterminados
        var usuariosPredeterminados = new List<Estudiante>
        {
            new Estudiante
            {
                Nombre = "Admin",
                Apellido = "User",
                Username = "admin",
                Correo = "admin@gmail.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("123"),
                Anio = 0,
                Division = 1,
                IsAdmin = true
            },
            new Estudiante
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Username = "juanp",
                Correo = "juan.perez@gmail.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("123"),
                Anio = 1,
                Division = 2,
                IsAdmin = false
            },
            new Estudiante
            {
                Nombre = "Miguel",
                Apellido = "Verduguez",
                Username = "MiguelV",
                Correo = "Miguel.Verduguez@gmail.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("123"),
                Anio = 1,
                Division = 2,
                IsAdmin = false
            },
            new Estudiante
            {
                Nombre = "María",
                Apellido = "García",
                Username = "mariag",
                Correo = "maria.garcia@gmail.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("123"),
                Anio = 2,
                Division = 3,
                IsAdmin = false
            },
            new Estudiante
            {
                Nombre = "Carlos",
                Apellido = "López",
                Username = "carlosl",
                Correo = "carlos.lopez@gmail.com",
                Contrasena = BCrypt.Net.BCrypt.HashPassword("password3"),
                Anio = 3,
                Division = 1,
                IsAdmin = false
            }
        };

        // Crear usuarios predeterminados
        foreach (var usuario in usuariosPredeterminados)
        {
            // Verificar si el usuario ya existe por correo
            var usuarioExistente = await repoEstudiante.ObtenerPorCorreo(usuario.Correo);
            if (usuarioExistente == null)
            {
                var idAutoIncrementado = await repoEstudiante.Crear(usuario);
                usuario.idEstudiante = idAutoIncrementado;
                Console.WriteLine($"Usuario '{usuario.Username}' creado con éxito.");
            }
            else
            {
                // Actualizar el objeto usuario con el ID existente
                usuario.idEstudiante = usuarioExistente.idEstudiante;
                Console.WriteLine($"El usuario '{usuario.Username}' ya existe.");
            }
        }

        // Lista de eventos predeterminados
        var eventosPredeterminados = new List<Evento>
        {
            new Evento
            {
                Nombre = "Feria de Ciencias",
                Fecha = DateTime.Now.AddMonths(1),
                Ubicacion = "Auditorio Principal",
                Descripcion = "Evento para mostrar proyectos científicos de estudiantes.",
                ImagenUrl = "example.jpg",
                idEstudiante = usuariosPredeterminados[0].idEstudiante // Admin
            },
            new Evento
            {
                Nombre = "Torneo de Fútbol",
                Fecha = DateTime.Now.AddMonths(2),
                Ubicacion = "Campo de Fútbol",
                Descripcion = "Competencia deportiva entre clases.",
                ImagenUrl = "example.jpg",
                idEstudiante = usuariosPredeterminados[1].idEstudiante // Juan
            },
            new Evento
            {
                Nombre = "Concierto de Música",
                Fecha = DateTime.Now.AddMonths(3),
                Ubicacion = "Sala de Conciertos",
                Descripcion = "Presentación de bandas locales.",
                ImagenUrl = "example.jpg",
                idEstudiante = usuariosPredeterminados[2].idEstudiante // María
            },
            new Evento
            {
                Nombre = "Exposición de Arte",
                Fecha = DateTime.Now.AddMonths(4),
                Ubicacion = "Galería de Arte",
                Descripcion = "Muestra de obras de arte realizadas por estudiantes.",
                ImagenUrl = "example.jpg",
                idEstudiante = usuariosPredeterminados[3].idEstudiante // Carlos
            }
        };

        foreach (var evento in eventosPredeterminados)
        {
            // Verificar si el evento ya existe por nombre
            var eventoExistente = await repoEvento.ObtenerPorId(evento.idEvento);

            if (eventoExistente == null)
            {
                var idEvento = await repoEvento.Crear(evento);
                evento.idEvento = idEvento;
                Console.WriteLine($"Evento '{evento.Nombre}' creado con éxito.");

                // Crear participación para el creador del evento
                var participacion = new Participacion
                {
                    idEvento = idEvento,
                    idEstudiante = evento.idEstudiante
                };

                var idParticipacion = await repoParticipacion.Crear(participacion);
                participacion.idParticipacion = idParticipacion;
                Console.WriteLine($"Participación para el creador del evento '{evento.Nombre}' creada con éxito.");
            }
            else
            {
                Console.WriteLine($"El evento '{evento.Nombre}' ya existe.");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear los usuarios o eventos predeterminados: {ex.Message}");
    }
}

app.Run();
