using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Services.Interfaces {
    public interface ICategoryService {
        Task<IEnumerable<Category>> ListCategoryAsync();
    }
}