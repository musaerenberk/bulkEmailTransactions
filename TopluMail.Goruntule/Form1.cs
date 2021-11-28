using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.TopluMail.Core.Repository;
using Udemy.TopluMail.Entities;

namespace Udemy.TopluMail.Goruntule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KayitListe();
        }

        private void btn_ornek_data_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                Musteri musteri = new Musteri();
                musteri.Ad = FakeData.NameData.GetFirstName();
                musteri.Soyad = FakeData.NameData.GetSurname();
                musteri.EmailAdres = musteri.Ad + "." + musteri.Soyad + "@" + FakeData.NetworkData.GetDomain();
                using (MusteriRepository musterirepo = new MusteriRepository())
                {
                    musterirepo.KayitEKLE(musteri);
                }
            }
            KayitListe();
        }

        void KayitListe()
        {
            List<Musteri> musteriListesi = new List<Musteri>();
            using (MusteriRepository musterirepo = new MusteriRepository())
            {
                musteriListesi =  musterirepo.TumListe();
            }
            grd_musteri.DataSource = musteriListesi;
        }

        private void btn_yenile_Click(object sender, EventArgs e)
        {
            KayitListe();
        }
    }
}
