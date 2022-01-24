using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class AreasController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<AreasModel>> Listar()
        {
            var consultaArea = DbContext.Context.Areas.ToList().OrderBy(c => c.nombre);

            return consultaArea.Select(c => new AreasModel
            {
                idArea = c.idArea,
                nombre = c.nombre               

            });
        }


        public ResponseModel Crear(AreasModel area)
        {
            try
            {
                Areas nuevaArea = new Areas();

                nuevaArea.idArea = area.idArea;
                nuevaArea.nombre = area.nombre;                

                DbContext.Context.Areas.Add(nuevaArea);

                DbContext.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó el area con exito";
            return response;
        }


        public ResponseModel Actualizar(AreasModel area)
        {

            try
            {
                var areaActualizar = DbContext.Context.Areas.FirstOrDefault(c => c.idArea == area.idArea);                

                if (areaActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : El Area No existe";
                    return response;

                }
                else
                {
                    areaActualizar.idArea = area.idArea;
                    areaActualizar.nombre = area.nombre;
                    
                }

                DbContext.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se actualizó el area con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idArea)
        {
            try
            {
                var areaEliminar = DbContext.Context.Areas.FirstOrDefault(c => c.idArea == idArea);

                if (areaEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : El area a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.Areas.Remove(areaEliminar);
                }

                DbContext.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se eliminó el area con exito";
            return response;
        }
    }
}
