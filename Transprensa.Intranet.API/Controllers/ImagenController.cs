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
    public class ImagenController : ApiController
    {
        ImagenesController imagen = new ImagenesController();
        ResponseModel response = new ResponseModel();

        [System.Web.Http.HttpGet]
        public async Task<IEnumerable<ImagenesModel>> ListarImagenes()
        {
            return await imagen.Listar();
        }


        [System.Web.Http.HttpPost]
        public ResponseModel CrearImagenes([FromBody] ImagenesModel imagenPost)
        {
            try
            {
                var crear = imagen.Crear(imagenPost);
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
        public ResponseModel ActualizarImagen([FromBody] ImagenesModel imagenPut)
        {
            try
            {
                var actualizar = imagen.Actualizar(imagenPut);
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
        [System.Web.Http.Route("api/Imagen/EliminarImagen/{idItem}")]
        public ResponseModel EliminarImagen(int idItem)
        {
            return imagen.EliminarItem(idItem);
        }

       
    }
}