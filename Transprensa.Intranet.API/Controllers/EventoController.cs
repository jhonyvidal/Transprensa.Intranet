using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Transprensa.Intranet.BLL.Controllers;
using Transprensa.Intranet.BLL.Models;

namespace Transprensa.Intranet.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventoController : ApiController
    {
        EventosController evento = new EventosController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<EventosModel>> ListarEventos()
        {
            return await evento.Listar();
        }       


        [System.Web.Http.HttpPost]
        public ResponseModel CrearEvento([FromBody] EventosModel eventoPost)
        {
            try
            {
                var crear = evento.Crear(eventoPost);
                return crear;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ("Error:" + ex);
                return response;
            }

        }

        [System.Web.Http.HttpPut]
        public ResponseModel ActualizarEvento([FromBody] EventosModel eventoPut)
        {
            try
            {
                var actualizar = evento.Actualizar(eventoPut);
                return actualizar;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ("Error:" + ex);
                return response;
            }

        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Evento/EliminarEvento/{idItem}")]
        public ResponseModel EliminarEvento(int idItem)
        {
            return evento.EliminarItem(idItem);
        }
    }
}