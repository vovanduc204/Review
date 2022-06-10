using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.API.Errors;
using SM.API.ViewModels.Category;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Entities;
using SM.DomainLayer.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetListCategory()
        {
            var categories = await _categoryService.ListAsync();
            if (categories == null) return NotFound();

            var mappedCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return Ok(mappedCategories);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryViewModel), 200)]
        public IActionResult CreateCategory([FromBody] CategoryViewModel resource)
        {
            var category = _mapper.Map<CategoryViewModel, Category>(resource);
            var result =  _categoryService.SaveCategoryAsync(category);

            if (result == null) return NotFound(new ApiResponse(404));
            else return Ok(new Response { Status = "Success", Message = "Category created successfully!" });
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CreateCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<CreateCategoryViewModel, Category>(categoryViewModel);
            var result = await _categoryService.UpdateCategoryAsync(id, category);
            if (result == null) return NotFound(new ApiResponse(404));
            else return Ok(new Response { Status = "Success", Message = "Category update successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok(new Response { Status = "Success", Message = "Category deleted successfully!" });
        }
    }
}
