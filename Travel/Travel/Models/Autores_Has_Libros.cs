//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Travel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autores_Has_Libros
    {
        public int IdAutorLibro { get; set; }
        public Nullable<int> Id_Autor { get; set; }
        public Nullable<int> Id_Libro { get; set; }
    
        public virtual autores autores { get; set; }
        public virtual Libros Libros { get; set; }
    }
}