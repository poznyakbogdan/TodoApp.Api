using AutoMapper;
using TodoApp.Api.Models.Output;
using TodoApp.Infra.Dto;

namespace TodoApp.Api.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, CategoryOutputModel>();
            CreateMap<int?, CategoryDto>()
                .ForMember(x => x.Id, expression => expression.MapFrom(x => x));
        }
    }
}