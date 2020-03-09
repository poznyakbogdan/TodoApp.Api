using System.Collections.Generic;

namespace TodoApp.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
    }
}