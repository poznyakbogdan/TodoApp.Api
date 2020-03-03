using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApp.DAL.Models;
using TodoApp.Infra;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

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
            taskModel.CreatedAt = DateTime.UtcNow;
            var createdTask = await _context.Tasks.AddAsync(taskModel);
            await _context.SaveChangesAsync();
            return createdTask.Entity.Id;
        }

        public async Task Update(int id, TaskDto taskDto)
        {
            var model = await _context.Tasks.SingleAsync(x => x.Id == id);

            if (!string.IsNullOrEmpty(taskDto.Name))
            {
                model.Name = taskDto.Name;
            }
            
            if (!string.IsNullOrEmpty(taskDto.Description))
            {
                model.Description = taskDto.Description;
            }
            
            if (taskDto.Status.HasValue)
            {
                model.Status = (int)taskDto.Status.Value;
            }

            _context.Tasks.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var model = await _context.Tasks.SingleAsync(x => x.Id == id);
            _context.Tasks.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}