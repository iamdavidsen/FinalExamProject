using System.Collections.Generic;
using System.Threading.Tasks;
using KDBS.Data;

namespace KDBS.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetCategories();

        Task<CategoryModel> GetCategory(string categoryId);

        Task CreateCategory(CategoryModel categoryModel);

        Task EditCategory(CategoryModel categoryModel);

        Task DeleteCategory(string categoryId);
    }

}
