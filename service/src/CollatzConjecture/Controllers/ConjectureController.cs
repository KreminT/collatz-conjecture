using CollatzConjecture.Math;
using CollatzConjecture.Math.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CollatzConjecture.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConjectureController : ControllerBase
    {
        private readonly ICollatzConjectureResolver resolver;
        private readonly IResultProcessor resultProcessor;

        public ConjectureController(ICollatzConjectureResolver resolver, IResultProcessor resultProcessor)
        {
            this.resolver = resolver;
            this.resultProcessor = resultProcessor;
        }

        [HttpPost, Route("resolve")]
        public async Task<ActionResult> Resolve([FromBody] string value)
        {
            await resolver.ResolveConjecture(value, resultProcessor);
            string fileName = Path.GetFileName(resultProcessor.GetFileName());
            Stream stream = System.IO.File.OpenRead(resultProcessor.GetFileName());

            if (stream == null)
                throw new BadHttpRequestException(value); // returns a NotFoundResult with Status404NotFound response.

            return File(stream, "application/octet-stream", fileName); // returns a FileStreamR
        }

        [HttpGet, Route("result")]
        public async Task<ActionResult> Result([FromQuery] string value)
        {
            string fileName = Path.GetFileName(value);
            Stream stream = System.IO.File.OpenRead(value);

            if (stream == null)
                throw new BadHttpRequestException(value); // returns a NotFoundResult with Status404NotFound response.

            return File(stream, "application/octet-stream", fileName); // returns a FileStreamR
        }


        [HttpGet, Route("random")]
        public string RandomIntager([FromQuery] int count)
        {
            string value = string.Empty;
            for (int i = 0; i < count; i++)
            {
                Random random = new Random();
                value += random.Next(0, 9);
            }
            return value;
        }
    }
}
