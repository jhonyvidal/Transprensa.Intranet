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
    public class InformacionesEmpresaController : ApiController
    {
        InformacionEmpresaController informacionEmpresa = new InformacionEmpresaController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<InformacionEmpresaModel>> ListarInformacionEmpresa()
        {
            return await informacionEmpresa.Listar();
        }       


        [System.Web.Http.HttpPost]
        public ResponseModel CrearInformacionEmpresa([FromBody] InformacionEmpresaModel informacionEmpresaPost)
        {
            try
            {
                var crear = informacionEmpresa.Crear(informacionEmpresaPost);
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
        public ResponseModel ActualizarInformacionEmpresa([FromBody] InformacionEmpresaModel informacionEmpresaPut)
        {
            try
            {
                var actualizar = informacionEmpresa.Actualizar(informacionEmpresaPut);
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
        [System.Web.Http.Route("api/InformacionesEmpresa/EliminarInformacionEmpresa/{idItem}")]
        public ResponseModel EliminarInformacionEmpresa(int idItem)
        {
            return informacionEmpresa.EliminarItem(idItem);
        }
    }
}