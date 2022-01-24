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
    public class DocumentoController : ApiController
    {
        DocumentosController documento = new DocumentosController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<DocumentosModel>> ListarDocumentos()
        {
            return await documento.Listar();
        }


        [System.Web.Http.HttpPost]
        public ResponseModel CrearDocumentos([FromBody] DocumentosModel documentoPost)
        {
            try
            {
                var crear = documento.Crear(documentoPost);
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
        public ResponseModel ActualizarDocumento([FromBody] DocumentosModel documentoPut)
        {
            try
            {
                var actualizar = documento.Actualizar(documentoPut);
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
        [System.Web.Http.Route("api/Documento/EliminarDocumento/{idItem}")]
        public ResponseModel EliminarDocumento(int idItem)
        {
            return documento.EliminarItem(idItem);
        }
    }
}