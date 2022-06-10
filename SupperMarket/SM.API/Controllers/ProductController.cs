using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.API.Errors;
using SM.API.ViewModels;
using SM.API.ViewModels.Product;
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
        public async Task<IActionResult> GetListProducts()
        {
            var products = await _productService.ListProductsAsync();
            if (products == null) return NotFound(new ApiResponse(404));
            var mappedProducts = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return Ok(new QueryResult<ProductViewModel>(mappedProducts, mappedProducts.Count()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CreateProductViewModel), StatusCodes.Status200OK)]
        public IActionResult CreateProduct([FromBody] CreateProductViewModel createProductViewModel)
        {
            try
            {
                var product = _mapper.Map<CreateProductViewModel, Product>(createProductViewModel);
                var result =  _productService.SaveProductAsync(product);
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
        public IActionResult GetProductById([FromRoute] int id)
        {
            try
            {
                return Ok(_mapper.Map<ProductViewModel>(_productService.GetProductById(id)));
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
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateProductViewModel createProductViewModel)
        {
            try
            {
                var product = _mapper.Map<CreateProductViewModel, Product>(createProductViewModel);
                var productExisting = _productService.GetProductById(id);
                if (productExisting == null) return NotFound(new ApiResponse(404));
                else await _productService.UpdateProductAsync(id, product);
                return Ok(new Response { Status = "Success", Message = "Product updated successfully!" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Ok(new CreateProductViewModel());
            }
           
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var productExisting = _productService.GetProductById(id);
                if (productExisting == null) return NotFound(new ApiResponse(404));
                else await _productService.DeleteProduct(id);
                return Ok(new Response { Status = "Success", Message = "Product deleted successfully!" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return Ok(new ProductViewModel());
            }
           
        }

    }
}
