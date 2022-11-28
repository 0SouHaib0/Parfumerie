using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult ListClients()
        {
            return View();
        }
            public ActionResult GetClients()
        {
            /*  using (SOSEntities1 db = new SOSEntities1())
              {
                  var emplist = db.CLIENTs.ToList<CLIENT>();
                  return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
              }*/
            SOSOEntities model = new SOSOEntities();
            var cli = model.CLIENTs.Select(o => new
            {
                Nom = o.Nom,
                Prenom = o.Prenom,
                Email = o.Email,
                Adresse = o.Adresse,
                num = o.Num,
                ClientID=o.ClientID
            }).ToList();
            return Json(new { data = cli }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AjoutModifie(int id=0)
        {
            if (id == 0)
                return View();
            else
            {
                using (SOSOEntities db = new SOSOEntities())
                {
                    return View(db.CLIENTs.Where(x => x.ClientID == id).FirstOrDefault<CLIENT>());
                }
            }
            
        }

        [HttpPost]
        public ActionResult AjoutModifie(CLIENT c)
        {
            using (SOSOEntities db = new SOSOEntities())
            {
                if (c.ClientID == 0)
                {
                    db.CLIENTs.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("ListClients");
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ListClients");
                }

            }
        }

        

        public ActionResult supprimer(int id)
        {
            using (SOSOEntities db = new SOSOEntities())
            {
                CLIENT emp = db.CLIENTs.Where(x => x.ClientID == id).FirstOrDefault<CLIENT>();
                db.CLIENTs.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("ListClients");
            }
        }


        public ActionResult Dashboard()
        {

            return View("DashboardView");
        }


        public ActionResult Formulaire()
        {
            return View("FormulaireView");
        }
        public ActionResult AddClient(string Nom, string Prenom, String Adresse, string Num, string Email, string Password)
        {
            SOSOEntities model = new SOSOEntities();

            CLIENT c = new CLIENT();
            c.Nom = Nom;
            c.Prenom = Prenom;
            c.Email = Email;
            c.Password = Password;
            c.Adresse = Adresse;
            c.Num = Num;
            model.CLIENTs.Add(c);
            model.SaveChanges();

            return View("LoginView");
        }
        public ActionResult Login()
        {
            return View("LoginView");
        }
        public ActionResult LoginCheck(string Email, string Password)
            {
            SOSOEntities model = new SOSOEntities();
            var obj = model.CLIENTs.Where(o => o.Email.Equals(Email) && o.Password.Equals(Password)).FirstOrDefault();
            if(obj != null)
            {
                ClassUser c = new ClassUser()
                {
                    Nom = obj.Nom,
                    CLientID=obj.ClientID,
                };
                Session["Data"] = c;
                return RedirectToAction("Index", "Produit");
            }
            else if (Email=="admin" && Password=="admin")
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Login");
            }

            }


        public ActionResult MonCompte(int id)
        {
            SOSOEntities sos = new SOSOEntities();
            CLIENT N = sos.CLIENTs.Where(o => o.ClientID.Equals(id)).FirstOrDefault();
            ListClientModel vm = new ListClientModel();
            vm.c = N;
            return View("MonCompteView",vm);
        }

        public ActionResult Deconnexion()
        {
            Session["data"] = null;
            return RedirectToAction("Index", "Produit");
        }




    }
}