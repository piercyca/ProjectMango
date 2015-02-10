namespace Mango.Core.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MangoContext : DbContext
    {
        public MangoContext()
            : base("name=MangoContext")
        {
        }

        #region Products

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

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
