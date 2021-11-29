using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Radnik
    {
            public Radnik()
            {
                Narudzba = new HashSet<Narudzba>();
            }

            public int RadnikId { get; set; }
            public string ImePrezimeRadnika { get; set; }
            public string BrojTelefonaRadnika { get; set; }
            public string EmailRadnika { get; set; }
            public decimal? PlataRadnika { get; set; }

            public virtual ICollection<Narudzba> Narudzba { get; set; }
        
    }
}
