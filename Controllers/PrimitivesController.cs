using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace Web_TARpv22.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimitivesController : ControllerBase
    {

        // GET: primitiivid/hello-world
        [HttpGet ("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }
        
        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }
        
        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }
        
        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++) { 
            Console.WriteLine("See on logi nr " + i);
            }
        }

        // Iseseisev töö ------------------------------

        // GET: primitiivid/Between
        [HttpGet("Between")]
        public string Between()
        {
            Random rnd = new Random();
            var arv1 = rnd.Next(1, 20);
            var arv2 = rnd.Next(1, 20);

            var between = rnd.Next(Math.Min(arv1, arv2) + 1, Math.Max(arv1, arv2)) - 1;


            string ans = $"{arv1}, {arv2} = {between}";
            return ans;
        }

        // GET: primitiivid/bday/09/11/2001
        [HttpGet("bday/{day}/{month}/{year}")]
        public string Bday(int day, int month, int year)
        {
            DateTime bdayDate = new DateTime(year, month, day);
            DateTime currentDate = DateTime.Today;

            int age = currentDate.Year - bdayDate.Year;

            if (currentDate.Month < bdayDate.Month || (currentDate.Month == bdayDate.Month && currentDate.Day < bdayDate.Day))
            {
                age--;
            }

            return $"Kui sina on sündinud {bdayDate.Day}/{bdayDate.Month}/{bdayDate.Year} ja präegu on {currentDate.Day}/{currentDate.Month}/{currentDate.Year}. \nSina on {age} aastat vana.";
        }
    }
}
