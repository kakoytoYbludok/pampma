using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gostinka
{
    internal class Uslugi
    {
        public string ManStr = String.Empty;
        public string GirlStr = String.Empty;
        public int PriceGirl = 0;
        public int PricePokraska = 0;
        public int PriceMan = 0;
        public int PriceManik = 0;
        public int PriceChistka = 0;
        public string Pokraska = String.Empty;
        public string Manik = String.Empty;
        public string ChistkaLic = String.Empty;
        public DateTime? Date;
        public string Time;
        private static Uslugi _instance;

        public static Uslugi Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Uslugi();
                }
                return _instance;
            }
        }

        public void InitUsluga(string Pokraska, int PricePokraska)
        {
            Instance.Pokraska = Pokraska;
            Instance.PricePokraska = PricePokraska;
           
        }
        public void InitUsluga2(string GirlStr, int PriceGirl)
        {
            Instance.GirlStr = GirlStr;
            Instance.PriceGirl = PriceGirl;

        }

        public void InitUsluga3(string ManStr, int PriceMan, DateTime? Date, string Time)
        {
            Instance.ManStr = ManStr;
            Instance.PriceMan = PriceMan;
            Instance.Date = Date;
            Instance.Time = Time;

        }
        public void InitUsluga4(string Manik, int PriceManik)
        {
            Instance.Manik = Manik;
            Instance.PriceManik = PriceManik;

        }public void InitUsluga5(string ChistkaLic, int PriceChistka)
        {
            Instance.ChistkaLic = ChistkaLic;
            Instance.PriceChistka = PriceChistka;

        }

    }
}
    

