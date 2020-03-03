using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infra;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Core
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<TaskDto> CreateTask(TaskDto taskDto)
        {
            var taskId = await _tasksRepository.Create(taskDto);
            return await GetById(taskId);
        }

        public async Task<TaskDto> GetById(int id)
        {
            return await _tasksRepository.GetById(id);
        }

        public async Task<IEnumerable<TaskDto>> Get()
        {
            return await _tasksRepository.Get();
        }
    }
}