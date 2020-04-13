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
using System.Web.Mvc;
using OnboardInternship;
using OnboardInternship.Models;

namespace OnboardInternship.Controllers
{
    public class SalesController : ApiController
    {
        private InternshipEntities db = new InternshipEntities();

        // GET: api/Sales
        /* public IQueryable<Sale> GetSales()
         {
             return db.Sales;
         }
         */
        public object GetSales()
        {
            var s = from S in db.Sales
                    join C in db.Customers on S.CustomerId equals C.Id
                    join P in db.Products on S.ProductId equals P.Id
                    join ST in db.Stores on S.StoreId equals ST.Id
                    select new
                    {S.Id,S.DateSold,
                        CName=C.Name,
                        PName=P.Name,
                        SName=ST.Name};

            return s;
        }

















        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public string PutSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return "Update Failed";
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return "Updated Successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                return "Update Failed";
            }

          }

        // POST: api/Sales
        [ResponseType(typeof(Sale))]
        public string PostSale(Sale sale)
        {
            try
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return "Added Successfully";
            }
            catch
            {
                return "Failed to Add";
            }
                                    
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult DeleteSale(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sale);
            db.SaveChanges();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sales.Count(e => e.Id == id) > 0;
        }
    }
}