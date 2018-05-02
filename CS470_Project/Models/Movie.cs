//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS470_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            this.Directors = new HashSet<Director>();
        }
    
        public int ISAN { get; set; }
        public string Title { get; set; }
        public int Yr { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int Runtime { get; set; }
        public int ProducerID { get; set; }
        public int GenreID { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Producer Producer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Director> Directors { get; set; }
    }
}
