using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TodoApp.DAL.Models;
using TodoApp.Infra;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Core
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Category>();
            _mapper = mapper;
        }
        
        public async Task<CategoryDto> Create(string name)
        {
            var category = new Category()
            {
                Name = name
            };
            await _repository.CreateAsync(category);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(model);
        }
        
        public async Task<CategoryDto> Update(int id, string name)
        {
            var model = await _repository.GetByIdAsync(id);
            model.Name = name;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CategoryDto>(model);
        }
        
        public async Task Remove(int id)
        {
            var model = await _repository.GetByIdAsync(id);
            _repository.Remove(model);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var models = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(models);
        }
    }
}