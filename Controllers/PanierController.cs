using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class PanierController : Controller
    {
        private SOSOEntities de = new SOSOEntities();
        // GET: Panier
        public ActionResult Index()
        {
            return View("CartView");
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pr.ProduitID == id)
                    return i;
            return -1;
        }

        public ActionResult RetirerPanier(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("CartView"); 
        }

            public ActionResult AjouterPanier(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(de.PRODUITs.Find(id), 1));
                Session["cart"] = cart;
                
            }
            else
            {
                List<Item> cart = (List < Item >) Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(de.PRODUITs.Find(id), 1));
                else
                    cart[index].Quantite++;
                Session["cart"] = cart;
            }
            return RedirectToAction("Index","Produit"); 
        }
    }
}