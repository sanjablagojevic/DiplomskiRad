using System;
using System.Collections.Generic;
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
        public int? KategorijaId { get; set; }
        public string NazivUsluge { get; set; }
        public decimal CijenaUsluge { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }
    }
}
