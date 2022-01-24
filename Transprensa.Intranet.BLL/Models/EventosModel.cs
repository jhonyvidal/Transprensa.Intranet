using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.BLL.Models
{
    public class EventosModel
    {
        public int idEvento { get; set; }
        public int dia { get; set; }
        public int mes { get; set; }
        public string nombre { get; set; }
        public int idTipoEvento { get; set; }
        public string nombreTipoEvento { get; set; }
        public int? año { get; set; }
    }
}
