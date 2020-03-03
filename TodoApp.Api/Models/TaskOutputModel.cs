using System;

namespace TodoApp.Api.Models
{
    public class TaskOutputModel : TaskInputModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}