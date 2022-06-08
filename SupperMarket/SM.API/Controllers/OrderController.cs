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
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetById(id);

            if (order == null) return NotFound();

            var mappedOrder = _mapper.Map<OrderViewModel>(order);

            return Ok(mappedOrder);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListOrders()
        {
            var orders = await _orderService.ListAsync();

            if (orders is null) return NotFound();

            var mappedOrders = _mapper.Map<IEnumerable<OrderViewModel>>(orders);

            return Ok(new QueryResult<OrderViewModel>(mappedOrders, mappedOrders.Count()));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPageOrders([FromBody] QueryObjectParams queryObject)
        {
            var queryResult = await _orderService.ListQueryAsync(queryObject);

            if (queryResult is null) return NotFound();

            var mappedOrders = _mapper.Map<IEnumerable<OrderViewModel>>(queryResult.Entities);

            return Ok(new QueryResult<OrderViewModel>(mappedOrders, queryResult.TotalCount));
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderSaveRequestViewModel orderResource)
        {
            var order = _mapper.Map<OrderSaveRequestViewModel, Order>(orderResource);

            await _orderService.SaveAsync(order);

            return Ok(new Response { Status = "Success", Message = "Order created successfully!" });
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var order = await _orderService.GetById(id);

            if (order is null) return NotFound();

            await _orderService.Delete(id);

            return Ok(new Response { Status = "Success", Message = "Order deleted successfully!" });
        }
    }
}
