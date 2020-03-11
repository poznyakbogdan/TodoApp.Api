using AutoMapper;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;

namespace TodoApp.Core.Mapping
{
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}