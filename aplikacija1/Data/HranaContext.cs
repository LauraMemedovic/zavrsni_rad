using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aplikacija1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace aplikacija1.Data
{
    public class HranaContext : DbContext
    {
        public HranaContext() : base("HranaContext")
        {

        }

        public DbSet<Recept> Recepti { get; set; }
        public DbSet<Prehrana> Prehrane { get; set; }
        public DbSet<PopisRecepata> PopisiRecepata { get; set; }
        public DbSet<Omiljeni> OmiljeniR { get; set; }
        public DbSet<Sastojak> Sastojci { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}