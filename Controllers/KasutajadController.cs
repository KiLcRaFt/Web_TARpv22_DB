using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Web_TARpv22.Models;

namespace Web_TARpv22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KasutajadController : Controller
    {
        private readonly KTDbContext _context;
        private readonly HttpClient _httpClient;

        public KasutajadController(HttpClient httpClient,  KTDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }
        private static List<Kasutaja> _kasutaja = new()
        {

        };

        // GET /tooted
        [HttpGet]
        public List<Kasutaja> Get()
        {
            return _kasutaja;
        }

        // DELETE /tooted/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Kasutaja> Delete(int index)
        {
            _kasutaja.RemoveAt(index);
            return _kasutaja;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _kasutaja.RemoveAt(index);
            return "Kustutatud!";
        }

        // POST /tooted/lisa/1/pepsi/1.5/true
        [HttpPost("lisa/{username}/{password}/{nimi}/{perenimi}")]
        public async Task<List<Kasutaja>> Add(int id, string username, string password, string nimi, string perenimi)
        {
            Kasutaja toode = new Kasutaja(id, username, password, nimi, perenimi);
            _kasutaja.Add(toode);
            await _context.Kasutajad.AddAsync(toode);
            await _context.SaveChangesAsync();
            return _kasutaja;
        }

    }
}
