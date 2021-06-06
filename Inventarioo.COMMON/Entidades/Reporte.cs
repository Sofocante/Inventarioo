using System;
using System.Collections.Generic;
using System.Text;

namespace Inventarioo.COMMON.Entidades
{
    public class Reporte:Base
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return string.Format("[{0}] {1}", Categoria, Nombre);
        }
    }
}
