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
    public class TiposEventosController : ApiController
    {
        TipoEventoController tipoEvento = new TipoEventoController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<TipoEventoModel>> ListarTipoEvento()
        {
            return await tipoEvento.Listar();
        }       


        [System.Web.Http.HttpPost]
        public ResponseModel CrearTipoEvento([FromBody] TipoEventoModel tipoEventoPost)
        {
            try
            {
                var crear = tipoEvento.Crear(tipoEventoPost);
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
        public ResponseModel ActualizarTipoEvento([FromBody] TipoEventoModel tipoEventoPut)
        {
            try
            {
                var actualizar = tipoEvento.Actualizar(tipoEventoPut);
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
        [System.Web.Http.Route("api/TiposEventos/EliminarTipoEvento/{idItem}")]
        public ResponseModel EliminarTipoEvento(int idItem)
        {
            return tipoEvento.EliminarItem(idItem);
        }
    }
}