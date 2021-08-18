using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class LibrosViewModel
    {
        public int IdLibro { get; set; }
        public Nullable<int> IdEditorial { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }
        public virtual ICollection<Autores_Has_Libros> Autores_Has_Libros { get; set; }
        public virtual Editoriales Editoriales { get; set; }
    }
}