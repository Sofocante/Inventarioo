using Inventarioo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarioo.COMMON.Interfaces
{
    public interface IManejadorVales:IManejadorGenerico<Vale>
    {
        List<Vale> ValesPorLiquidar();
        List<Vale> ValesEnIntervalo(DateTime inicio, DateTime fin);
    }
}
