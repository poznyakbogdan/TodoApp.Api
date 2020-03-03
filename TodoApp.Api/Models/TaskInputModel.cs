using System.ComponentModel.DataAnnotations;
using TodoApp.Infra;

namespace TodoApp.Api.Models
{
    public class TaskInputModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Created;
    }
}