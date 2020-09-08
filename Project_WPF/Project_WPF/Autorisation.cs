namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Autorisation")]
    public partial class Autorisation
    {
        [Key]
        [StringLength(20)]
        public string login { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }
    }
}
