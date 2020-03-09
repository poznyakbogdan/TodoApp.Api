using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra.Interfaces
{
    public interface ITodoListService
    {
        Task<TodoListDto> Create(string name, IEnumerable<int> tasksId);
        Task<TodoListDto> GetById(int id);
        Task<TodoListDto> GetAll();
    }
}