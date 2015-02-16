using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mango.Core.Data
{
    public class MangoContext : DbContext
    {
        public MangoContext()
            : base("name=MangoContext")
        {
        }

        #region Products

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductConfig> ProductConfigs { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Products

            modelBuilder.Entity<Product>()
               .HasRequired(e => e.ProductCategory)
               .WithMany()
               .HasForeignKey(f => f.ProductCategoryId);

            #endregion
        }
    }
}
