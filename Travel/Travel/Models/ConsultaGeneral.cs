using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace Travel.Models
{
    public class ConsultaGeneral
    {
        [Key]
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NombresEditorial { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }


    }
}