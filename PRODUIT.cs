//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUIT
    {
        public int ProduitID { get; set; }
        public string Nom { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public Nullable<int> Prix { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> MarqueID { get; set; }
        public Nullable<int> CategorieID { get; set; }
    
        public virtual CATEGORIE CATEGORIE { get; set; }
        public virtual MARQUE MARQUE { get; set; }
        public virtual TYPE TYPE { get; set; }
    }
}