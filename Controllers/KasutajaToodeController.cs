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

        public KasutajaToodeController(KTDbContext context)
        {
            _context = context;
        }

        [HttpGet("{kasutajaId}")]
        public async Task<IActionResult> GetCart(int kasutajaId)
        {
            var cartItems = await _context.KasutajaToode
                .Where(ci => ci.KasutajaId == kasutajaId)
                .Include(ci => ci.Toode)
                .ToListAsync();

            if (cartItems.Count == 0)
                return NotFound($"Kasutajal ID {kasutajaId} on tühi ostukorv.");

            return Ok(cartItems.Select(ci => new
            {
                ProductId = ci.Toode.Id,
                ProductName = ci.Toode.Name,
                Quantity = ci.Kokku,
                TotalPrice = ci.Kokku * ci.Toode.Price
            }));
        }

        [HttpPost("{kasutajaId}/add")]
        public async Task<IActionResult> AddToCart(int kasutajaId, [FromBody] int toodeId)
        {
            var kasutaja = await _context.Kasutajad.Include(k => k.KasutajaToode).FirstOrDefaultAsync(k => k.Id == kasutajaId);
            var toode = await _context.Tooded.FindAsync(toodeId);
            if (kasutaja == null || toode == null)
                return NotFound("Kasutajat või toodet ei leitud.");

            var existingItem = kasutaja.KasutajaToode.FirstOrDefault(ci => ci.ToodeId == toodeId);
            if (existingItem != null)
            {
                existingItem.Kokku += 1;
            }
            else
            {
                var cartItem = new KasutajaToode
                {
                    KasutajaId = kasutajaId,
                    ToodeId = toodeId,
                };
                _context.KasutajaToode.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return Ok("Toode lisatud ostukorvi.");
        }

        [HttpDelete("{kasutajaId}/remove")]
        public async Task<IActionResult> RemoveFromCart(int kasutajaId, [FromBody] int toodeId)
        {
            var cartItem = await _context.KasutajaToode.FirstOrDefaultAsync(ci => ci.KasutajaId == kasutajaId && ci.ToodeId == toodeId);
            if (cartItem == null)
                return NotFound("Toodet ei leitud ostukorvis.");

            _context.KasutajaToode.Remove(cartItem);
            await _context.SaveChangesAsync();
            return Ok("Toode eemaldati ostukorvist.");
        }
    }
}
