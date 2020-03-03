using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra
{
    public interface ITasksRepository
    {
        Task<TaskDto> GetById(int id);
        Task<IEnumerable<TaskDto>> Get();
        Task<int> Create(TaskDto taskDto);
    }
}