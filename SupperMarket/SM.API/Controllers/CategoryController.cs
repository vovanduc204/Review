using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.API.ViewModels;
using SM.DomainLayer.Comunication.Response;
using SM.DomainLayer.Core.SharedKernel.Models;
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
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.ListAsync();
            if (categories == null) return NotFound();

            var mappedCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return Ok(mappedCategories);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryViewModel), 200)]
        public async Task<IActionResult> PostAsync([FromBody] CategoryViewModel resource)
        {
            var category = _mapper.Map<CategoryViewModel, Category>(resource);
            var result = await _categoryService.SaveAsync(category.Name);
            return Ok(new Response { Status = "Success", Message = "Category created successfully!" });
        }
    }
}
