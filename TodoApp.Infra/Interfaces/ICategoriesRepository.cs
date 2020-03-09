using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<CategoryDto> GetById(int id);
        Task<IEnumerable<CategoryDto>> Get();
        Task<int> Create(CategoryDto categoryDto);
        // Task Update(int id, TaskDto taskDto);
        // Task Remove(int id);
    }
}