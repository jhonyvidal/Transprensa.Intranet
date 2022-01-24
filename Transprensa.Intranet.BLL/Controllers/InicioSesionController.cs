using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transprensa.Intranet.BLL.Controllers
{
    public class InicioSesionController : BaseController
    {
        public bool AutenticatheUser(String userName, string password)
        {
            bool ret = false;
            string NombreCompleto;
            string NTusername;
            string co;
            string correo;

            try
            {
                DirectoryEntry de = new DirectoryEntry("LDAP://192.168.93.250:389", userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                dsearch.Filter = "sAMAccountName=" + userName + "";                
                SearchResult results = null;

                results = dsearch.FindOne();

                NombreCompleto = results.GetDirectoryEntry().Properties["DisplayName"].Value.ToString();
                NTusername = results.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();
                co = results.GetDirectoryEntry().Properties["department"].Value.ToString();//department
                correo = results.GetDirectoryEntry().Properties["mail"].Value.ToString();


            }
            catch (Exception ex)
            {
                ret = false;
                
            }

            return ret;

        }
        private string GetCurrentDomainPath()
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://192.168.93.250:389");
            return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
        }
        bool status = false;
        

    }
}

