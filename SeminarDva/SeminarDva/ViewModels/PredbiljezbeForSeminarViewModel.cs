using SeminarDva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarDva.ViewModels
{
    public class PredbiljezbeForSeminarViewModel
    {
        public int? Id { get; set; }
        public Seminar Seminar { get; set; }
        public List<Predbiljezba> Predbiljezbe { get; set; }
    }
}