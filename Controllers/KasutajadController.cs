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
            new Kasutaja (1, "Test1", "123123", "test1","TEST1"),
            new Kasutaja (2, "Test2", "123123", "test2", "TEST2"),
            new Kasutaja (3, "Test3", "123123", "test3", "TEST3"),
            new Kasutaja (4, "Test4", "123123", "test4", "TEST4"),
            new Kasutaja (5, "Test5", "123123", "test5", "TEST5")
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
        [HttpPost("lisa/{id}/{username}/{password}/{nimi}/{perenimi}")]
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
