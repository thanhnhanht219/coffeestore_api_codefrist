using coffeestore_online.Models;
using coffeestore_online.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace coffeestore_online.Controllers
{
    public class TypeOfProductController : ApiController
    {
        private TypeOfProduct_Repository _repository = new TypeOfProduct_Repository();

        [HttpGet]
        [Route("api/typeofproduct")]
        public HttpResponseMessage Get()
        {
        
            var items = _repository.List();
            if(items != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    items.Select(x => _repository.convertToModel(x)));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }
    }
}
