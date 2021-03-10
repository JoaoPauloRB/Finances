using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Data;
using Service.Services.Interfaces;

namespace Service.Services {
    public class CategoryService : ICategoryService {
        private readonly UnitOfWork _uow;
        public CategoryService(UnitOfWork uow) {
            _uow = uow;
        }

        public async Task<IEnumerable<Category>> ListCategoryAsync()
        {
            return await _uow.CategoryRepository.GetAsync();
        }
  }
}