using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    public class ProductsController : ApiController
    {
        List<ProductDTO>products = new List<ProductDTO>
        {
            new ProductDTO { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new ProductDTO { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new ProductDTO { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        // GET: api/Products
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return products;
        }

        // GET: api/Products/5
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]ProductDTO product)
        {
            try
            {
                products.Add(product);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Products/2
        public IHttpActionResult Post(int id, [FromBody]ProductDTO product)
        {
            try
            {
                products.Where(w => w.Id == id)
                  .Select(s => {
                      s.Name = product.Name;
                      s.Category = product.Category;
                      s.Price = product.Price;
                      return s;
                  }).ToList();

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]ProductDTO product)
        {
            try
            {
                products.Where(w => w.Id == id)
                  .Select(s => {
                      s.Name = product.Name;
                      s.Category = product.Category;
                      s.Price = product.Price;
                      return s;
                  }).ToList();
                
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Products/5
        public IHttpActionResult Delete(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                products.RemoveAll(x => x.Id == id);
            }
            return Ok();
        }

    }
}
