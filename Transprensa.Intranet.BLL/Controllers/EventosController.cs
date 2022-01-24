using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class EventosController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<EventosModel>> Listar()
        {
            var consultaEvento = DbContext.Context.Eventos.ToList();

            return consultaEvento.Select(c => new EventosModel
            {
                idEvento = c.idEvento,
                nombre = c.nombre,
                dia = c.dia,
                mes = c.mes,
                idTipoEvento = c.idTipoEvento,
                nombreTipoEvento = c.TipoEvento.nombre,
                año = c.ano

            });
        }


        public ResponseModel Crear(EventosModel evento)
        {
            try
            {
                Eventos nuevoEvento = new Eventos();

                var tipoEvento = DbContext.Context.TipoEvento.FirstOrDefault(c => c.idTipoEvento == evento.idTipoEvento);

                if (tipoEvento != null)
                {
                    nuevoEvento.idEvento = evento.idEvento;
                    nuevoEvento.nombre = evento.nombre;
                    nuevoEvento.dia = evento.dia;
                    nuevoEvento.mes = evento.mes;
                    nuevoEvento.idTipoEvento = tipoEvento.idTipoEvento;
                    nuevoEvento.ano = evento.año;

                    DbContext.Context.Eventos.Add(nuevoEvento);
                }
                else
                {
                    response.success = false;
                    response.message = "El tipo de evento es obligatorio";
                    return response;
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
            response.message = "Se creó el evento con exito";
            return response;
        }


        public ResponseModel Actualizar(EventosModel evento)
        {
            
            try
            {
                var eventoActualizar = DbContext.Context.Eventos.FirstOrDefault(c => c.idEvento == evento.idEvento);
                var tipoEvento = DbContext.Context.TipoEvento.FirstOrDefault(c => c.idTipoEvento == evento.idTipoEvento);

                if (eventoActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : El Tipo de Evento No existe";
                    return response;

                }
                else
                {
                    eventoActualizar.idEvento = evento.idEvento;
                    eventoActualizar.nombre = evento.nombre;
                    eventoActualizar.dia = evento.dia;
                    eventoActualizar.mes = evento.mes;
                    eventoActualizar.idTipoEvento = tipoEvento.idTipoEvento;
                    eventoActualizar.ano = evento.año;
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
            response.message = "Se actualizó el evento con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idEvento)
        {
            try
            {
                var eventoEliminar = DbContext.Context.Eventos.FirstOrDefault(c => c.idEvento == idEvento);

                if (eventoEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : El evento a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.Eventos.Remove(eventoEliminar);
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
            response.message = "Se eliminó el evento con exito";
            return response;
        }
    }
}
