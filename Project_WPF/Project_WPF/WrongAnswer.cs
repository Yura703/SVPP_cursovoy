namespace Project_WPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WrongAnswer
    {
        [Key]
        public int WrongAnswers_id { get; set; }

        public int Tabel_id { get; set; }

        public int Questions_id { get; set; }

        public short Question_number { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Date_Test { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
