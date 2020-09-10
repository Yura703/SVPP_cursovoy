namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Spatial;

    public partial class Questionn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questionn()
        {
            Tests = new HashSet<Test>();
            Tests1 = new HashSet<Test>();
            Tests2 = new HashSet<Test>();
            Tests3 = new HashSet<Test>();
        }

        [Key]
        public int Questions_id { get; set; }

        [Column("Question", TypeName = "ntext")]
        [Required]
        public string Question { get; set; }// public string Question1 { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Variant1 { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Variant2 { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Variant3 { get; set; }

        public byte Answer { get; set; }

        public int Var { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests2 { get; set; }

        public static explicit operator Questionn(DbRawSqlQuery<Questionn> v)
        {
            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Test> Tests3 { get; set; }
    }
}
