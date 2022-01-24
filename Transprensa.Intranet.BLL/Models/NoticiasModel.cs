using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.BLL.Models
{
    public class NoticiasModel
    {
        public int idNoticia { get; set; }
        public string titulo { get; set; }
        public string cuerpo { get; set; }
        public string enlaces { get; set; }        
        public string archivos { get; set; }
        public System.DateTime fecha { get; set; }
        public string categoria { get; set; }
        public List<ImagenesModel> imagenes { get; set; }
    }
    
    public class ImagenesModel
    {
        public int idImagen { get; set; }
        public int idNoticia { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
    }
}
