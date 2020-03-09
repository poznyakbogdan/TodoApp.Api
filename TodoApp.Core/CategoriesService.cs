using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Core
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<CategoryDto> Create(string name)
        {
            var listId = await _categoriesRepository.Create(new CategoryDto
            {
                Name = name,
            });
            return await GetById(listId);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            return await _categoriesRepository.GetById(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return await _categoriesRepository.Get();
        }
    }
}