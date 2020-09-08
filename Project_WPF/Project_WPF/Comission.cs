namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comission")]
    public partial class Comission
    {
        [Key]
        public int Comission_id { get; set; }

        public int NamberComission { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        public bool Head { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
