using AutoMapper;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;

namespace TodoApp.Core.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}