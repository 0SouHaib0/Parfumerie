using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DetailModel
    {
        public PRODUIT nouv { get; set; }
        public List<MARQUE> allMarques { get; set; }
    }
}