using Microsoft.AspNetCore.Mvc;
using EShop.Application.Repositories;
using EShop.Application.DTOS.Category;
using EShop.Domain.Entities.Concretes;
using EShop.Application.Services.Abstracts;
using Azure.Core;
using EShop.Application.DTOS;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPatch("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationDTO model) 
        => Ok(await _categoryService.GetAllAsync(model));




    [HttpPost("AddCategory")]
    public async Task<IActionResult> Add([FromBody] AddCategoryDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        var result = await _categoryService.AddAsync(model);

        if (!result)
            return BadRequest();

        return StatusCode(204);
    }



    [HttpDelete("DeletCategory")]
    public async Task<IActionResult> Delet([FromRoute] int id)
        => await _categoryService.DeleteAsync(id) ? StatusCode(2004) : BadRequest();

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _categoryService.GetByIdAsync(id);

        if (result is null)
            return BadRequest();

        return Ok(result);
    }


    [HttpPut("Update{id}")]
    public async Task<IActionResult> Updae([FromRoute] int id, [FromBody] UpdateCategotyDTO model)
    {
        var result = await _categoryService.UpdateAsync(id, model);

        if (!result)
            return BadRequest();

        return StatusCode(204);
    }

}
