using System;

namespace TodoApp.Infra.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CategoryId { get; set; }
    }
}