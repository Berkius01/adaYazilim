using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adaYazilim.Models
{
    public class TrainReturn 
    {
        public TrainReturn() {
            YerlesimAyrinti = new List<Ayrinti>();
        }
        public Boolean RezervasyonYapilabilir { get; set; }

        public List<Ayrinti> YerlesimAyrinti { get; set; }

        public void addAyrinti(string adi, int sayi) {
            YerlesimAyrinti.Add(new Ayrinti(adi,sayi));
        }
        
    }
    public class Ayrinti
    {
        public Ayrinti(string adi, int sayi)
        {
            VagonAdi = adi;
            KisiSayisi = sayi;
        }
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
