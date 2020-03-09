using System.Collections.Generic;

namespace TodoApp.Infra.Dto
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}