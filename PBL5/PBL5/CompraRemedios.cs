//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL5
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompraRemedios
    {
        public int Id { get; set; }
        public int ReceitaId { get; set; }
    
        public virtual Receita Receita { get; set; }
    }
}
