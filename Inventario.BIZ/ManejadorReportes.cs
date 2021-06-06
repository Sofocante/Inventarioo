using Inventarioo.COMMON.Entidades;
using Inventarioo.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.BIZ
{
    public class ManejadorReportes:IManejadorReportes
    {
        IRepositorio<Reporte> repositorio;
        public ManejadorReportes(IRepositorio<Reporte> repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Reporte> Listar => repositorio.Read;

        public bool Agregar(Reporte entidad)
        {
            return repositorio.Create(entidad);
        }

        public Reporte BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public List<Reporte> MaterialesDeCategoria(string categoria)
        {
            return Listar.Where(e => e.Categoria == categoria).ToList();
        }
        public bool Modificar(Reporte entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
