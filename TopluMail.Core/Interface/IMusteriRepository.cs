using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TopluMail.Entities;

namespace Udemy.TopluMail.Core.Interface
{
    public interface IMusteriRepository
    {
        int KayitEKLE(Musteri m);
        int MusteriKuponATA(Musteri m);
        string MusteriKuponUret();
        Musteri MusteriKuponAra(string kuponKod);
        List<Musteri> TumListe();
        Musteri GetirID(int ID);
        void MusteriKuponKodDogrula(string kuponKOD);
    }
}
