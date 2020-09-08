namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Title
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Title()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public int title_id { get; set; }

        [StringLength(63)]
        public string title_name { get; set; }

        [StringLength(50)]
        public string title_abvr { get; set; }

        public int? var_id { get; set; }

        public int? gr_security { get; set; }

        public int? interval { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
