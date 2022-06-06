using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.API.ViewModels;
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

        /// <summary>
        /// Lists all categories.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryViewModel>), 200)]
        public IActionResult ListAll()
        {
            try
            {
                return Ok(_mapper.Map<List<CategoryViewModel>>(_categoryService.ListAsync()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Ok(new List<CategoryViewModel>());
            }
        }

        /// <summary>
        /// Saves a new category.
        /// </summary>
        /// <param name="resource">Category data.</param>
        /// <returns>Response for the request.</returns>   
        //[Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(CategoryViewModel), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CategoryViewModel resource)
        {
            var category = _mapper.Map<CategoryViewModel, Category>(resource);
            var result = await _categoryService.SaveAsync(category.Name);
            return Ok(result);
        }
    }
}
