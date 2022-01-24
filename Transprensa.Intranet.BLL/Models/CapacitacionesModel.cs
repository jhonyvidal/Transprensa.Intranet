using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.BLL.Models
{
    public class CapacitacionesModel
    {
        public int idCapacitacion { get; set; }
        public string resumen { get; set; }
        public int idArea { get; set; }
        public string enlace { get; set; }
        public string nombre { get; set; }
        public string nombreArea { get; set; }
    }
}
