using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TopluMail.Core.Database;
using Udemy.TopluMail.Core.Helper;
using Udemy.TopluMail.Core.Interface;
using Udemy.TopluMail.Entities;

namespace Udemy.TopluMail.Core.Repository
{
    public class MusteriRepository : globalIslemler, IMusteriRepository, IDisposable
    {
        SqlCommand cmd;
        SqlDataReader reader;
        int ReturnValue;
        DataAccessLayer DAL;

        public MusteriRepository()
        {
            DAL = new DataAccessLayer();
        }

        public Musteri GetirID(int ID)
        {
            Musteri musteri = new Musteri();
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("MusteriGetirID");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                reader = DAL.VeriGetir(cmd);
                while (reader.Read())
                {
                    musteri = new Musteri()
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Soyad = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        KuponKOD = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        KuponDurum = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        KuponAktifTarih = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6),
                    };
                }
                reader.Close();
                DAL.con.Close();
            });
            return musteri;
        }

        public int KayitEKLE(Musteri m)
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("KayitEKLE");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Ad", SqlDbType.NVarChar).Value = m.Ad;
                cmd.Parameters.Add("@Soyad", SqlDbType.NVarChar).Value = m.Soyad;
                cmd.Parameters.Add("@EmailAdres", SqlDbType.NVarChar).Value = m.EmailAdres;
                ReturnValue = DAL.Calistir(cmd);

            });
            return ReturnValue;
        }

        public int MusteriKuponATA(Musteri m)
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("KuponKODAta");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = m.ID;
                cmd.Parameters.Add("@KuponKOD", SqlDbType.NVarChar).Value = m.KuponKOD;
                cmd.Parameters.Add("@KuponDurum", SqlDbType.Bit).Value = m.KuponDurum;
                ReturnValue = DAL.Calistir(cmd);

            });
            return ReturnValue;
        }

        public Musteri MusteriKuponAra(string kuponKod)
        {
            Musteri musteri = new Musteri();
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("MusteriKuponKODARA");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@KuponKOD", SqlDbType.NVarChar).Value = kuponKod;
                reader = DAL.VeriGetir(cmd);
                while (reader.Read())
                {
                    musteri = new Musteri()
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Soyad = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        KuponKOD = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        KuponDurum = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        KuponAktifTarih = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6),
                    };
                }
                reader.Close();
                DAL.con.Close();
            });
            return musteri;
        }

        public string MusteriKuponUret()
        {
            string musteriKupon = string.Empty;
            TryCatchKullan(() =>
            {
                do
                {
                    Random rnd = new Random();
                    musteriKupon = rnd.Next(111111, 999999).ToString();
                    cmd = new SqlCommand("KuponKODKontrol");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@KuponKOD", SqlDbType.NVarChar).Value = musteriKupon;
                } while (DAL.CalistirINT(cmd) > 0);
            });
            return musteriKupon;
        }

        public List<Musteri> TumListe()
        {
            List<Musteri> musteriListe = new List<Musteri>();
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("MusteriListe");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                reader = DAL.VeriGetir(cmd);
                while (reader.Read())
                {
                    musteriListe.Add(new Musteri()
                    {
                        ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Soyad = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        KuponKOD = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        KuponDurum = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                        KuponAktifTarih = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6),
                    });
                }
                reader.Close();
                DAL.con.Close();
            });
            return musteriListe;
        }

        public void MusteriKuponKodDogrula(string kuponKOD)
        {
            TryCatchKullan(() => 
            {
                cmd = new SqlCommand("KuponKODGuncelle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@KuponKOD", SqlDbType.NVarChar).Value = kuponKOD;
                DAL.Calistir(cmd);
            });
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
