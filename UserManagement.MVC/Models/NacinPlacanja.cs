using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class NacinPlacanja
    {
        public NacinPlacanja()
        {
            Placanje = new HashSet<Placanje>();
        }

        public int NacinPlacanjaId { get; set; }
        public string NazivNacinaPlacanja { get; set; }

        public virtual ICollection<Placanje> Placanje { get; set; }
    }
}
