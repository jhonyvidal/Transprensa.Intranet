using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class InformacionEmpresaController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<InformacionEmpresaModel>> Listar()
        {
            var consultaInformacion = DbContext.Context.InformacionEmpresa.ToList();

            return consultaInformacion.Select(c => new InformacionEmpresaModel
            {
                idInformacion = c.idInformacion,
                titulo = c.titulo,
                descripcion = c.descripcion                

            });
        }


        public ResponseModel Crear(InformacionEmpresaModel informacionEmpresa)
        {
            try
            {
                InformacionEmpresaModel nuevaInformacionEmpresa = new InformacionEmpresaModel();

                nuevaInformacionEmpresa.idInformacion = informacionEmpresa.idInformacion;
                nuevaInformacionEmpresa.titulo = informacionEmpresa.titulo;
                nuevaInformacionEmpresa.descripcion = informacionEmpresa.descripcion;


                DbContext.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó la informacion de la empresa con exito";
            return response;
        }


        public ResponseModel Actualizar(InformacionEmpresaModel informacionEmpresa)
        {

            try
            {
                var informacionEmpresaActualizar = DbContext.Context.InformacionEmpresa.FirstOrDefault(c => c.idInformacion == informacionEmpresa.idInformacion);
                

                if (informacionEmpresaActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : La informacion de la empresa No existe";
                    return response;

                }
                else
                {
                    informacionEmpresaActualizar.idInformacion = informacionEmpresa.idInformacion;
                    informacionEmpresaActualizar.titulo = informacionEmpresa.titulo;
                    informacionEmpresaActualizar.descripcion = informacionEmpresa.descripcion;
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
            response.message = "Se actualizó la informacion de la empresa con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idInformacionEmpresa)
        {
            try
            {
                var informacionEmpresaEliminar = DbContext.Context.InformacionEmpresa.FirstOrDefault(c => c.idInformacion == idInformacionEmpresa);

                if (informacionEmpresaEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : La informacion empresa a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.InformacionEmpresa.Remove(informacionEmpresaEliminar);
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
            response.message = "Se eliminó la informacion de empresa con exito";
            return response;
        }
    }
}
