﻿using Inventarioo.COMMON.Entidades;
using Inventarioo.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventario.BIZ
{
    public class ManejadorEmpleados:IManejadorEmpleados
    {
        IRepositorio<Empleado> repositorio;
        public ManejadorEmpleados(IRepositorio<Empleado> repo)
        {
            repositorio = repo;
        }

        public List<Empleado> Listar => repositorio.Read;

        public bool Agregar(Empleado entidad)
        {
            return repositorio.Create(entidad);
        }

        public Empleado BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Empleado entidad)
        {
            throw new NotImplementedException();
        }
    }
}
