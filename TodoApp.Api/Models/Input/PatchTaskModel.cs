namespace TodoApp.Api.Models.Input
{
    public class PatchTaskModel : PutTaskModel
    {
        public int Id { get; set; }
    }
}