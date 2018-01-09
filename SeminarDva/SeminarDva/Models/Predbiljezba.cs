using System;
using System.ComponentModel.DataAnnotations;

namespace SeminarDva.Models
{
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }
        public DateTime DatumPredbiljezbe { get; set; }

        [Required(ErrorMessage = "Ime je obavezno!")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Ime mora biti između 1 - 20 znakova.")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Prezime mora biti između 1 - 20 znakova.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Adresa je obavezna!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Adresa mora biti između 5 - 70 znakova.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Email je obavezan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon je obavezan")]
        public string Telefon { get; set; }

        public int? IdSeminar { get; set; }
        public virtual Seminar Seminar { get; set; }
        public bool Status { get; set; }
    }
}