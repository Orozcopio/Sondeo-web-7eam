using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sondeo_web_7eam.Models
{
    public partial class ProductoParcial
    {
        
        public int ID_PRODUCTO { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public Nullable<int> ID_CATEGORIA { get; set; }
        [Display(Name = "Unidad de medida")]
        [Required]
        public Nullable<int> UNIDAD_MEDIDA { get; set; }
        [Display(Name = "Marca")]
        [Required]
        public Nullable<int> ID_MARCA { get; set; }
        [Display(Name = "Producto")]
        [Required]
        public string PRODUCTO1 { get; set; }
        [Display(Name = "Presentacion")]
        [Required]
        public string PRESENTACION { get; set; }
        [Display(Name = "Pecio")]
        [Required]
        public decimal PRECIO_CONSULTA { get; set; }
        [Display(Name = "Tipo")]
        [Required]
        public string TIPO { get; set; }
        [Display(Name = "Precio al por mayor")]
        [Required]
        public bool ALPORMAYOR { get; set; }
        public int ID_SONDEO { get; set; }
        [Display(Name = "Cantidad medida")]
        [Required]
        public decimal CANTIDAD_MEDIDA { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }
        public virtual MARCA MARCA { get; set; }
        public virtual MEDIDA MEDIDA { get; set; }
        public virtual SONDEO SONDEO { get; set; }
    }

    [MetadataType(typeof(ProductoParcial))]
    public partial class PRODUCTO
    {

    }
}