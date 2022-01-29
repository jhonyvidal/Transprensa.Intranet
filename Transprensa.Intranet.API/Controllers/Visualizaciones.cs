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
    public class VisualizacionesController : ApiController
    {
        VisualizacionController Visualizacion = new VisualizacionController();
        ResponseModel response = new ResponseModel();

        //api/Visualizaciones
        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<VisualizacionesResponse>> ListarVisualizaciones()
        {
            return await Visualizacion.Listar();
        }

        //api/Visualizaciones
        [System.Web.Http.HttpPost]
        public ResponseModel CrearVisualizaciones([FromBody] VisualizacionesModel visualizacionPost)
        {

            if (!ModelState.IsValid)
            {
                string error = "";
                foreach (var value in ModelState.Values)
                {
                    foreach (var e in value.Errors)
                    {
                        error += e.ErrorMessage + ",";
                    }
                }
                response.success = false;
                response.message = ("Error:" + error);
                return response;
            }
            
            try
            {
                var crear = Visualizacion.Crear(visualizacionPost);
                return crear;
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ("Error:" + ex);
                return response;
            }

        }



    }
}