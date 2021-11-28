using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TopluMail.Entities
{
    public class Musteri
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EmailAdres { get; set; }
        public string KuponKOD { get; set; }
        public bool KuponDurum { get; set; }
        public DateTime KuponAktifTarih { get; set; }
    }
}
