using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class Item
    {
        private PRODUIT pr=new PRODUIT();

        

        private int quantite;

       
        public int Quantite { get => quantite; set => quantite = value; }
        public PRODUIT Pr { get => pr; set => pr = value; }

        public Item()
        { }

        public Item(PRODUIT produit ,int quantite)
        {
            this.pr= produit;
            this.quantite= quantite;
        }
    }

}