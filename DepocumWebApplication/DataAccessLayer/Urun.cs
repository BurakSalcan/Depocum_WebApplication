using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Urun
    {

        public int ID { get; set; }

        public string Isim { get; set; }

        public DateTime Ekleme_Tarihi { get; set; }
        //DateTime olmazsa string olarak değiştireceğiz.
        public int Depo_ID { get; set; }

        public int Raf_ID { get; set; }

        public int Palet_ID { get; set; }

        public int Uye_ID { get; set; }

    }
}
