using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApp.DAL.Models;
using TodoApp.Infra;
using TodoApp.Infra.Dto;

namespace TodoApp.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public TasksRepository(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TaskDto> GetById(int id)
        {
            var task = await _context.Tasks.SingleAsync(x => x.Id == id);
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<IEnumerable<TaskDto>> Get()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<int> Create(TaskDto taskDto)
        {
            var taskModel = _mapper.Map<TaskModel>(taskDto);
            var createdTask = await _context.Tasks.AddAsync(taskModel);
            await _context.SaveChangesAsync();
            return createdTask.Entity.Id;
        }
    }
}