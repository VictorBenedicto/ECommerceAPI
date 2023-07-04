using ECommerceAPI.Commands;
using ECommerceAPI.DTOs;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/cartItem")]
    [ApiController]
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
        public IActionResult Put(Guid CartItemId, [FromBody] DTOUpdateCartItem upCartItem)
        {
            try
            {
                var change = _cartItemRepository.Put(CartItemId, upCartItem);
                return Ok(change);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid CartItemId)
        {
            try
            {
                _cartItemRepository.Delete(CartItemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
