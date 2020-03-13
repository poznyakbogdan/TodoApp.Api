using TodoApp.Infra;

namespace TodoApp.Api.Models.Input
{
    public class PostTaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus? Status { get; set; }
        public int? CategoryId { get; set; }
    }
}