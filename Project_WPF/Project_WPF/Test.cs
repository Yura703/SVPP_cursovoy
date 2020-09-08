namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            Storages = new HashSet<Storage>();
        }

        [Key]
        public int Tests_id { get; set; }

        public int Questions_1 { get; set; }

        public int Questions_2 { get; set; }

        public int Questions_3 { get; set; }

        public int Questions_4 { get; set; }

        public virtual Question Question { get; set; }

        public virtual Question Question1 { get; set; }

        public virtual Question Question2 { get; set; }

        public virtual Question Question3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
