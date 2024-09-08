## Que aplicar en el appsettings.Development.json:


{
  "AllowedHosts": "*",
  "ConnectionStrings": 
  {
    "DefaultConnection": "Server=localhost;Database=OrganizacionEventosEscolares;user=tuUsuario;Password=tuPassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
