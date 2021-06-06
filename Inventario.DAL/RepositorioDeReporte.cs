using Inventarioo.COMMON.Entidades;
using Inventarioo.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Inventario.DAL
{
    public class RepositorioDeReporte : IRepositorio<Reporte>
    {
        private string DBName = @"C:\INV\Inventario.db";
        private string TableName = "Reportes";

        public List<Reporte> Read
        {
            get
            {
                List<Reporte> datos = new List<Reporte>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Reporte>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }
        public bool Create(Reporte entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Reporte>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Reporte>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Reporte entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Reporte>(TableName);
                    coleccion.Insert(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
