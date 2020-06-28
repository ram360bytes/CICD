using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly PracticeContext dbContext;

        public ProductsController(PracticeContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        // GET: api/Products/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<ActionResult> GetProducts(int id)
        //{
        //    var products = await dbContext.Products.FindAsync(id);

        //    if (products == null)
        //    {
        //        return NotFound();
        //    }

        //    return products;
        //}

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult> PostProducts(Products products)
        {
            dbContext.Products.Add(products);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductId)
            {
                return BadRequest();
            }

            dbContext.Entry(products).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteProducts(int id)
        //{
        //    var products = await dbContext.Products.FindAsync(id);
        //    if (products == null)
        //    {
        //        return NotFound();
        //    }

        //    dbContext.Products.Remove(products);
        //    await dbContext.SaveChangesAsync();

        //    return products;
        //}

        private bool ProductsExists(int id)
        {
            return dbContext.Products.Any(e => e.ProductId == id);
        }
    }
}
