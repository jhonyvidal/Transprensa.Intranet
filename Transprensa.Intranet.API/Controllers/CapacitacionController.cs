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
    public class CapacitacionController : ApiController
    {
        CapacitacionesController capacitacion = new CapacitacionesController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<CapacitacionesModel>> ListarCapacitaciones()
        {
            return await capacitacion.Listar();
        }


        [System.Web.Http.HttpPost]
        public ResponseModel CrearCapacitaciones([FromBody] CapacitacionesModel capacitacionPost)
        {
            try
            {
                var crear = capacitacion.Crear(capacitacionPost);
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
        public ResponseModel ActualizarCapacitacion([FromBody] CapacitacionesModel capacitacionPut)
        {
            try
            {
                var actualizar = capacitacion.Actualizar(capacitacionPut);
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
        [System.Web.Http.Route("api/Capacitacion/EliminarCapacitacion/{idItem}")]
        public ResponseModel EliminarCapacitacion(int idItem)
        {
            return capacitacion.EliminarItem(idItem);
        }
    }
}