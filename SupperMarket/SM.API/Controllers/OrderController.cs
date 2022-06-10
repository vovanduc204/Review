using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM.API.Errors;
using SM.API.ViewModels.Address;
using SM.API.ViewModels.Order;
using SM.DomainLayer.Core.Extensions;
using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Entities.OrderAggregate;
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
        public async Task<ActionResult<OrderReturnViewModel>> GetOrderByIdForUser(int id)
        {
            var email = User.RetrieveEmailFromPrincipal();
            var order = await _orderService.GetOrderByIdAsync(id, email);
            if (order == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<OrderReturnViewModel>(order);
        }

        [HttpGet("GetListOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListOrders()
        {
            var listOrders = await _orderService.ListOrdersAsync();
            if (listOrders == null) return NotFound(new ApiResponse(404));
            var resultOrders = _mapper.Map<IEnumerable<OrderReturnViewModel>>(listOrders);
            return Ok(resultOrders);
        }

        [HttpGet("GetOrdersForUser")]
        public async Task<ActionResult<IReadOnlyList<OrderReturnViewModel>>> GetOrdersForUser()
        {
            var email = User.RetrieveEmailFromPrincipal();
            var orders = await _orderService.GetOrdersForUserAsync(email);
            if (orders == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<IReadOnlyList<OrderReturnViewModel>>(orders));
        }

        [HttpPost]
        [Route("CreateOrderByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrderByUser(OrderViewModel orderViewModel)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var address = _mapper.Map<AddressViewModel, Address>(orderViewModel.ShipToAddress);
            var order = await _orderService.CreateOrderAsync(email, orderViewModel.DeliveryMethodId, orderViewModel.BasketId, address);
            if (order == null) return BadRequest(new ApiResponse(400, "Problem when creating order"));
            return Ok(order);
        }

    }
}
