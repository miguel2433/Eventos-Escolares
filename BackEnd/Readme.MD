## Que aplicar en el appsettings.Development.json:

```json
{
  "AllowedHosts": "*",
  "ConnectionStrings": 
  {
    "DefaultConnection": "Server=localhost;Database=5to_OrganizacionEventosEscolares;user=tuUsuario;Password=tuPassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
