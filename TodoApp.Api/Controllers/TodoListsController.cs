using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models.Input;
using TodoApp.Api.Models.Output;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListsController : ControllerBase
    {
        private readonly ITodoListService _todoListService;
        private readonly IMapper _mapper;

        public TodoListsController(ITodoListService todoListService, IMapper mapper)
        {
            _todoListService = todoListService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoListOutputModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<TodoListOutputModel> Create([FromBody] PostTodoListModel postTodoListModel)
        {
            var list = await _todoListService.Create(postTodoListModel.Name, postTodoListModel.TasksId);
            return _mapper.Map<TodoListOutputModel>(list);
        }
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TodoListOutputModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<TodoListOutputModel> GetById([FromBody] int id)
        {
            var list = await _todoListService.GetById(id);
            return _mapper.Map<TodoListOutputModel>(list);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoListOutputModel>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<TodoListOutputModel>> GetAll()
        {
            var lists = await _todoListService.GetAll();
            return _mapper.Map<IEnumerable<TodoListOutputModel>>(lists);
        }
    }
}