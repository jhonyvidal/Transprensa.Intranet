using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Transprensa.Intranet.BLL.Models
{
    public class VisualizacionesModel
    {
        [DisplayName("Id")]
        public int idVisualizacion { get; set; }
        [DisplayName("Usuario")]
        [Required]
        public string idUsuario { get; set; }
        [DisplayName("Noticia")]
        [Required]
        public int idNoticia { get; set; }

    }
    public class VisualizacionesResponse
    {
        public int idNoticia { get; set; }
        public int Vistas { get; set; }

    }
}
