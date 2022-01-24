using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class CapacitacionesController: BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<CapacitacionesModel>> Listar()
        {
            var consultaCapacitaciones = DbContext.Context.Capacitaciones.ToList();

            return consultaCapacitaciones.Select(c => new CapacitacionesModel
            {
                idCapacitacion = c.idCapacitacion,
                resumen = c.resumen,
                idArea = c.idArea,
                enlace = c.enlace,
                nombre = c.nombre,
                nombreArea = c.Areas.nombre

            }); 
        }


        public ResponseModel Crear(CapacitacionesModel capacitacion)
        {
            try
            {
                Capacitaciones nuevaCapacitacion = new Capacitaciones();

                var area = DbContext.Context.Areas.FirstOrDefault(c => c.idArea == capacitacion.idArea);

                if(area != null)
                {
                    nuevaCapacitacion.idCapacitacion = capacitacion.idCapacitacion;
                    nuevaCapacitacion.resumen = capacitacion.resumen;
                    nuevaCapacitacion.idArea = capacitacion.idArea;
                    nuevaCapacitacion.enlace = capacitacion.enlace;
                    nuevaCapacitacion.nombre = capacitacion.nombre;
                    
                }                

                DbContext.Context.Capacitaciones.Add(nuevaCapacitacion);

                DbContext.Context.SaveChanges();

                var consultaNotificaciones = DbContext.Context.ConfiguracionNotificaciones.FirstOrDefault(c => c.modulo == "Capacitaciones" && c.evento == "Crear");
                Notificaciones notificacion = new Notificaciones();

                if (consultaNotificaciones != null)
                {
                    notificacion.idConfiguracionNoticia = consultaNotificaciones.idConfiguracion;
                    notificacion.fecha = DateTime.Now;
                    DbContext.Context.Notificaciones.Add(notificacion);
                    DbContext.Context.SaveChanges();

                }
                else
                {
                    response.success = false;
                    response.message = "No existe una configuración de notificación para ete evento";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó la capacitación con exito";
            return response;
        }


        public ResponseModel Actualizar(CapacitacionesModel capacitacion)
        {

            try
            {
                var capacitacionActualizar = DbContext.Context.Capacitaciones.FirstOrDefault(c => c.idCapacitacion == capacitacion.idCapacitacion);

                if (capacitacionActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : La capacitación No existe";
                    return response;

                }
                else
                {

                    capacitacionActualizar.resumen = capacitacion.resumen;
                    capacitacionActualizar.idArea = capacitacion.idArea;
                    capacitacionActualizar.enlace = capacitacion.enlace;
                    capacitacionActualizar.nombre = capacitacion.nombre;

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
            response.message = "Se actualizó la capacitación con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idCapacitacion)
        {
            try
            {
                var capacitacionEliminar = DbContext.Context.Capacitaciones.FirstOrDefault(c => c.idCapacitacion == idCapacitacion);

                if (capacitacionEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : La capacitación a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.Capacitaciones.Remove(capacitacionEliminar);
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
            response.message = "Se eliminó la capacitación con exito";
            return response;
        }
    }
}
