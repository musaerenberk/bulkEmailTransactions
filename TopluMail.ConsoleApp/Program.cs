using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TopluMail.Core.Helper;
using Udemy.TopluMail.Core.Repository;
using Udemy.TopluMail.Entities;

namespace Udemy.TopluMail.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string MailIcerik = "";
            using (MusteriRepository musterirepo = new MusteriRepository())
            {
                List<Musteri> musteriListele = musterirepo.TumListe();
                for (int i = 0; i < musteriListele.Count; i++)
                {
                    if (string.IsNullOrEmpty(musteriListele[i].KuponKOD))
                    {
                        musteriListele[i].KuponKOD = musterirepo.MusteriKuponUret();
                        musteriListele[i].KuponDurum = false;
                        musterirepo.MusteriKuponATA(musteriListele[i]);

                        // Eposta Gönderme işlemi 

                       
                        MailIcerik += "<div>";
                        MailIcerik += "<p>Merhaba</p>";
                        MailIcerik += "<p> " + musteriListele[i].Ad + " " + musteriListele[i].Soyad + "</p>";
                        MailIcerik += "<p>" + DateTime.Now.ToShortDateString() + " tarihinde mağazamız tarafından kullanabilmeniz için bir indirim kuponu oluşturulmuştur.</p>";
                        MailIcerik += " <p>ilgili indirim kuponunuzu aktif etmek için <a href='http://www.cengizatilla.com/Home/KuponOnay?KuponKod=" + musteriListele[i].KuponKOD + "'>Tıklayınız</a></p>";
                        MailIcerik += "<div>";

                        EpostaIslemleri.emailGonder(musteriListele[i].Ad + " " + musteriListele[i].Soyad, musteriListele[i].EmailAdres, "İndirim Kuponu", MailIcerik);

                    }
                }
            }




           

        }
    }
}
