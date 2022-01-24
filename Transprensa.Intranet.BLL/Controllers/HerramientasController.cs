using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class HerramientasController : BaseController
    {
        ResponseModel response = new ResponseModel();

        public async Task<IEnumerable<HerramientasModel>> Listar()
        {
            var consultaHerramienta = DbContext.Context.Herramientas.ToList();

            return consultaHerramienta.Select(c => new HerramientasModel
            {
                idHerramienta = c.idHerramienta,
                nombre = c.nombre,
                descripcion = c.descripcion,
                enlace = c.enlace
                

            });
        }


        public ResponseModel Crear(HerramientasModel herramienta)
        {
            try
            {
                Herramientas nuevaHerramienta = new Herramientas();

                nuevaHerramienta.idHerramienta = herramienta.idHerramienta;
                nuevaHerramienta.nombre = herramienta.nombre;
                nuevaHerramienta.descripcion = herramienta.descripcion;
                nuevaHerramienta.enlace = herramienta.enlace;

                DbContext.Context.Herramientas.Add(nuevaHerramienta);
                

                DbContext.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó la herramienta con exito";
            return response;
        }


        public ResponseModel Actualizar(HerramientasModel herramienta)
        {

            try
            {
                var herramientaActualizar = DbContext.Context.Herramientas.FirstOrDefault(c => c.idHerramienta == herramienta.idHerramienta);                

                if (herramientaActualizar == null)
                {
                    response.success = false;
                    response.message = "Error : La herramienta No existe";
                    return response;

                }
                else
                {
                    herramientaActualizar.idHerramienta = herramienta.idHerramienta;
                    herramientaActualizar.nombre = herramienta.nombre;
                    herramientaActualizar.descripcion = herramienta.descripcion;
                    herramientaActualizar.enlace = herramienta.enlace;
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
            response.message = "Se actualizó la herramienta con exito";
            return response;
        }

        public ResponseModel EliminarItem(int idHerramienta)
        {
            try
            {
                var herramientaEliminar = DbContext.Context.Herramientas.FirstOrDefault(c => c.idHerramienta == idHerramienta);

                if (herramientaEliminar == null)
                {
                    response.success = false;
                    response.message = "Error : La herramienta a eliminar no existe";
                    return response;

                }
                else
                {
                    DbContext.Context.Herramientas.Remove(herramientaEliminar);
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
            response.message = "Se eliminó la herramienta con exito";
            return response;
        }
    }
}
