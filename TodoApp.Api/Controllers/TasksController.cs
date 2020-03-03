using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;
        private readonly IMapper _mapper;

        public TasksController(ITasksService tasksService, IMapper mapper)
        {
            _tasksService = tasksService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<TaskOutputModel>> Get()
        {
            var tasks = await _tasksService.Get();
            return _mapper.Map<IEnumerable<TaskOutputModel>>(tasks);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<TaskOutputModel> Create([FromBody] TaskInputModel task)
        {
            return _mapper.Map<TaskOutputModel>(await _tasksService.CreateTask(_mapper.Map<TaskDto>(task)));
        }
    }
}