using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using revingpos_api.Models;
using revingpos_api.app;
namespace revingpos_api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly RevingposContext _context;
        private readonly IProductsRepository _productsRepository;
        public ProductsController(RevingposContext context, IProductsRepository productsRepository)
        {
            _context = context;
            _productsRepository = productsRepository;

        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            
          //Metodo join reduntante  
            // var result = await _context.Products.Join(_context.Brands, product => product.BrandsId,
            //     brand => brand.Id, (product, brand) => new {product, brand}
            // ).ToListAsync();
          
            //Metodo join sin redundancia, posiblemente tenga dificultal cuando la consulta sea mas compleja
            var result2 = await _context.Products
            .Include("Brands")
            .ToListAsync();

            return Ok(result2);
        }
        // GET: api/Todo/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Products>> GetProducts(long id)
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return product;
            }


        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Products>> CreateProduct(Products item)
        {
            
            try
            {
                Products newProduct = await _productsRepository.Create(item);
                return Ok(newProduct);
            }
            catch (System.Exception E)
            {    
                throw E;
            }
            
           
        }
    }
}