using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeminarDva.Models
{
    public class Seminar
    {
        [Key]
        public int IdSeminar { get; set; }
        [Required(ErrorMessage = "Naziv je obavezan!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Naziv mora biti između 3 - 40 znakova.")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Opis je obavezan!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Naziv mora biti između 3 - 50 znakova.")]
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public bool Popunjen { get; set; }
        public virtual ICollection<Predbiljezba> Predbiljezba { get; set; }
        public int? BrojMjesta { get; set; }
    }
}