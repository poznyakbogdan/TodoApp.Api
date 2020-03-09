using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.DAL.Repositories
{
    public class TodoListsRepository : ITodoListsRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IMapper _mapper;
        
        public TodoListsRepository(ApplicationContext applicationContext, IMapper mapper)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }

        public async Task<TodoListDto> GetById(int id)
        {
            var listModel = await _applicationContext.TodoLists.SingleAsync(x => x.Id == id);
            return _mapper.Map<TodoListDto>(listModel);
        }

        public async Task<IEnumerable<TodoListDto>> Get()
        {
            var listModels = await _applicationContext.TodoLists.ToListAsync();
            return _mapper.Map<IEnumerable<TodoListDto>>(listModels);
        }
 
        public async Task<int> Create(TodoListDto todoListDto)
        {
            var listModel = new TodoList
            {
                Name = todoListDto.Name
            };
            var createdList = await _applicationContext.AddAsync(listModel);
            await _applicationContext.SaveChangesAsync();
            return _mapper.Map<TodoListDto>(createdList).Id;
        }
    }
}