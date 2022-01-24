using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class NotificacionesController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public ResponseModel Crear(NotificacionesModel notificacion)
        {
            try
            {
                Notificaciones nuevaNotificacion = new Notificaciones();

                nuevaNotificacion.idNotificacion = notificacion.idNotificacion;
                nuevaNotificacion.idConfiguracionNoticia = notificacion.idConfiguracionNoticia;
                nuevaNotificacion.fecha = notificacion.fecha;

                DbContext.Context.Notificaciones.Add(nuevaNotificacion);

                DbContext.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó la notificación con exito";
            return response;
        }

        public async Task<IEnumerable<NotificacionesModel>> Listar()
        {
            var consultaArea = DbContext.Context.Notificaciones.ToList();

            return consultaArea.Select(c => new NotificacionesModel
            {
                idNotificacion = c.idNotificacion,
                idConfiguracionNoticia = c.idConfiguracionNoticia,
                nombre = c.ConfiguracionNotificaciones.nombre,
                fecha = c.fecha,
                modulo = c.ConfiguracionNotificaciones.modulo,
                mensaje = c.ConfiguracionNotificaciones.mensaje


            }) ;
        }


    }
}
