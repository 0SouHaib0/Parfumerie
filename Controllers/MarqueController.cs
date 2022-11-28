using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MarqueController : Controller
    {
        // GET: Marque
        public ActionResult ListMarques()
        {
            return View();
        }
        public ActionResult GetMarques()
        {
            /*  using (SOSEntities1 db = new SOSEntities1())
              {
                  var emplist = db.CLIENTs.ToList<CLIENT>();
                  return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
              }*/
            SOSOEntities model = new SOSOEntities();
            var cli = model.MARQUEs.Select(o => new
            {
                MarqueID = o.MarqueID,
                Nom = o.NomMarque,
            }).ToList();
            return Json(new { data = cli }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AjoutModifieMarque(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                using (SOSOEntities db = new SOSOEntities())
                {
                    return View(db.MARQUEs.Where(x => x.MarqueID == id).FirstOrDefault<MARQUE>());
                }
            }

        }

        [HttpPost]
        public ActionResult AjoutModifieMarque(MARQUE c)
        {
            using (SOSOEntities db = new SOSOEntities())
            {
                if (c.MarqueID == 0)
                {
                    db.MARQUEs.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("ListMarques");
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ListMarques");
                }

            }
        }

        public ActionResult supprimerMarque(int id)
        {
            using (SOSOEntities db = new SOSOEntities())
            {
                MARQUE emp = db.MARQUEs.Where(x => x.MarqueID == id).FirstOrDefault<MARQUE>();
                db.MARQUEs.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("ListMarques");
            }
        }

    }
}