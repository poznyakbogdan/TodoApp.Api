using System.Collections.Generic;

namespace TodoApp.DAL.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskModel> Tasks { get; set; }
    }
}