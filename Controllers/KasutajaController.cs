using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_TARpv22.Models;

namespace Web_TARpv22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private static Kasutaja _kasutaja = new Kasutaja(1, "TestUser", "qwerty123", "Test", "Test");

        // GET: toode
        [HttpGet]
        public Kasutaja GetKasutaja()
        {
            return _kasutaja;
        }

    }
}
