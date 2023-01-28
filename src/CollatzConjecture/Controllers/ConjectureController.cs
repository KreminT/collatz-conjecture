using CollatzConjecture.Math;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollatzConjecture.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConjectureController : ControllerBase
    {
        private readonly ICollatzConjectureResolver resolver;

        public ConjectureController(ICollatzConjectureResolver resolver)
        {
            this.resolver = resolver;
        }

        [HttpPost,Route("resolve")]
        public List<string> Resolve([FromBody]string value)
        {
            return resolver.ResolveConjecture(value);
        }


        [HttpGet, Route("random")]
        public string RandomIntager([FromQuery] int count)
        {
            string value = string.Empty;
            for(int i = 0; i < count; i++)
            {
                Random random = new Random();
                value+=random.Next(0,9);
            }
            return value;
        }
    }
}
