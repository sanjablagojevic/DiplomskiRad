using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Usluga
    {
        public Usluga()
        {
            Narudzba = new HashSet<Narudzba>();
        }

        public int UslugaId { get; set; }
        [DisplayName("Category")]
        public int? KategorijaId { get; set; }
        [DisplayName("Service name")]
        public string NazivUsluge { get; set; }

        [DisplayName("Cost")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CijenaUsluge { get; set; }
        [DisplayName("Category")]
        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }
    }
}
