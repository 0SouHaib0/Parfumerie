using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ClassUser
    {
        
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string email { get; set; }
            public string Adresse { get; set; }
        public int CLientID { get; set; }
    }
}