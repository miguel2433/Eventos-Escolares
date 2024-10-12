using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Servicios
{
    public interface IUpdate<T>
    {
    Task Update(T objeto);
    }
}