using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class DocumentosController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<DocumentosModel>> Listar()
        {
            var consultaDocumentos = DbContext.Context.Documentos.ToList();

            return consultaDocumentos.Select(c => new DocumentosModel
            {
                idDocumento = c.idDocumento,
                idArea = c.idArea,
                urlDocumento = c.urlDocumento,
                nombre = c.nombre,
                nombreArea = c.Areas.nombre

            });
        }


        public ResponseModel Crear(DocumentosModel documento)
        {
            try
            {
                Documentos nuevoDocumento = new Documentos();

                var area = DbContext.Context.Areas.FirstOrDefault(c => c.idArea == documento.idArea);

                if (area != null)
                {
                    nuevoDocumento.idDocumento = documento.idDocumento;
                    nuevoDocumento.idArea = area.idArea;
                    nuevoDocumento.urlDocumento = documento.urlDocumento;
                    nuevoDocumento.nombre = documento.nombre;
                    

                    DbContext.Context.Documentos.Add(nuevoDocumento);
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
            response.message = "Se creó el documento con exito";
            return response;
        }


        public ResponseModel Actualizar(DocumentosModel documento)
        {

            try
            {
                var documentoActualizar = DbContext.Context.Documentos.FirstOrDefault(c => c.idDocumento == documento.idDocumento);
                var area = DbContext.Context.Areas.FirstOrDefault(c => c.idArea == documento.idArea);

                if (documentoActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : El documento no existe";
                    return response;

                }
                else
                {
                    documentoActualizar.idDocumento = documento.idDocumento;
                    documentoActualizar.idArea = area.idArea;
                    documentoActualizar.urlDocumento = documento.urlDocumento;
                    documentoActualizar.nombre = documento.nombre;
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
            response.message = "Se actualizó el documento con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idDocumento)
        {
            try
            {
                var documentoEliminar = DbContext.Context.Documentos.FirstOrDefault(c => c.idDocumento == idDocumento);

                if (documentoEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : El documento a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.Documentos.Remove(documentoEliminar);
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
            response.message = "Se eliminó el documento con exito";
            return response;
        }
    }
}
