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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var cat = await _repo.GetByIdAsync(id);
            if (cat == null) return null;

            return new CategoryDto
            {
                Id = cat.Id,
                Name = cat.Name
            };
        }

        public async Task<int> CreateAsync(CategoryDto dto)
        {
            var cat = new Category { Name = dto.Name };
            await _repo.AddAsync(cat);
            return cat.Id;
        }

        public async Task<bool> UpdateAsync(int id, CategoryDto dto)
        {
            var cat = await _repo.GetByIdAsync(id);
            if (cat == null) return false;

            cat.Name = dto.Name;
            return await _repo.UpdateAsync(cat);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}