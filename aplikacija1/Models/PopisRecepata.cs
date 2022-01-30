using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aplikacija1.Models
{
    public class PopisRecepata
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Sastojak { get; set; }
        public string Sastojak2 { get; set; }

        public string Slozenost { get; set; }
    }
}