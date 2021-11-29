using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Usluga = new HashSet<Usluga>();
        }

        public int KategorijaId { get; set; }

        [DisplayName("Naziv kategorije")]
        public string NazivKategorije { get; set; }

        public virtual ICollection<Usluga> Usluga { get; set; }
    }
}
