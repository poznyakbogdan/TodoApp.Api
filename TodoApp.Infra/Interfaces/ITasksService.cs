using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra.Dto;

namespace TodoApp.Infra.Interfaces
{
    public interface ITasksService
    {
        Task<TaskDto> CreateTask(TaskDto taskDto);

        Task<TaskDto> GetById(int id);

        Task<IEnumerable<TaskDto>> Get();

        Task<TaskDto> Update(int id, TaskDto taskDto);

        Task Remove(int id);
    }
}