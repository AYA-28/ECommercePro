using ECommerce.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.Repository;
using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<List<Product>> GetAllAsync()=> await _context.Prpducts.ToListAsync();
        public async Task<Product?> GetByIdAsync(int id) => await _context.Prpducts.FindAsync(id);
        public async Task AddAsync(Product p)
        {
            await _context.Prpducts.AddAsync(p);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Product p)
        {
            _context.Prpducts.Update(p);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var p = await _context.Prpducts.FindAsync(id);
            if (p == null) return false;
            _context.Prpducts.Remove(p);
            return await _context.SaveChangesAsync() > 0;

        }

    }
}
 