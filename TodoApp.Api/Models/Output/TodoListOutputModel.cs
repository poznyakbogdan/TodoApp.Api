using System.Collections.Generic;

namespace TodoApp.Api.Models.Output
{
    public class TodoListOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskOutputModel> Tasks { get; set; }
    }
}