using System;
using System.Collections.Generic;
using revingpos_api.Models;
using System.Threading.Tasks;

namespace revingpos_api.app.products
{
    public class ProductsRepository : IProductsRepository
    {
         private readonly RevingposContext _context;
        public ProductsRepository(RevingposContext context){
            _context = context;
        }

        public async Task<Products> Create(Products product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
           
        }

        public Products Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Products GetProduct(long id)
        {
            throw new NotImplementedException();
        }

        public Products Update(Products productChanges)
        {
            throw new NotImplementedException();
        }
    }
}