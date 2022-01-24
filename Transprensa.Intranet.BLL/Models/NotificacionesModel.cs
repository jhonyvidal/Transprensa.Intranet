using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.BLL.Models
{
    public class NotificacionesModel
    {
        public int idNotificacion { get; set; }
        public int idConfiguracionNoticia { get; set; }
        public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string modulo { get; set; }
        public string mensaje { get; set; }
    }
}
