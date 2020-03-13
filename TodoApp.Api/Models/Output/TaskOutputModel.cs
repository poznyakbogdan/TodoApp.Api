using System;
using TodoApp.Api.Models.Input;

namespace TodoApp.Api.Models.Output
{
    public class TaskOutputModel : PostTaskModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}