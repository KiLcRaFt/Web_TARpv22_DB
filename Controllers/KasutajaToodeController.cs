using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_TARpv22.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web_TARpv22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasutajaToodeController : ControllerBase
    {
        private readonly KTDbContext _context;

        public KasutajaToodeController(KTDbContext context) // Ensure your specific DbContext class name
        {
            _context = context;
        }

        [HttpPost("{kasutajaId}/add")]
        public async Task<IActionResult> AddToCart(int kasutajaId, [FromBody] int toodeId)
        {
            // Ensure the user and product exist
            var kasutaja = await _context.Kasutajad.Include(k => k.KasutajaToode).FirstOrDefaultAsync(k => k.Id == kasutajaId);
            var toode = await _context.Tooded.FindAsync(toodeId);
            if (kasutaja == null || toode == null)
                return NotFound("User or product not found.");

            // Check if the product is already in the cart
            var existingItem = kasutaja.KasutajaToode.FirstOrDefault(ci => ci.ToodeId == toodeId);
            if (existingItem != null)
            {
                // If already in cart, increase quantity or handle as needed
                existingItem.Kokku += 1;
            }
            else
            {
                // If not in cart, create a new entry
                var cartItem = new KasutajaToode
                {
                    KasutajaId = kasutajaId,
                    ToodeId = toodeId,
                };
                _context.KasutajaToode.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return Ok("Product added to cart.");
        }

        [HttpDelete("{kasutajaId}/remove")]
        public async Task<IActionResult> RemoveFromCart(int kasutajaId, [FromBody] int toodeId)
        {
            // Find the cart item for the specified user and product
            var cartItem = await _context.KasutajaToode.FirstOrDefaultAsync(ci => ci.KasutajaId == kasutajaId && ci.ToodeId == toodeId);
            if (cartItem == null)
                return NotFound("Product not found in cart.");

            _context.KasutajaToode.Remove(cartItem);
            await _context.SaveChangesAsync();
            return Ok("Product removed from cart.");
        }

        [HttpGet("{kasutajaId}")]
        public async Task<IActionResult> GetCart(int kasutajaId)
        {
            // Get all items in the user's cart
            var cartItems = await _context.KasutajaToode
                .Where(ci => ci.KasutajaId == kasutajaId)
                .Include(ci => ci.Toode) // Include the product details
                .ToListAsync();

            if (cartItems.Count == 0)
                return NotFound("Cart is empty.");

            return Ok(cartItems.Select(ci => new
            {
                ProductId = ci.Toode.Id,
                ProductName = ci.Toode.Name,
                Quantity = ci.Kokku,
                TotalPrice = ci.Kokku * ci.Toode.Price
            }));
        }
    }
}
