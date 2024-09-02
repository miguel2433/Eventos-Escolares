using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BackEnd.Models;
namespace BackEnd.Servicios
{
    public interface IRepoEstudiante
    {
        public void Crear (Estudiante estudiante);
    }
}