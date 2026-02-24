using EShop.Application.DTOS;
using EShop.Application.DTOS.Category;
using EShop.Application.Repositories;
using EShop.Application.Services.Abstracts;
using EShop.Domain.Entities.Concretes;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using System.Net.WebSockets;

namespace EShop.Persistence.Services.Concretes;

public class CategoryServuce : ICategoryService
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
        var newCategory = new Category()
        {
            Name = model.Name,
            Description = model.Description
        };

        await _categoryWriteRepository.AddAsync(newCategory);
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

    public async Task<IEnumerable<AllCategoryDTO>> GetAllAsync(PaginationDTO model)
    {
        var categoryes = await _categoryReadRepository.GetAllAsync();

        var categoryWithPagionation = categoryes
                                        .Skip(model.Page * model.PageSize)
                                        .Take(model.PageSize)
                                        .ToList();
        var allCategory = categoryWithPagionation
                            .Select(x => new AllCategoryDTO()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Description = x.Description,
                            });

        return allCategory;


    }

    public async Task<AllCategoryDTO> GetByIdAsync(int id)
    {
        var category = await _categoryReadRepository.GetByIdAsync(id);

        if (category is null)
           return null;

        var mappedData = new AllCategoryDTO()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return mappedData;
    }

    public async Task<bool> UpdateAsync(int id, UpdateCategotyDTO model)
    {
        var category = await _categoryReadRepository.GetByIdAsync(id);

        if(category is null)
            return false;

        category.Name = model.Name;
        category.Description = model.Description;

        await _categoryWriteRepository.SaveChangeAsync();

        return true;
    }
}



