//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public int GenreId { get; set; }
        public decimal BoxOffice { get; set; }
    
        public virtual Genre Genre { get; set; }
    }
}
