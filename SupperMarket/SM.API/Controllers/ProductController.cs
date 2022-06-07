using AutoMapper;
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
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.ListAsync();
            if (products == null) return NotFound();

            var mappedProducts = _mapper.Map<IEnumerable<ProductViewModel>>(products);

            return Ok(new QueryResult<ProductViewModel>(mappedProducts, mappedProducts.Count()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] CreateProductViewModel createProductViewModel)
        {
            try
            {
                var product = _mapper.Map<CreateProductViewModel, Product>(createProductViewModel);
                var result = await _productService.SaveAsync(product);
                return Ok(new Response { Status = "Success", Message = "Product created successfully!" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Ok(new CreateProductViewModel());
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                return Ok(_mapper.Map<ProductViewModel>(_productService.GetById(id)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Ok(new ProductViewModel());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateProductViewModel createProductViewModel)
        {
            var product = _mapper.Map<CreateProductViewModel, Product>(createProductViewModel);
            await _productService.UpdateAsync(id, product);
            return Ok(new Response { Status = "Success", Message = "Product updated successfully!" });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok(new Response { Status = "Success", Message = "Product deleted successfully!" });
        }
    }
}
