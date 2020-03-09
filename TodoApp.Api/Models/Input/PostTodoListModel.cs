using System.Collections.Generic;

namespace TodoApp.Api.Models.Input
{
    public class PostTodoListModel
    {
        public string Name { get; set; }
        public IEnumerable<int> TasksId { get; set; }
    }
}