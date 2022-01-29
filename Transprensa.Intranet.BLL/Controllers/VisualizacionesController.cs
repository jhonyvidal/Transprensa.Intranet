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

        public async Task<IEnumerable<VisualizacionesResponse>> Listar()
        {        
            
            var listaVisualizaciones = DbContext.Context.Visualizaciones
                .GroupBy(c=>c.idNoticia)
                .Select(c => new { idNoticia = c.Key, Total = c.Select(v => v.idNoticia).Count() })
                .ToList();

            return listaVisualizaciones.Select(c => new VisualizacionesResponse
            {
                idNoticia = c.idNoticia,
                Vistas = c.Total

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
