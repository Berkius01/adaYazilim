using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adaYazilim.Models;
using System.Text.Json;

namespace adaYazilim.Models
{
    public class TrainService
    {
        public JsonResult Assign(Train train)
        {
            TrainReturn treturn = new TrainReturn();
            JsonResult result;
            List<Ayrinti> tempAyrinti = new List<Ayrinti>();
            int temp = train.RezervasyonYapilacakKisiSayisi;
            treturn.RezervasyonYapilabilir = train.KisilerFarkliVagonlaraYerlestirilebilir;
            foreach (var vagon in train.tren.Vagonlar){
                double max = vagon.Kapasite * 0.7;
                
                //double tempCapacity = vagon.DoluKoltukAdet + train.RezervasyonYapilacakKisiSayisi;

                int bos = (int)(max - vagon.DoluKoltukAdet); // 20
                                                              //vagon.DoluKoltukAdet += train.RezervasyonYapilacakKisiSayisi; //53
                                                          // treturn.addAyrinti(vagon.Ad, fark);
                int kisiSayisi = bos - temp;
               if(bos > 0 && temp>0)
                {
                    if (kisiSayisi >= 0)
                    {
                        tempAyrinti.Add(new Ayrinti(vagon.Ad, temp));
                        temp -= bos;
                    }

                    else
                    {
                        if (bos == 0 || temp <= 0)
                        {
                            continue;
                        }
                        else
                        {
                            temp -= bos;
                            tempAyrinti.Add(new Ayrinti(vagon.Ad, bos));
                           
                        }
                    }

                }
                /*if (tempCapacity <= max )
                {
                    vagon.DoluKoltukAdet += train.RezervasyonYapilacakKisiSayisi;
                    //train.RezervasyonYapilacakKisiSayisi = 0;
                    

                }
                if (train.KisilerFarkliVagonlaraYerlestirilebilir || tempCapacity <= max)
                {

                    
                    treturn.addAyrinti(vagon.Ad, kisiSayisi);
                    train.RezervasyonYapilacakKisiSayisi -= kisiSayisi;
                }*/



            }
            if (temp <= 0) {
                if (treturn.YerlesimAyrinti.Count != 1 && train.KisilerFarkliVagonlaraYerlestirilebilir) {
                    treturn.YerlesimAyrinti = tempAyrinti;
                }
                else if(treturn.YerlesimAyrinti.Count == 1 && train.KisilerFarkliVagonlaraYerlestirilebilir==false)
                {
                    treturn.YerlesimAyrinti = tempAyrinti;
                }
                
            }
         
            
            return new JsonResult(treturn);
            
            
            
        }
    }
}
