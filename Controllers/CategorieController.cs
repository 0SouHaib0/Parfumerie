using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Categorie
        public ActionResult CategorieProduit(int n)
        {
            SOSEntities model;
            model = new SOSEntities();
            CategorieModel vm = new CategorieModel();

            List<PRODUIT> hs;
            hs = model.PRODUITs.Where(o => o.CategorieID == n).ToList();

            vm.listProduit = hs;



            return View("CategorieView",vm);
        }

       
    }
}