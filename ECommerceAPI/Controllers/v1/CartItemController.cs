﻿using ECommerceAPI.Commands;
using ECommerceAPI.DTOs;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/cartItem")]
    [ApiVersion("1.0")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMediator _mediator;

        public CartItemController(ICartItemRepository cartItemRepository, IMediator mediator)
        {
            _cartItemRepository = cartItemRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCartItems()
        {
            var cartitems = await _mediator.Send(new GetCartItemsQuery());
            return Ok(cartitems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddCartItem([FromBody] DTOAddCartItem cartItem)
        {
            try
            {
                await _mediator.Send(new AddCartItemCommand(cartItem));
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid CartItemId, [FromBody] DTOUpdateCartItem upCartItem)
        {
            try
            {
                await _mediator.Send(new ChangeCartItemCommand(CartItemId, upCartItem));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid CartItemId)
        {
            try
            {
                await _mediator.Send(new DeleteCartItemCommand(CartItemId));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
