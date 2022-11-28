using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ListClientModel
    {
        public int NbCLients { get; set; }

        public CLIENT c { get; set; }
        public List<CLIENT> AllClients { get; set; }
    }
}