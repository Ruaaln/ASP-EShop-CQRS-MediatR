using EShop.Application.DTOS;
using EShop.Application.DTOS.Category;
using EShop.Application.Repositories;
using EShop.Domain.Entities.Concretes;
using Microsoft.Identity.Client;

namespace EShop.Persistence.Services.Concretes;

public class CategoryServuce
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public CategoryServuce(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
    }


    public async Task<bool> AddAsync(AddCategoryDto model)
    {
        var NewCategory = new Category()
        {
            Name = model.Name,
            Description = model.Description
        };


        await _categoryWriteRepository.AddAsync(NewCategory);
        await _categoryWriteRepository.SaveChangeAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _categoryReadRepository.GetByIdAsync(id);

        if (category is null) 
            return false;

        await _categoryWriteRepository.Delete(id);
        await _categoryWriteRepository.SaveChangeAsync();
        
        return true;
    }



    public async Task<IEnumerable<AllCategoryDTO>> GetAllCategory(PaginationDTO model)
    {
        var category = await _categoryReadRepository.GetAllAsync();

        var categoryWithPagionation = category
                                            .Skip(model.Page * model.PageSize)
                                            .Take(model.PageSize)
                                            .ToList();
        var allCategoryDto = categoryWithPagionation.Select(x => new AllCategoryDTO()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        });

        return allCategoryDto;
    }


    public async Task<AllCategoryDTO> GetByIdAsync(int id)
    {
        var category = await _categoryReadRepository.GetByIdAsync(id);


        if (category is null)
            return null;

        var mapperData = new AllCategoryDTO()
        {
            Id = id,
            Name = category.Name,
            Description = category.Description
        };

        return mapperData;
    }
}



