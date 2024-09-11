﻿using Kashkha.BL.DTOs.CartDTOs;
using Kashkha.BL.Managers.CartManager;
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kashkha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
         private readonly ICartManager _cartManager;

        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDTO>> GetCart(string userId)
        {
            var cart = await _cartManager.GetCartAsync(userId);
            return cart != null ? Ok(cart) : NotFound();
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<CartDTO>> AddToCart(string userId, AddToCartDTO addToCartDto)
        {
            var updatedCart = await _cartManager.AddToCartAsync(userId, addToCartDto);
            return Ok(updatedCart);
        }

        [HttpPut("{userId}/items/{productId}")]
        public async Task<ActionResult<CartDTO>> UpdateCartItemQuantity(string userId, int productId, [FromBody] int quantity)
        {
            var updatedCart = await _cartManager.UpdateCartItemQuantityAsync(userId, productId, quantity);
            return Ok(updatedCart);
        }

        [HttpDelete("{userId}/items/{productId}")]
        public async Task<ActionResult<CartDTO>> RemoveFromCart(string userId, int productId)
        {
            var updatedCart = await _cartManager.RemoveFromCartAsync(userId, productId);
            return Ok(updatedCart);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            await _cartManager.ClearCartAsync(userId);
            return NoContent();
        }
    }
}
