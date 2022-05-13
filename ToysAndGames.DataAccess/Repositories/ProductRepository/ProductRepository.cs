﻿using Microsoft.EntityFrameworkCore;
using ToysAndGames.DataAccess.Data;
using ToysAndGames.Model.Interfaces;
using ToysAndGames.Model.Products;

namespace ToysAndGames.DataAccess.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}