using ECommerce.Core.DTO;
using ECommerce.Core.Entities;
using ECommerce.Core.Repository;
using ECommerce.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infra.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<ProductDto>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(p => new ProductDto
            {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryId = p.CategoryId

    }
            );
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            return p == null ? null : new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryId = p.CategoryId
            };
        }
        public async Task<int> AddAsync(ProductDto dto)
        {
            var p = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
            await _repo.AddAsync(p);
            return p.Id;
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return false;

            p.Name = dto.Name;
            p.Description = dto.Description;
            p.Price = dto.Price;
            p.CategoryId = dto.CategoryId;

            return await _repo.UpdateAsync(p);
        }

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);


    }
}
