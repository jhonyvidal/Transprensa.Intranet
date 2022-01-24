using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transprensa.Intranet.DAL;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class BaseController
    {
        private IntranetContext _context;

        public IntranetContext DbContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new IntranetContext();
                }
                return _context;
            }
        }
    }
}
