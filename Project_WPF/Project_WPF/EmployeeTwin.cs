using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_WPF
{
    public class EmployeeTwin 
    {
        public int Tabel_id { get; set; }
        public string department { get; set; }
        public string title { get; set; }
        public string FIO { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public bool passed { get; set; }
        public bool need_print { get; set; }
        public int NamberComission { get; set; }
        public int NamberVariant { get; set; }
    }
}
