﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CarsController : ApiController
    {
        private AutosContext db = new AutosContext();

        // GET: api/Cars
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        [Route("api/brand/{brandId}/cars", Name = "carsByBrand")]
        // GET: api/Cars
        public IEnumerable<Car> GetCarsByBrandId(int brandId)
        {
            return db.Cars.Where(c=>c.BrandId==brandId);
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> GetCar(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.Id)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public async Task<IHttpActionResult> DeleteCar(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            await db.SaveChangesAsync();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.Id == id) > 0;
        }
    }
}