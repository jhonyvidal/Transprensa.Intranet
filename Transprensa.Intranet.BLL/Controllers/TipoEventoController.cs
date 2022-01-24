using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class TipoEventoController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<TipoEventoModel>> Listar()
        {
            var consultaTipoEvento = DbContext.Context.TipoEvento.ToList();

            return consultaTipoEvento.Select(c => new TipoEventoModel
            {
                idTipoEvento = c.idTipoEvento,
                nombre = c.nombre,
                color = c.color

            });
        }


        public ResponseModel Crear(TipoEventoModel tipoEvento)
        {
            try
            {
                TipoEvento nuevoTipoEvento = new TipoEvento();

                nuevoTipoEvento.idTipoEvento = tipoEvento.idTipoEvento;
                nuevoTipoEvento.nombre = tipoEvento.nombre;
                nuevoTipoEvento.color = tipoEvento.color;
                

                DbContext.Context.TipoEvento.Add(nuevoTipoEvento);
                

                DbContext.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó el tipo de evento con exito";
            return response;
        }


        public ResponseModel Actualizar(TipoEventoModel tipoEvento)
        {

            try
            {
                var tipoEventoActualizar = DbContext.Context.TipoEvento.FirstOrDefault(c => c.idTipoEvento == tipoEvento.idTipoEvento);                

                if (tipoEventoActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : El Tipo de Evento No existe";
                    return response;

                }
                else
                {
                    tipoEventoActualizar.idTipoEvento = tipoEvento.idTipoEvento;
                    tipoEventoActualizar.nombre = tipoEvento.nombre;
                    tipoEventoActualizar.color = tipoEvento.color;
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
            response.message = "Se actualizó el tipo evento con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idTipoEvento)
        {
            try
            {
                var tipoEventoEliminar = DbContext.Context.TipoEvento.FirstOrDefault(c => c.idTipoEvento == idTipoEvento);

                if (tipoEventoEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : El tipo de evento a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.TipoEvento.Remove(tipoEventoEliminar);
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
            response.message = "Se eliminó el tipo de evento con exito";
            return response;
        }
    }
}
