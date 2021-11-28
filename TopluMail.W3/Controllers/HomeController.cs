using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.TopluMail.Core.Repository;
using Udemy.TopluMail.Entities;

namespace Udemy.TopluMail.W3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KuponOnay(string KuponKod = "Demo")
        {
            Musteri m = new Musteri();
            using (MusteriRepository musterirepo = new MusteriRepository())
            {
                m = musterirepo.MusteriKuponAra(KuponKod);
                if (m != null && m.ID > 0)
                {
                    musterirepo.MusteriKuponKodDogrula(KuponKod);
                }
                else
                {
                    m = null;
                }
            }

            return View(m);
        }
    }
}