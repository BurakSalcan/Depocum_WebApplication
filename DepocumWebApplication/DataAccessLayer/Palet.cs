using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Palet
    {
        public int ID { get; set; }

        public string Isim { get; set; }

        public int Raf_ID { get; set; }

        public bool Durum { get; set; }

        public string DurumStr { get; set; }
    }
}
