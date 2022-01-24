using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class NoticiasController : BaseController
    {
        ResponseModel response = new ResponseModel();
        Notificaciones notificacion = new Notificaciones();

        public async Task<IEnumerable<NoticiasModel>> Listar()
        {
            var consultaNoticia = DbContext.Context.Noticias.ToList();          
            
            List<NoticiasModel> listadoNoticias = new List<NoticiasModel>();

            foreach (Noticias noticia in consultaNoticia)
            {

                NoticiasModel noticias = new NoticiasModel();                
                List<ImagenesModel> listadoImagenes = new List<ImagenesModel>();

                var consultaImagen = DbContext.Context.Imagenes.Where(c => c.idNoticia == noticia.idNoticia).ToList();
                
                
                foreach (Imagenes imagen in consultaImagen)
                {
                    ImagenesModel imagenes = new ImagenesModel();
                    imagenes.idImagen = imagen.idImagen;
                    imagenes.idNoticia = imagen.idNoticia;
                    imagenes.nombre = imagen.nombre;
                    imagenes.url = imagen.url;
                    listadoImagenes.Add(imagenes);

                }

                

                noticias.idNoticia = noticia.idNoticia;
                noticias.titulo = noticia.titulo;
                noticias.cuerpo = noticia.cuerpo;
                noticias.enlaces = noticia.enlaces;
                noticias.imagenes = listadoImagenes;
                noticias.archivos = noticia.archivos;
                noticias.fecha = noticia.fecha;
                noticias.categoria = noticia.categoria;

                listadoNoticias.Add(noticias);


            }

            


            return listadoNoticias;
        }

        public async Task<IEnumerable<NoticiasModel>> ListarNoticiasPublicas()
        {
            var consultaNoticia = DbContext.Context.Noticias.Where(c => c.fecha <= DateTime.Now).OrderBy(c => c.fecha).Take(6).ToList();

            List<NoticiasModel> listadoNoticias = new List<NoticiasModel>();

            foreach (Noticias noticia in consultaNoticia)
            {

                NoticiasModel noticias = new NoticiasModel();
                List<ImagenesModel> listadoImagenes = new List<ImagenesModel>();

                var consultaImagen = DbContext.Context.Imagenes.Where(c => c.idNoticia == noticia.idNoticia).ToList();


                foreach (Imagenes imagen in consultaImagen)
                {
                    ImagenesModel imagenes = new ImagenesModel();
                    imagenes.idImagen = imagen.idImagen;
                    imagenes.idNoticia = imagen.idNoticia;
                    imagenes.nombre = imagen.nombre;
                    imagenes.url = imagen.url;
                    listadoImagenes.Add(imagenes);

                }



                noticias.idNoticia = noticia.idNoticia;
                noticias.titulo = noticia.titulo;
                noticias.cuerpo = noticia.cuerpo;
                noticias.enlaces = noticia.enlaces;
                noticias.imagenes = listadoImagenes;
                noticias.archivos = noticia.archivos;
                noticias.fecha = noticia.fecha;
                noticias.categoria = noticia.categoria;

                listadoNoticias.Add(noticias);


            }




            return listadoNoticias;
        }


        public ResponseModel Crear(NoticiasModel noticia)
        {
            try
            {
                Noticias nuevaNoticia = new Noticias();

                nuevaNoticia.idNoticia = noticia.idNoticia;
                nuevaNoticia.titulo = noticia.titulo;
                nuevaNoticia.cuerpo = noticia.cuerpo;
                nuevaNoticia.enlaces = noticia.enlaces;
                nuevaNoticia.archivos = noticia.archivos;
                nuevaNoticia.fecha = noticia.fecha;
                nuevaNoticia.categoria = noticia.categoria;

                var id = DbContext.Context.Noticias.Add(nuevaNoticia);

                DbContext.Context.SaveChanges();

                Imagenes nuevaImagen = new Imagenes();

                if (noticia.imagenes != null)
                {
                    foreach (ImagenesModel imagen in noticia.imagenes)
                    {
                        nuevaImagen.idNoticia = id.idNoticia;
                        nuevaImagen.nombre = imagen.nombre;
                        nuevaImagen.url = imagen.url;

                        DbContext.Context.Imagenes.Add(nuevaImagen);
                        DbContext.Context.SaveChanges();
                    }
                }

                var consultaNotificaciones = DbContext.Context.ConfiguracionNotificaciones.FirstOrDefault(c => c.modulo == "Noticias" && c.evento == "Crear");
                Notificaciones notificacion = new Notificaciones();

                if(consultaNotificaciones != null)
                {
                    notificacion.idConfiguracionNoticia = consultaNotificaciones.idConfiguracion;
                    notificacion.fecha = nuevaNoticia.fecha;
                    DbContext.Context.Notificaciones.Add(notificacion);
                    DbContext.Context.SaveChanges();

                }
                else
                {
                    response.success = false;
                    response.message = "No existe una configuración de notificación para ete evento";
                    return response;
                }
                

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó la noticia con exito";
            return response;
        }


        public ResponseModel Actualizar(NoticiasModel noticia)
        {

            try
            {
                var noticiaActualizar = DbContext.Context.Noticias.FirstOrDefault(c => c.idNoticia == noticia.idNoticia); 
               

                if (noticiaActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : La noticia No existe";
                    return response;

                }
                else
                {
                    noticiaActualizar.idNoticia = noticia.idNoticia;
                    noticiaActualizar.titulo = noticia.titulo;
                    noticiaActualizar.cuerpo = noticia.cuerpo;
                    noticiaActualizar.enlaces = noticia.enlaces;                    
                    noticiaActualizar.archivos = noticia.archivos;
                    noticiaActualizar.fecha = noticia.fecha;
                    noticiaActualizar.categoria = noticia.categoria;
                }

                DbContext.Context.SaveChanges();

                if (noticia.imagenes != null)
                {
                    foreach (ImagenesModel imagen in noticia.imagenes)
                    {
                        var imagenActualizar = DbContext.Context.Imagenes.FirstOrDefault(c => c.idImagen == imagen.idImagen);

                        if(imagenActualizar != null)
                        {
                            imagenActualizar.idNoticia = noticiaActualizar.idNoticia;
                            imagenActualizar.nombre = imagen.nombre;
                            imagenActualizar.url = imagen.url;
                        }                    

                        
                        DbContext.Context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se actualizó la noticia con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idNoticia)
        {
            try
            {
                var noticiaEliminar = DbContext.Context.Noticias.FirstOrDefault(c => c.idNoticia == idNoticia);

                if (noticiaEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : La noticia a eliminar no existe";
                    return response;

                }
                else
                {
                    var imagenEliminar = DbContext.Context.Imagenes.Where(c => c.idNoticia == noticiaEliminar.idNoticia).ToList();

                    foreach (Imagenes imagen in imagenEliminar)
                    {
                        DbContext.Context.Imagenes.Remove(imagen);
                        DbContext.Context.SaveChanges();
                    }

                    

                    DbContext.Context.Noticias.Remove(noticiaEliminar);
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
            response.message = "Se eliminó la noticia con exito";
            return response;
        }

        
}
}
