using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.DAL
{
    public class IntranetContext: DbContext
    {
        private IntranetEntities _context;

        public IntranetEntities Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new IntranetEntities();
                }
                return _context;
            }
        }

        public IntranetContext()
        {
            _context = new IntranetEntities();
            ((IObjectContextAdapter)this.Context).ObjectContext.CommandTimeout = 999999999;
        }
    }
}
