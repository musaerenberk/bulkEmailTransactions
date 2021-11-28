using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TopluMail.Core.Helper
{
    public class EpostaIslemleri
    {
        public static void emailGonder(string isimsoyisim, string emailadres, string konu, string icerik)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("cengizatillaudemy@cengizatilla.com", "ABCD Magaza");
            mail.To.Add(new MailAddress(emailadres, isimsoyisim));
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("mail.cengizatilla.com", 587);
            client.Credentials = new System.Net.NetworkCredential("cengizatillaudemy@cengizatilla.com", "Q184NAbg");
            client.EnableSsl = false;

            client.Send(mail);
        }
    }
}
