using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_TARpv22.Models;

namespace Web_TARpv22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }

        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = _toode.Price + 1;
            return _toode;
        }

        // Iseseisev töö ------------------------

        // GET: toode/IsActive
        [HttpGet("IsActive")]
        public Toode IsActive()
        {
            _toode.IsActive = !_toode.IsActive;
            return _toode;
        }
        
        // GET: toode/NameChange/Pepsi
        [HttpGet("NameChange/{url}")]
        public Toode NameChange(string url)
        {
            _toode.Name = url;
            return _toode;
        }
        
        // GET: toode/Multiply/2
        [HttpGet("Multiply/{url}")]
        public Toode Multiply(double url)
        {
            _toode.Price =  _toode.Price * url;
            return _toode;
        }
    }
}
