﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinMonitorApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WinMonitorEntityModelContext : DbContext
    {
        public WinMonitorEntityModelContext()
            : base("name=WinMonitorEntityModelContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DBComponent_With_Status> DBComponent_With_Status { get; set; }
        public DbSet<DBIncident> DBIncidents { get; set; }
        public DbSet<DBLogin> DBLogins { get; set; }
        public DbSet<DBMaster_DBComponent_With_Status> DBMaster_DBComponent_With_Status { get; set; }
        public DbSet<DBSubscription> DBSubscriptions { get; set; }
        public DbSet<DBLogHistory> DBLogHistories { get; set; }
        public DbSet<DBCompany> DBCompanies { get; set; }
        public DbSet<DBDataCenter> DBDataCenters { get; set; }
    }
}