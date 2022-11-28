using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SOSOEntities model = new SOSOEntities();
            List<PRODUIT> all;
            List<MARQUE> allM;

            all = model.PRODUITs.ToList();
            allM = model.MARQUEs.ToList();

            AllProduitModel vm;
            vm = new AllProduitModel();
            vm.allProduits = all;
            vm.allMarques = allM;
            return View("IndexView",vm);
        }

        public ActionResult ContactUs()
        {
            return View("ContactUsView");
        }



            public ActionResult CategorieProduit(int n)
        {
            SOSOEntities model;
            model = new SOSOEntities();
            CategorieModel vm = new CategorieModel();

            List<MARQUE> allM;
            allM = model.MARQUEs.ToList();
            vm.allMarques = allM;
            List<PRODUIT> hs;
            hs = model.PRODUITs.Where(o => o.CategorieID == n).ToList();

            vm.listProduit = hs;



            return View("CategorieView", vm);
        }

        public ActionResult Search(string mot)
        {
            SOSOEntities model;
            model = new SOSOEntities();
            SearchModel vm = new SearchModel();
            if (!String.IsNullOrEmpty(mot))
            {
                List<PRODUIT> ls ;
                ls = model.PRODUITs.Where(o => o.Nom.Contains(mot)).ToList() ; 

            vm.listProduit = ls;
            }
            List<MARQUE> allM;
            allM = model.MARQUEs.ToList();
            vm.allMarques = allM;

            return View("SearchView", vm);
        }

        public ActionResult Marque(int n)
        {
            SOSOEntities model;
            model = new SOSOEntities();

            List<PRODUIT> Ss;
            Ss = model.PRODUITs.Where(o => o.MarqueID == n).ToList();
            MarqueModel vm = new MarqueModel () ;

                vm.listProduit = Ss;
           
            List<MARQUE> allM;
            allM = model.MARQUEs.ToList();
            vm.allMarques = allM;

            return View("MarqueView", vm);
        }

        public ActionResult Detail(int id)
        {
            SOSOEntities model;
            model = new SOSOEntities();

            PRODUIT p = new PRODUIT();
            p = model.PRODUITs.FirstOrDefault(o => o.ProduitID == id);
            DetailModel vm = new DetailModel();

            vm.nouv= p;

            List<MARQUE> allM;
            allM = model.MARQUEs.ToList();
            vm.allMarques = allM;

            return View("DetailView", vm);
        }

        public ActionResult ListProduit()
        {
            return View();
        }
        public ActionResult GetProduits()
        {
            /*  using (SOSEntities1 db = new SOSEntities1())
              {
                  var emplist = db.CLIENTs.ToList<CLIENT>();
                  return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
              }*/
            SOSOEntities model = new SOSOEntities();
            var cli = model.PRODUITs.Select(o => new
            {
                id = o.ProduitID,
                nom = o.Nom,
                prix = o.Prix,
                marque = model.MARQUEs.FirstOrDefault(s=>s.MarqueID ==o.MarqueID).NomMarque,
                type= model.TYPEs.FirstOrDefault(s => s.TypeID == o.TypeID).NomType,
                categorie = model.CATEGORIEs.FirstOrDefault(s => s.CategorieID == o.CategorieID).NomCtg
            }).ToList();
            return Json(new { data = cli }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AjoutModifieProduit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                using (SOSOEntities db = new SOSOEntities())
                {
                    return View(db.PRODUITs.Where(x => x.ProduitID == id).FirstOrDefault<PRODUIT>());
                }
            }

        }

        [HttpPost]
        public ActionResult AjoutModifieProduit(PRODUIT c)
        {
            using (SOSOEntities db = new SOSOEntities())
            {
                if (c.ProduitID == 0)
                {
                    db.PRODUITs.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("ListProduit");
                }
                else
                {
                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ListProduit");
                }

            }
        }

        public ActionResult supprimerProduit(int id)
        {
            using (SOSOEntities db = new SOSOEntities())
            {
                PRODUIT emp = db.PRODUITs.Where(x => x.ProduitID == id).FirstOrDefault<PRODUIT>();
                db.PRODUITs.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("ListProduit");
            }
        }

    }
}