using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models.Input;
using TodoApp.Api.Models.Output;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryOutputModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<CategoryOutputModel> Create([FromBody] PostCategoryModel postCategoryModel)
        {
            var list = await _categoriesService.Create(postCategoryModel.Name);
            return _mapper.Map<CategoryOutputModel>(list);
        }
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CategoryOutputModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<CategoryOutputModel> GetById([FromRoute] int id)
        {
            var list = await _categoriesService.GetById(id);
            return _mapper.Map<CategoryOutputModel>(list);
        }
        
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(CategoryOutputModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<CategoryOutputModel> Update([FromRoute] int id, [FromBody] PostCategoryModel categoryModel)
        {
            var list = await _categoriesService.Update(id, categoryModel.Name);
            return _mapper.Map<CategoryOutputModel>(list);
        }
        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _categoriesService.Remove(id);
            return NoContent();
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryOutputModel>), 200)]
        [ProducesResponseType(500)]
        public async Task<IEnumerable<CategoryOutputModel>> GetAll()
        {
            var lists = await _categoriesService.GetAll();
            return _mapper.Map<IEnumerable<CategoryOutputModel>>(lists);
        }
    }
}