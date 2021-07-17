using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Test")
        {
        }

        public virtual DbSet<tblClass> tblClasses { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblClass>()
                .HasMany(e => e.tblStudents)
                .WithRequired(e => e.tblClass)
                .WillCascadeOnDelete(false);
        }
    }
}
