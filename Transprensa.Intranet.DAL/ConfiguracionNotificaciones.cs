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
    
    public partial class ConfiguracionNotificaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConfiguracionNotificaciones()
        {
            this.Notificaciones = new HashSet<Notificaciones>();
        }
    
        public int idConfiguracion { get; set; }
        public string nombre { get; set; }
        public string modulo { get; set; }
        public string evento { get; set; }
        public bool estado { get; set; }
        public string mensaje { get; set; }
        public byte[] fechaActualizacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notificaciones> Notificaciones { get; set; }
    }
}