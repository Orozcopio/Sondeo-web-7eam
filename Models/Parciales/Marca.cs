using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sondeo_web_7eam.Models.Parciales
{

    public partial class MARCA
    {
        [Required]
        [Index(IsUnique = true)]
        [Display(Name = "Codigo de Marca: ")]  
        public int ID_MARCA { get; set; } 


        [Required]
        [Index(IsUnique = true)]
        [Display(Name = "Nombre de la Marca:")]
        public string MARCA1 { get; set; }

    }


    [MetadataType(typeof(MARCA))]
    public partial class MARCA
    {
        
    }
}