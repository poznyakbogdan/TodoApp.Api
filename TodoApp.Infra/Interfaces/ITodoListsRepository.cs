using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra.Interfaces
{
    public interface ITodoListsRepository
    {
        Task<TodoListDto> GetById(int id);
        Task<IEnumerable<TodoListDto>> Get();
        Task<int> Create(TodoListDto todoListDto);
//        Task Update(int id, TaskDto taskDto);
//        Task Remove(int id);
    }
}