using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Project_WPF
{
    [Table("ViewEmployee")]
    public partial class ViewEmployee
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tabel_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FIO { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(80)]
        public string dep_name { get; set; }

        [StringLength(63)]
        public string title_name { get; set; }

        public int? var_id { get; set; }

        public bool? need_print { get; set; }

        public bool? passed { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Date { get; set; }

        public int? gr_security { get; set; }

        public int? interval { get; set; }
    }
}