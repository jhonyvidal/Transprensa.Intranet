using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.BLL.Models
{
    public class DocumentosModel
    {
        public int idDocumento { get; set; }
        public int idArea { get; set; }
        public string urlDocumento { get; set; }
        public string nombre { get; set; }
        public string nombreArea { get; set; }
    }
}
