using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sondeo_web_7eam.Models.Parciales
{

    public class MarcaCE
    {
        [Required]
        [Index(IsUnique = true)]
        [Display(Name = "Codigo de Marca:")]
        public string ID_MARCA { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [Display(Name = "Nombre de la Marca:")]
        public string MARCA1 { get; set; }

    }


    [MetadataType(typeof(MarcaCE))]
    public partial class MARCA
    {
        
    }
}