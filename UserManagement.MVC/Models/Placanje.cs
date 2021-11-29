using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public partial class Placanje
    {
            public int PlacanjeId { get; set; }
            public int? NacinPlacanjaId { get; set; }
            public int? NarudzbaId { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal IznosPlacanja { get; set; }
            public string CreditCardNumber { get; set; }
            public DateTime? CreditCaredExpDate { get; set; }
            public string CreditHolderName { get; set; }

            public virtual NacinPlacanja NacinPlacanja { get; set; }
            public virtual Narudzba Narudzba { get; set; }
    }
}
