using AutoMapper;
using TodoApp.Api.Models;
using TodoApp.Infra.Dto;

namespace TodoApp.Api.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDto, TaskOutputModel>();
            CreateMap<TaskInputModel, TaskDto>();
        }
    }
}