using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class ImagenesController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<ImagenesModel>> Listar()
        {
            var consultaImagenes = DbContext.Context.Imagenes.ToList();

           
            return consultaImagenes.Select(c => new ImagenesModel
            {
                idImagen = c.idImagen,
                idNoticia = c.idNoticia,
                nombre = c.nombre,
                url = c.url,

            });
        }

        public ResponseModel Crear(ImagenesModel imagen)
        {
            try
            {
                Imagenes nuevaImagen = new Imagenes();

                nuevaImagen.idNoticia = imagen.idNoticia;
                nuevaImagen.nombre = imagen.nombre;
                nuevaImagen.url = imagen.url;

                DbContext.Context.Imagenes.Add(nuevaImagen);
                DbContext.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó la imagen con exito";
            return response;
        }


        public ResponseModel Actualizar(ImagenesModel imagen)
        {

            try
            {

                var imagenActualizar = DbContext.Context.Imagenes.FirstOrDefault(c => c.idImagen == imagen.idImagen);

                if (imagenActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : La imagen no existe";
                    return response;

                }
                else
                {
                    imagenActualizar.idNoticia = imagen.idNoticia;
                    imagenActualizar.nombre = imagen.nombre;
                    imagenActualizar.url = imagen.url;

                }

                DbContext.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se actualizó la imagen con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idImagen)
        {
            try
            {
                var imagenEliminar = DbContext.Context.Noticias.FirstOrDefault(c => c.idNoticia == idImagen);

                if (imagenEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : La imagen a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.Noticias.Remove(imagenEliminar);
                    DbContext.Context.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se eliminó la imagen con exito";
            return response;
        }

    }
}
