using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models.Input;
using TodoApp.Api.Models.Output;
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
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<TaskOutputModel> Get([FromRoute] int id)
        {
            var task = await _tasksService.GetById(id);
            return _mapper.Map<TaskOutputModel>(task);
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
        [ProducesResponseType(typeof(TaskOutputModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Create([FromBody] PostTaskModel postTask)
        {
            var task = _mapper.Map<TaskOutputModel>(await _tasksService.CreateTask(_mapper.Map<TaskDto>(postTask)));
            return Created(Url.Action("Get", new {task.Id}), task);
        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(TaskOutputModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<TaskOutputModel> Update([FromRoute] int id, [FromBody] PutTaskModel putTaskModel)
        {
            var task = await _tasksService.Update(id, _mapper.Map<TaskDto>(putTaskModel));
            return _mapper.Map<TaskOutputModel>(task);
        }
        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _tasksService.Remove(id);
            return NoContent();
        }
    }
}