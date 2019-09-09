using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using revingpos_api.Models;

namespace revingpos_api.app
{
    public interface IProductsRepository
    {
        Products GetProduct(long id);
        IEnumerable<Products> GetAllProducts();
        Task<Products> Create(Products product);
        Products Update(Products productChanges);
        Products Delete(long id);

    }




}