using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public String UserId { get; set; }

        [DisplayName("Ocjena")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ocjena { get; set; }

        [DisplayName("Komentar")]
        public string Komentar { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime? Kreirano { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
