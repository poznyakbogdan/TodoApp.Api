using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra.Interfaces
{
    public interface ICategoriesService
    {
        Task<CategoryDto> Create(string name);
        Task<CategoryDto> GetById(int id);
        Task<IEnumerable<CategoryDto>> GetAll();
    }
}