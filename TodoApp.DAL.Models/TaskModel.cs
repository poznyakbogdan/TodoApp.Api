using System;

namespace TodoApp.DAL.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}