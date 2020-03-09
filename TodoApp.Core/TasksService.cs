using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<TaskDto> Update(int id, TaskDto taskDto)
        {
            await _tasksRepository.Update(id, taskDto);
            return await GetById(id);
        }

        public async Task UpdateMany(IEnumerable<TaskDto> tasksDtos)
        {
            await _tasksRepository.UpdateMany(tasksDtos);
        }

        public async Task Remove(int id)
        {
            await _tasksRepository.Remove(id);
        }
    }
}