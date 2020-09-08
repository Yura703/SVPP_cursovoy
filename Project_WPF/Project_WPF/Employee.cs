namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Storages = new HashSet<Storage>();
            WrongAnswers = new HashSet<WrongAnswer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tabel_id { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public bool? passed { get; set; }

        public bool? need_print { get; set; }

        public int dep_id { get; set; }

        public int title_id { get; set; }

        public int? NamberComission { get; set; }

        public virtual Department Department { get; set; }

        public virtual Title Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
