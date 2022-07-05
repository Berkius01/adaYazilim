using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace adaYazilim.Models
{
    public class Train
    {

        public class Tren {
            public String Ad { get; set; }
            public List<Vagon> Vagonlar { get; set; }
        }
        
        public class Vagon {
            public String Ad { get; set; }
            public int Kapasite { get; set; }
            public int DoluKoltukAdet { get; set; }
        }
        
        public Tren tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public Boolean KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
        


        public string toString() {

            return  "!";
        }
    }
}
