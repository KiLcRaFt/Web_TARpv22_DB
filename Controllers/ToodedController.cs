using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Web_TARpv22.Models;

namespace Web_TARpv22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToodedController : ControllerBase
    {
        private static List<Toode> _tooded = new()
        {
        new Toode(1,"Koola", 1.5, true),
        new Toode(2,"Fanta", 1.0, false),
        new Toode(3,"Sprite", 1.7, true),
        new Toode(4,"Vichy", 2.0, true),
        new Toode(5,"Vitamin well", 2.5, true)
        };



        //GET - получение данных

        //PUT - замена данных

        //POST - добавить данные

        //PATCH - изменение свойства

        //DELETE - удалить


        // GET :/tooded
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooded;
        }

        // DELETE :/tooded/kustuta/0
        [HttpDelete("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooded.RemoveAt(index);
            return _tooded;
        }

        [HttpDelete("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooded.RemoveAt(index);
            return "Kustutatud!";
        }

        // POST :/tooted/lisa
        [HttpPost("lisa")]
        public List<Toode> Add([FromBody] Toode toode)
        {
            _tooded.Add(toode);
            return _tooded;
        }

        [HttpPost("lisa2")] // POST :/tooded/lisa2?id=1&nimi=Koola&hind=1.5&aktiivne=true
        public List<Toode> Add2([FromQuery] int id, [FromQuery] string nimi, [FromQuery] double hind, [FromQuery] bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooded.Add(toode);
            return _tooded;
        }

        [HttpPatch("hind-dollaritesse/{kurss}")] // PATCH :/tooded/hind-dollaritesse/1.5
        public List<Toode> Dollaritesse(double kurss)
        {
            for (int i = 0; i < _tooded.Count; i++)
            {
                _tooded[i].Price = _tooded[i].Price * kurss;
            }
            return _tooded;
        }

        // või foreachina:

        [HttpPatch("hind-dollaritesse2/{kurss}")] // PATCH :/tooded/hind-dollaritesse2/1.5
        public List<Toode> Dollaritesse2(double kurss)
        {
            foreach (var t in _tooded)
            {
                t.Price = t.Price * kurss;
            }

            return _tooded;
        }

        // Iseseisev töö -------------------------------------

        // DELETE :/tooded/kustuta_all
        [HttpDelete("kustuta_all")]
        public string Delete_all()
        {
            _tooded.Clear();
            return "Kõik on kustutatud.";
        }
        
        // PUT :/tooded/false_all
        [HttpPut("false_all")]
        public List<Toode> false_all()
        {
            foreach(var t in _tooded)
            {
                t.IsActive = false;
            }
            return _tooded;
        }

        // GET :/tooded/getOne/1
        [HttpGet("getOne/{id}")]
        public Toode GetOne(int id)
        {
            if (id <= _tooded.Count() && id > 0)
            {
                return _tooded[id - 1];
            }
            else
            {
                return null;
            }
        }

        // GET :/tooded/kallim
        [HttpGet("kallim")]
        public string kallim()
        {
            var maxPrice = _tooded.Max(t => t.Price);
            return $"{maxPrice}";
        }
    }
}
