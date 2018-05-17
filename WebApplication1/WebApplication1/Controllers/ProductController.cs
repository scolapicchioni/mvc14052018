using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class ProductController : ApiController
    {
        private static List<Product> db = new List<Product>() {
            new Product(){Id = 1, Brand = "Dell", Name = "Latitude 5570", Price=1234 },
            new Product(){Id = 2, Brand = "Dell", Name = "Latitude 5970", Price=12345 },
            new Product(){Id = 3, Brand = "Acer", Name = "Longitude 1234", Price=78945 },
            new Product(){Id = 4, Brand = "Acer", Name = "Longitude 7563", Price=98745 }
        };

        //GET /api/product
        public List<Product> GetList() {
            return db;
        }

        //GET api/product/5
        public IHttpActionResult GetProductById(int id)
        {
            Product found = db.FirstOrDefault(p => p.Id == id);
            if (found == null)
                return NotFound();
            return Ok(found);
        }

        //GET /api/brand/dell/products
        [Route("api/brand/{brand}/products")]
        public List<Product> GetProductsByBrand(string brand)
        {
            return db.Where(p=>p.Brand.ToLower().StartsWith(brand.ToLower())).ToList();
        }

        //insert
        //POST /api/product
        public IHttpActionResult Post(Product toInsert) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Add(toInsert);

            //201
            //Location /api/product/6
            return CreatedAtRoute("DefaultApi", new { id = toInsert.Id, controller="Blah" }, toInsert);
        }

        //update
        //PUT /api/product/4
        public IHttpActionResult Put(int id, Product toUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toUpdate.Id) {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //delete
        //DELETE /api/product/4
        public IHttpActionResult Delete(int id) {
            Product found = db.FirstOrDefault(p => id== p.Id);
            if (found == null)
                return NotFound();

            db.Remove(found);
            return Ok(found);
        }

    }
}
