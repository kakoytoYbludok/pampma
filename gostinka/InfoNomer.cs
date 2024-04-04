using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gostinka
{
    internal class InfoNomer
    {

        public string NumberNomer;
        public string Vidnomera;
        public int PriceNomer;
        public string Bed;
        public DateTime? Zaselen;
        public string Viselen;
        private static InfoNomer _instance;

        public static InfoNomer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InfoNomer();
                }
                return _instance;
            }
        }

        public void InitInfoNomer(string NumberNomer, string Vidnomera, int PriceNomer, string Bed, DateTime? Zaselen, string Viselen)
        {
            Instance.NumberNomer = NumberNomer;
            Instance.Vidnomera = Vidnomera;
            Instance.PriceNomer = PriceNomer;
            Instance.Bed = Bed;
            Instance.Zaselen = Zaselen;
            Instance.Viselen = Viselen;

        }

        

    }
}



