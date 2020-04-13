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
using OnboardInternship.Models;

namespace OnboardInternship.Controllers
{
    public class CustomerController : ApiController
    {
        private InternshipEntities db = new InternshipEntities();

        // GET: api/Customer
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        // PUT: api/Customer/5
        [ResponseType(typeof(void))]
        public string Put(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return "Update Failed";
            }
                       
            db.Entry(customer).State = EntityState.Modified;

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

        public string PostCustomer(Customer customer)
        {

            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return "Customer Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }


        }

        // DELETE: api/Customers3/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }

    }
}