using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Usluga")]
        public int? UslugaId { get; set; }

        [DisplayName("Radnik")]
        public String UserId { get; set; }

        [DisplayName("Adresa naručioca")]
        public string AdresaNarudzbe { get; set; }
        [DisplayName("Datum")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime DatumNarudzbe { get; set; }
        [DisplayName("Vrijeme početka")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime? VrijemePocetka { get; set; }
        [DisplayName("Vrijeme kraja")]
        public DateTime? VrijemeKraja { get; set; }
        public bool? NarudzbaPotvrdjena { get; set; }
        public string EmailNarucioca { get; set; }
        public string BrojTelefonaNarucioca { get; set; }

        public virtual ApplicationUser User { get; set; }
        [DisplayName("Usluga")]
        public virtual Usluga Usluga { get; set; }
        public virtual ICollection<Placanje> Placanje { get; set; }
    }
}
