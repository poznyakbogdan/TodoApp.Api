using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra.Interfaces
{
    public interface ITasksRepository
    {
        Task<TaskDto> GetById(int id);
        Task<IEnumerable<TaskDto>> Get();
        Task<int> Create(TaskDto taskDto);
        Task Update(int id, TaskDto taskDto);
        Task UpdateMany(IEnumerable<TaskDto> tasksDtos);
        Task Remove(int id);
    }
}