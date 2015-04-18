using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mango.Core.Entity
{
    public class MangoContext : DbContext
    {
        public MangoContext()
            : base("name=MangoContext")
        {
        }

        #region Orders

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLineItem> OrderLineItems { get; set; }

        #endregion

        #region Products

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductUrlSlugRedirect> ProductUrlSlugRedirects { get; set; }

        #endregion

        #region Organizations 
        // i.e. UGA

        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationImage> OrganizationImages { get; set; }

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Products

            modelBuilder.Entity<Product>()
               .HasRequired(product => product.ProductCategory)
               .WithMany(productCategory => productCategory.Products)
               .HasForeignKey(product => product.ProductCategoryId);

            modelBuilder.Entity<ProductImage>()
                .HasRequired(productImage => productImage.Product)
                .WithMany(product => product.ProductImages)
                .HasForeignKey(productImage => productImage.ProductId);

            #endregion

            #region Orders

            modelBuilder.Entity<Order>()
                .HasRequired(e => e.Customer)
                .WithMany()
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Order>()
            //    .HasRequired(e => e.BillAddress)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasRequired(e => e.ShipAddress)
                .WithMany()
                .WillCascadeOnDelete(false);

            #endregion

            #region Organization

            modelBuilder.Entity<OrganizationImage>()
                .HasRequired(organizationImage => organizationImage.Organization)
                .WithMany(organization => organization.OrganizationImages)
                .HasForeignKey(organizationImage => organizationImage.OrganizationId);

            #endregion
        }
    }
}
