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
    public class HerramientaController : ApiController
    {
        HerramientasController herramienta = new HerramientasController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<HerramientasModel>> ListarHerramientas()
        {
            return await herramienta.Listar();
        }       


        [System.Web.Http.HttpPost]
        public ResponseModel CrearHerramienta([FromBody] HerramientasModel herramientaPost)
        {
            try
            {
                var crear = herramienta.Crear(herramientaPost);
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
        public ResponseModel ActualizarHerramienta([FromBody] HerramientasModel herramientaPut)
        {
            try
            {
                var actualizar = herramienta.Actualizar(herramientaPut);
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
        [System.Web.Http.Route("api/Herramienta/EliminarHerramienta/{idItem}")]
        public ResponseModel EliminarHerramienta(int idItem)
        {
            return herramienta.EliminarItem(idItem);
        }
    }
}