using coffeestore_online.Models;
using coffeestore_online.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace coffeestore_online.Controllers
{
    public class ProductController : ApiController
    {
        private Product_Repository _repository = new Product_Repository();

        //GET:api/Product
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            var items = _repository.List();
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items.Select(pr=> _repository.convertToModel(pr)));
        }

        //GET:api/Product/1
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(string id)
        {
            var items = _repository.convertToModel(_repository.Get(id));
            if(items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        //POST: api/Product
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post(Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository.Insert(product);
            }
            catch
            {
                return BadRequest();
            }
            return CreatedAtRoute("DefaultApi", 
                new Product { ProductId = product.ProductId },
                product );
        }

        //PUT 
        [ResponseType(typeof(Product))]
        public IHttpActionResult Put(Product product, string id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != product.ProductId)
            {
                return BadRequest();
            }
            try
            {
                _repository.Update(product, id);
            }
            catch
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //DELETE 
        [ResponseType(typeof(Product))]
        public IHttpActionResult Delete(string id)
        {
            var item = _repository.Get(id).ProductId;
            if(item == null)
            {
                return NotFound();
            }
            try{
                _repository.Delete(id);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_repository.List().Select(pr => _repository.convertToModel(pr)));
        }




    }
}
