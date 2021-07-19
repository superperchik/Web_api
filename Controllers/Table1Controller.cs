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
using WebApp.Entity;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class Table1Controller : ApiController
    {
        private BaseTestEntities db = new BaseTestEntities();

        // GET: api/Table1
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetTable1()
        {
            return Ok(db.Table1.ToList().ConvertAll(p => new User(p)));
        }

        // GET: api/Table1/5
        [ResponseType(typeof(Table1))]
        public IHttpActionResult GetTable1(int id)
        {
            Table1 table1 = db.Table1.Find(id);
            if (table1 == null)
            {
                return NotFound();
            }

            return Ok(table1);
        }

        // PUT: api/Table1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTable1(int id, Table1 table1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table1.id)
            {
                return BadRequest();
            }

            db.Entry(table1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Table1
        [ResponseType(typeof(Table1))]
        public IHttpActionResult PostTable1(Table1 table1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table1.Add(table1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Table1Exists(table1.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = table1.id }, table1);
        }

        // DELETE: api/Table1/5
        [ResponseType(typeof(Table1))]
        public IHttpActionResult DeleteTable1(int id)
        {
            Table1 table1 = db.Table1.Find(id);
            if (table1 == null)
            {
                return NotFound();
            }

            db.Table1.Remove(table1);
            db.SaveChanges();

            return Ok(table1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table1Exists(int id)
        {
            return db.Table1.Count(e => e.id == id) > 0;
        }
    }
}