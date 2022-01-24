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
    public class AreaController : ApiController
    {
        AreasController area = new AreasController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<AreasModel>> ListarAreas()
        {
            return await area.Listar();
        }


        [System.Web.Http.HttpPost]
        public ResponseModel CrearArea([FromBody] AreasModel areaPost)
        {
            try
            {
                var crear = area.Crear(areaPost);
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
        public ResponseModel ActualizarArea([FromBody] AreasModel areaPut)
        {
            try
            {
                var actualizar = area.Actualizar(areaPut);
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
        [System.Web.Http.Route("api/Area/EliminarArea/{idItem}")]
        public ResponseModel EliminarArea(int idItem)
        {
            return area.EliminarItem(idItem);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Area/Prueba")]
        public void Prueba()
        {
            InicioSesionController inicio = new InicioSesionController();
            inicio.AutenticatheUser("jdelgado", "13071998Kamilo");
        }
    }
}