﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class restaurant_projectEntities : DbContext
    {
        public restaurant_projectEntities()
            : base("name=restaurant_projectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Commandes> Commandes { get; set; }
        public virtual DbSet<Plats> Plats { get; set; }
        public virtual DbSet<Serveur> Serveur { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<TotalCommandes> TotalCommandes { get; set; }
    }
}