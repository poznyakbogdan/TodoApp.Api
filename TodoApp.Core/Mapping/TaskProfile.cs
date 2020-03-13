using AutoMapper;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;

namespace TodoApp.Core.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskModel, TaskDto>();
            CreateMap<TaskDto, TaskModel>();
        }
    }
}