﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Remedio> RemedioSet { get; set; }
        public virtual DbSet<Medico> MedicoSet { get; set; }
        public virtual DbSet<Receita> ReceitaSet { get; set; }
        public virtual DbSet<Doença> DoençaSet { get; set; }
        public virtual DbSet<CompraRemedios> CompraRemediosSet { get; set; }
    }
}
