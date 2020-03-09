using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IMapper _mapper;
        
        public CategoriesRepository(ApplicationContext applicationContext, IMapper mapper)
        {
            _applicationContext = applicationContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var listModel = await _applicationContext.Categories.Where(x => x.Id == id).Include(x => x.Tasks).SingleAsync();
            return _mapper.Map<CategoryDto>(listModel);
        }

        public async Task<IEnumerable<CategoryDto>> Get()
        {
            var listModels = await _applicationContext.Categories.Include(x => x.Tasks).ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(listModels);
        }
 
        public async Task<int> Create(CategoryDto categoryDto)
        {
            var listModel = new Category
            {
                Name = categoryDto.Name
            };
            var createdList = await _applicationContext.AddAsync(listModel);
            await _applicationContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(createdList.Entity).Id;
        }
    }
}