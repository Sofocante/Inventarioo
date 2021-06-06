using Inventarioo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarioo.COMMON.Interfaces
{
    public interface IManejadorReportes:IManejadorGenerico<Reporte>
    {
        List<Reporte> MaterialesDeCategoria(string categoria);
    }
}
