using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<TaskOutputModel>> Get()
        {
            return new List<TaskOutputModel>();
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<TaskOutputModel> Create([FromBody] TaskInputModel task)
        {
            return new TaskOutputModel();
        }
    }
}