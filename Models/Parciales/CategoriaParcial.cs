using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sondeo_web_7eam.Models
{
    public class CategoriaParcial
    {
        public int ID_CATEGORIA { get; set; }
        [Display(Name = "Categoria")]
        public string CATEGORIA1 { get; set; }
        [Display(Name = "Descripcion")]
        public string DESCRIPCION_CAT { get; set; }
    }

    [MetadataType(typeof(CategoriaParcial))]
    public partial class CATEGORIA
    {
        
    }
}