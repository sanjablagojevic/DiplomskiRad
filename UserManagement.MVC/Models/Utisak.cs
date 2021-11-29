using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Utisak
    {
        public int UtisakId { get; set; }
        public decimal Ocjena { get; set; }
        public string Komentar { get; set; }
        public DateTime? Kreirano { get; set; }
    }
}
