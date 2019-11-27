using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Sondeo_web_7eam.Models.Parciales
{
    public class ProductoParcial
    {
        [Required]
        [Display(Name = "Ingrese el ID del Producto")]
        public string ID_PRODUCTO { get; set; }
        [Required]
        [Display(Name = "Seleccione el ID de su Categoria")]
        public string ID_CATEGORIA { get; set; }
        [Required]
        [Display(Name = "Seleccione una Unidad de Medida")]
        public Nullable<int> UNIDAD_MEDIDA { get; set; }
        [Required]
        [Display(Name = "Ingrese la marca a la que pertenece")]
        public string ID_MARCA { get; set; }
        [Required]
        [Display(Name = "Ingrese el nombre del producto")]
        public string PRODUCTO1 { get; set; }
        [Required]
        [Display(Name = "Ingrese el tamaño de la presentación del Producto")]
        public string PRESENTACION { get; set; }
        [Required]
        [Display(Name = "Ingrese el precio Consultado")]
        public decimal PRECIO_CONSULTA { get; set; }
        [Required]
        [Display(Name = "Ingrese el tipo de este Producto")]
        public string TIPO { get; set; }
        public Nullable<bool> ALPORMAYOR { get; set; }
        public int ID_SONDEO { get; set; }
        public Nullable<decimal> CANTIDAD_MEDIDA { get; set; }
    }

    [MetadataType(typeof(ProductoParcial))]
    public partial class PRODUCTO
    {

    }

}