using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SearchModel
    {
        public List<PRODUIT> listProduit { get; set; }
        public List<MARQUE> allMarques { get; set; }
    }
}