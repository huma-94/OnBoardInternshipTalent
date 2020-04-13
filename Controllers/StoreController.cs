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
    public class StoreController : ApiController
    {
        private InternshipEntities db = new InternshipEntities();

        // GET: api/Store
        public IQueryable<Store> GetStores()
        {
            return db.Stores;
        }

        
        // PUT: api/Store/5
        [ResponseType(typeof(void))]
        public string PutStore(Store store)
        {
            if (!ModelState.IsValid)
            {
                return "Update Failed";
            }

          db.Entry(store).State = EntityState.Modified;

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

        // POST: api/Store
        [ResponseType(typeof(Store))]
        public string PostStore(Store store)
        {
            try
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return "Store added successfully";
            }

            catch
            {
                return "Failed to add";
            }
        }

        // DELETE: api/Store/5
        [ResponseType(typeof(Store))]
        public IHttpActionResult DeleteStore(int id)
        {
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            db.Stores.Remove(store);
            db.SaveChanges();

            return Ok(store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.Id == id) > 0;
        }
    }
}