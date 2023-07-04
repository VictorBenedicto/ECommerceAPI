﻿using ECommerceAPI.DTOs;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        public OrderController (IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _mediator.Send(new GetOrdersQuery());
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet ("OrderID", Name = "OrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrder(Guid OrderId)
        {
            try
            {
                var orderbyid = await _mediator.Send(new GetOrderByIdQuery(OrderId));
                return Ok(orderbyid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{OrderId:Guid}")]
        public async Task<IActionResult> Put(Guid OrderId, DTOOrderUpdate uporder)
        {
            try
            {
                await _orderRepository.Put(OrderId, uporder);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{OrderId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid OrderId)
        {
            try
            {
                await _orderRepository.Delete(OrderId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
