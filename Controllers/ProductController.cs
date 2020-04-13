using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnboardInternship;

namespace OnboardInternship.Controllers
{
    public class ProductController : ApiController
    {
        private InternshipEntities db = new InternshipEntities();

        // GET: api/Product
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }



        
        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public String PutProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return "Failed to Update";
            }

           
            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return "Product Updated Successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                return "Failed to Update";
            }

            
        }

        // POST: api/Product
        [ResponseType(typeof(Product))]
        public string PostProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return "Product Added Successfully";
            }
            catch
            {
                return "Failed to Add";
            }
        }

       // DELETE: api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}