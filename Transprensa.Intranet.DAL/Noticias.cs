//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Transprensa.Intranet.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Noticias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Noticias()
        {
            this.Imagenes = new HashSet<Imagenes>();
        }
    
        public int idNoticia { get; set; }
        public string titulo { get; set; }
        public string cuerpo { get; set; }
        public string enlaces { get; set; }
        public string archivos { get; set; }
        public System.DateTime fecha { get; set; }
        public string categoria { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagenes> Imagenes { get; set; }
    }
}
