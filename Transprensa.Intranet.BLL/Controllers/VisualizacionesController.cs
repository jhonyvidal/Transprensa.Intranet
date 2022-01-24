using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.BLL.Models;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class VisualizacionController : BaseController
    {
        ResponseModel response = new ResponseModel();
        Visualizaciones visualizaciones = new Visualizaciones();

        public async Task<IEnumerable<VisualizacionesModel>> Listar()
        {        
            
            var listaVisualizaciones = DbContext.Context.Visualizaciones.ToList();

            return listaVisualizaciones.Select(c => new VisualizacionesModel
            {
                idVisualizacion = c.idVisualizacion,
                idNoticia = c.idNoticia,
                idUsuario = c.idUsuario

            });

        }


        public ResponseModel Crear(VisualizacionesModel visualizacion)
        {
            try
            {
                Visualizaciones nuevavisualizacion = new Visualizaciones();


                nuevavisualizacion.idNoticia = visualizacion.idNoticia;
                nuevavisualizacion.idUsuario = visualizacion.idUsuario;
                nuevavisualizacion.idVisualizacion = visualizacion.idNoticia;


                var id = DbContext.Context.Visualizaciones.Add(nuevavisualizacion);

                DbContext.Context.SaveChanges();

            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = "Error: " + ex;
                return response;
            }

            response.success = true;
            response.message = "Se creó el registro con exito";
            return response;
        }
        
    }
}
