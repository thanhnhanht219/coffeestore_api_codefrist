namespace coffeestore_online.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Mapping;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.ComponentModel.Design;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class CoffeeStoreDBContext : DbContext
    {
       
        public CoffeeStoreDBContext()
            : base("name=CoffeeStoreDBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CoffeeStoreDBContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CoffeeStoreDBContext, coffeestore_online.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeOfProduct>()
              .ToTable("TypeOfProduct");
            modelBuilder.Entity<Product>()
             .ToTable("Product");
        }

        public virtual DbSet<TypeOfProduct> TypeOfProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        
    }

    [Table(name:"dbo.TypeOfProduct")]
    public partial class TypeOfProduct
    {
        private string _TypeOfProductId;
        private string _TypeOfProductName;
        //primary key
        [Key]
        public string TypeOfProductId 
        {
            get
            {
                return this._TypeOfProductId;
            }
            set
            {
                if ((this._TypeOfProductId != value))
                {
                    this._TypeOfProductId = value;
                }
            }
        }
        [MaxLength(50)]
        public string TypeOfProductName 
        {
            get
            {
                return this._TypeOfProductName;
            }
            set
            {
                if ((this._TypeOfProductName != value))
                {
                    this._TypeOfProductName = value;
                }
            }
        }


        public virtual ICollection<Product> Products { get; set; }
    }


    [Table(name: "dbo.Product")]
    public partial class Product
    {
        // này đâu ra vậy? alo alo
        // tự viết
        private string _ProductId;
        private string _ProductName;
        private double _ProductPrice;
        private string _ProductDescription;
        private string _ProductFileNameImg;
        private bool _ProductStatus;
        private string _TypeOfProductId;
        [Key]
        public string ProductId 
        {
            get
            {
                return this._ProductId;
            }
            set
            {
                if ((this._ProductId != value))
                {
                    this._ProductId = value;
                }
            }
        }

        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                if((this._ProductName != value))
                {
                    this._ProductName = value;
                }    
            }
        }

        public double ProductPrice 
        {
            get
            {
                return this._ProductPrice;
            }
            set
            {
                if ((this._ProductPrice != value))
                {
                    this._ProductPrice = value;
                }
            }
        }

        public string ProductDescription {
            get
            {
                return this._ProductDescription;
            }
            set
            {
                if ((this._ProductDescription != value))
                {
                    this._ProductDescription = value;
                }
            }
        }

        public string ProductFileNameImg {
            get
            {
                return this._ProductFileNameImg;
            }
            set
            {
                if ((this._ProductFileNameImg != value))
                {
                    this._ProductFileNameImg = value;
                }
            }
        }

        public bool ProductStatus {
            get
            {
                return this._ProductStatus;
            }
            set
            {
                if ((this._ProductStatus != value))
                {
                    this._ProductStatus = value;
                }
            }
        }

        //fully defined relationship - xác định khóa ngoại
        public string TypeOfProductId {
            get
            {
                return this._TypeOfProductId;
            }
            set
            {
                if ((this._TypeOfProductId != value))
                {
                    this._TypeOfProductId = value;
                }
            }
        }
        public virtual TypeOfProduct TypeOfProduct { get; set; }

    }

}