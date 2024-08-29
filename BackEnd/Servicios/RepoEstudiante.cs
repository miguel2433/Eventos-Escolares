using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Servicios
{
    public class RepoEstudiante
    {
        public List<Estudiante> ObtenerEstudiantes()
        {
            return new List<Estudiante>() 
            { 
                new() 
                {
                    idEstudiante = 1,
                    Nombre = "Miguel",
                    Año = 5,
                    Division = 7,
                    Correo = "miguelito@gmail.com",
                    ImageUrl = "/Imagenes/tradeo_OFERTO_CLARO.png"
                },
                new() 
                {
                    idEstudiante = 1,
                    Nombre = "Juan",
                    Año = 5,
                    Division = 7,
                    Correo = "juan@gmail.com",
                    ImageUrl = "/Imagenes/Posteo.png"
                },
                new() 
                {
                    idEstudiante = 1,
                    Nombre = "Roberto",
                    Año = 5,
                    Division = 7,
                    Correo = "roberto@gmail.com",
                    ImageUrl = "/Imagenes/Perfil_modo_claro.png"
                },
                new() 
                {
                    idEstudiante = 1,
                    Nombre = "Cheng",
                    Año = 5,
                    Division = 7,
                    Correo = "cheng@gmail.com",
                    ImageUrl = "/Imagenes/Posteo-oscuro.png"
                },
            };
        }

    }
}