using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AllProduitModel
    {
       public List<PRODUIT> allProduits { get; set; }
        public List<MARQUE> allMarques { get; set; }
    }
}