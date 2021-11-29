using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Utisak
    {
        public Utisak()
        {
            Kreirano = DateTime.Now;
        }
        public int UtisakId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Ocjena { get; set; }
        public string Komentar { get; set; }
        public DateTime? Kreirano { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
