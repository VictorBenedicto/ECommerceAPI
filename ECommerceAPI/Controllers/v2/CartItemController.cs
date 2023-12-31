﻿using ECommerceAPI.Commands;
using ECommerceAPI.DTOs;
using ECommerceAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/cartItem")]
    [ApiVersion("2.0")]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
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
