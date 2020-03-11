using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Core
{
    public class TasksService : ITasksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TaskModel> _repository;
        private readonly IMapper _mapper;

        public TasksService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TaskModel>();
            _mapper = mapper;
        }
        
        public async Task<TaskDto> CreateTask(TaskDto taskDto)
        {
            var taskModel = _mapper.Map<TaskModel>(taskDto);
            taskModel.CreatedAt = DateTime.Now;
            await _repository.CreateAsync(taskModel);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<TaskDto>(taskModel);
        }

        public async Task<TaskDto> GetById(int id)
        {
            var taskModel = await _repository.GetByIdAsync(id);
            return _mapper.Map<TaskDto>(taskModel);
        }

        public async Task<IEnumerable<TaskDto>> Get()
        {
            var taskModels = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(taskModels);
        }

        public async Task<TaskDto> Update(int id, TaskDto taskDto)
        {
            var model = await _repository.GetByIdAsync(id);

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
            
            if (taskDto.CategoryId.HasValue)
            {
                var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(taskDto.CategoryId.Value);
                category.Tasks.Add(model);
            }

            await _unitOfWork.CommitAsync();
            return _mapper.Map<TaskDto>(model);
        }

        public async Task UpdateMany(IEnumerable<TaskDto> tasksDtos)
        {
            var models = await _repository.FindAsync(x => tasksDtos.Select(y => y.Id).Contains(x.Id));
            tasksDtos.ToList().ForEach(async x =>
            {
                var model = models.Single(y => y.Id == x.Id);
                
                if (!string.IsNullOrEmpty(x.Name))
                {
                    model.Name = x.Name;
                }
            
                if (!string.IsNullOrEmpty(x.Description))
                {
                    model.Description = x.Description;
                }
            
                if (x.Status.HasValue)
                {
                    model.Status = (int)x.Status.Value;
                }
            
                if (x.CategoryId.HasValue)
                {
                    var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(x.CategoryId.Value);
                    category.Tasks.Add(model);
                }
            });
            await _unitOfWork.CommitAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}