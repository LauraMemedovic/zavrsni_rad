using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aplikacija1.Models
{
    public class Omiljeni
    {
        public int OmiljeniID { get; set; }
        public int SastojakID { get; set; }
        public int PopisRecepataID { get; set; }


        public virtual Sastojak Sastojak { get; set; }
        public virtual PopisRecepata PopisRecepata { get; set; }
    }
}