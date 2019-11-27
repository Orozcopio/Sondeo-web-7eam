using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sondeo_web_7eam.Models
{
    public class MarcasParcial
    {
        [Display(Name = "Marca")]
        public int ID_MARCA { get; set; }
        [Display(Name = "Marca")]
        public string MARCA1 { get; set; }
    }

    [MetadataType(typeof(MarcasParcial))]
    public partial class MARCA
    {

    }
}