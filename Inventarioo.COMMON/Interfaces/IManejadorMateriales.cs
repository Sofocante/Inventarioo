using Inventarioo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarioo.COMMON.Interfaces
{
    public interface IManejadorMateriales:IManejadorGenerico<Material>
    {
        List<Material> MaterialesDeCategoria(string categoria);
    }
}
