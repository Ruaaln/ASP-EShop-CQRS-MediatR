using EShop.Application.DTOS;
using EShop.Application.DTOS.Category;
using EShop.Application.DTOS.Product;

namespace EShop.Application.Services.Abstracts;

public interface ICategoryService
{

    Task<IEnumerable<AllCategoryDTO>> GetAllAsync(PaginationDTO model);
    Task<bool> AddAsync(AddCategoryDto model);
    Task<bool> DeleteAsync(int id);
    Task<AllCategoryDTO> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, UpdateCategotyDTO model);
    Task<List<AllCategoryDTO>> GetProductsByCategoryId(int categoryId);
}
