using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            Placanje = new HashSet<Placanje>();
        }

        public int NarudzbaId { get; set; }
        public int? UslugaId { get; set; }
        public int? RadnikId { get; set; }
        public string AdresaNarudzbe { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public DateTime? VrijemePocetka { get; set; }
        public DateTime? VrijemeKraja { get; set; }
        public bool? NarudzbaPotvrdjena { get; set; }
        public string EmailNarucioca { get; set; }
        public string BrojTelefonaNarucioca { get; set; }

        public virtual Radnik Radnik { get; set; }
        public virtual Usluga Usluga { get; set; }
        public virtual ICollection<Placanje> Placanje { get; set; }
    }
}
