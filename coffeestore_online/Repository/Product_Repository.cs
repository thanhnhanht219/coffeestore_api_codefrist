using coffeestore_online.IRepository;
using coffeestore_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coffeestore_online.Repository
{
    public class Product_Repository : IRepository<Product>
    {
        CoffeeStoreDBContext data = new CoffeeStoreDBContext();

        public List<Product> List()
        {
            return data.Products.ToList();
        }


        public Product Get(string id)
        {
            return data.Products.Where(t => t.ProductId.Equals(id)).FirstOrDefault();
        }

        public void Insert(Product item)
        {
            data.Products.Add(item);
            data.SaveChanges();
        }

        public void Delete(string id)
        {
            data.Products.Remove(data.Products.Find(id));
            data.SaveChanges();
        }

        public void Update(Product item, string id)
        {
            data.Entry(item).State = System.Data.Entity.EntityState.Modified;
            data.SaveChanges();
        }

        public Product getAll(Product top)
        {
            Product model = new Product();
            model.ProductId = top.ProductId;
            model.ProductName = top.ProductName;


            return model;
        }

        public Product convertToModel(Product item)
        {
            Product model = new Product();
            model.ProductId = item.ProductId;
            model.ProductName = item.ProductName;
            model.ProductPrice = item.ProductPrice;
            model.ProductDescription = item.ProductDescription;
            model.ProductFileNameImg = item.ProductFileNameImg;
            model.ProductStatus = item.ProductStatus;
            model.TypeOfProductId = item.TypeOfProductId;
            return model;
        }
    }
}