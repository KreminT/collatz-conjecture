using CollatzConjecture.Math;
using CollatzConjecture.Math.IO;
using CollatzConjecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollatzConjecture.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConjectureController : ControllerBase
    {
        private readonly ICollatzConjectureResolver _resolver;
        private readonly IFileResultProcessor _fileResultProcessor;
        private readonly IResultProcessor _resultProcessor;

        public ConjectureController(ICollatzConjectureResolver resolver, IFileResultProcessor fileResultProcessor, IResultProcessor resultProcessor)
        {
            this._resolver = resolver;
            this._fileResultProcessor = fileResultProcessor;
            _resultProcessor = resultProcessor;
        }

        [HttpPost, Route("resolve")]
        public async Task<ActionResult> ResolveToFile([FromBody] BodyArgs args)
        {
            await _resolver.ResolveConjecture(args.Value, args.Multiplier,args.MaxIteration, _fileResultProcessor);
            string fileName = Path.GetFileName(_fileResultProcessor.GetFileName());
            Stream stream = System.IO.File.OpenRead(_fileResultProcessor.GetFileName());

            if (stream == null)
                throw new BadHttpRequestException(args.Value); // returns a NotFoundResult with Status404NotFound response.

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

        [HttpGet, Route("resolve")]
        public async Task<IEnumerable<string>> Resolve([FromQuery] string value, [FromQuery] int multiplier)
        {
            await _resolver.ResolveConjecture(value, multiplier,0, _resultProcessor);
            return await _resultProcessor.GetResults();
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
