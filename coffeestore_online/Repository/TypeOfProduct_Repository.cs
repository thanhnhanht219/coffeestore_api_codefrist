using coffeestore_online.IRepository;
using coffeestore_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coffeestore_online.Repository
{
    public class TypeOfProduct_Repository : IRepository<TypeOfProduct>
    {
        CoffeeStoreDBContext data = new CoffeeStoreDBContext();

        public List<TypeOfProduct> List()
        {
            return data.TypeOfProducts.ToList();
        }

        public TypeOfProduct Get(string id)
        {
            return data.TypeOfProducts.Where(t => t.TypeOfProductId.Equals(id)).FirstOrDefault();
        }

        public void Insert(TypeOfProduct item)
        {
            
        }

        public void Delete(string id)
        {

        }

        public void Update(TypeOfProduct item, string id)
        {

        }

        public TypeOfProduct convertToModel(TypeOfProduct top)
        {
            TypeOfProduct model = new TypeOfProduct();
            model.TypeOfProductId = top.TypeOfProductId;
            model.TypeOfProductName = top.TypeOfProductName;
            return model;
        }
    }
}