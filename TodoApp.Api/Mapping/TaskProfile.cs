using AutoMapper;
using TodoApp.Api.Models;
using TodoApp.Api.Models.Input;
using TodoApp.Api.Models.Output;
using TodoApp.Infra.Dto;

namespace TodoApp.Api.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDto, TaskOutputModel>();
            CreateMap<PostTaskModel, TaskDto>();
        }
    }
}