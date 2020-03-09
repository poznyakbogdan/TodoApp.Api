using AutoMapper;
using TodoApp.Api.Models.Output;
using TodoApp.Infra.Dto;

namespace TodoApp.Api.Mapping
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<TodoListDto, TodoListOutputModel>();
        }
    }
}