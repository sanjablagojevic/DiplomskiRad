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
        [DisplayName("Service")]
        public int? UslugaId { get; set; }

        [DisplayName("Worker")]
        public String UserId { get; set; }

        [DisplayName("Address")]
        [Required]
        public string AdresaNarudzbe { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        [Required]
        public DateTime DatumNarudzbe { get; set; }

        [DisplayName("Start time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Required]
        public DateTime? VrijemePocetka { get; set; }

        [DisplayName("End time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime? VrijemeKraja { get; set; }
        public bool? NarudzbaPotvrdjena { get; set; }
        [DisplayName("Email")]
        [Required]
        public string EmailNarucioca { get; set; }
        [DisplayName("Mobile phone")]
        public string BrojTelefonaNarucioca { get; set; }
        [DisplayName("Surface")]
        public decimal BrojKvadrata { get; set; }

        public virtual ApplicationUser User { get; set; }
        [DisplayName("Service")]
        public virtual Usluga Usluga { get; set; }
        public virtual ICollection<Placanje> Placanje { get; set; }
    }
}
