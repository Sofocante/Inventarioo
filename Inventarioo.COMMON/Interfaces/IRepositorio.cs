using Inventarioo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarioo.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base 
    {
        bool Create(T entidad);
        List<T> Read { get; }
        bool Update(T entidadModificada);
        bool Delete(string id);
    }
} 
 