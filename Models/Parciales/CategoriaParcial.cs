using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sondeo_web_7eam.Models.Parciales
{
    public partial class CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA()
        {
            this.PRODUCTO = new HashSet<PRODUCTO>();
        }
        [Required]
        [Index(IsUnique =true)]
        public string ID_CATEGORIA { get; set; }
        public string CATEGORIA1 { get; set; }
        public string DESCRIPCION_CAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

    }
}