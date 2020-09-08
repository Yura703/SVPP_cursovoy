namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Storage")]
    public partial class Storage
    {
        [Key]
        public int Storage_id { get; set; }

        public int Tests_id { get; set; }

        public int Tabel_id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Data_Quest { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Test Test { get; set; }
    }
}
