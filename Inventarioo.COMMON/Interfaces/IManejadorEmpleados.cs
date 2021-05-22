using Inventarioo.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarioo.COMMON.Interfaces
{
    public interface IManejadorEmpleados:IManejadorGenerico<Empleado>
    {
        List<Empleado> EmpleadosPorArea(string are);

    }
}
