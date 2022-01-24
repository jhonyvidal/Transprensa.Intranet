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
    public class NoticiaController : ApiController
    {
        NoticiasController noticia = new NoticiasController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<NoticiasModel>> ListarNoticias()
        {
            return await noticia.Listar();
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Noticia/ListarNoticiasPublicas")]
        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<NoticiasModel>> ListarNoticiasPublicas()
        {
            return await noticia.ListarNoticiasPublicas();
        }


        [System.Web.Http.HttpPost]
        public ResponseModel CrearNoticia([FromBody] NoticiasModel noticiaPost)
        {
            try
            {
                var crear = noticia.Crear(noticiaPost);
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
        public ResponseModel ActualizarNoticia([FromBody] NoticiasModel noticiaPut)
        {
            try
            {
                var actualizar = noticia.Actualizar(noticiaPut);
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
        [System.Web.Http.Route("api/Noticia/EliminarNoticia/{idItem}")]
        public ResponseModel EliminarNoticia(int idItem)
        {
            return noticia.EliminarItem(idItem);
        }
    }
}