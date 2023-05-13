using CollatzConjecture.Math;
using CollatzConjecture.Math.IO;
using CollatzConjecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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
        public async Task<ActionResult> ResolveToFile([FromBody] ResolverArgs args)
        {
            await _resolver.ResolveConjecture(args, _fileResultProcessor);
            return File(await _fileResultProcessor.GetStream(args.StartInterval, args.EndInterval), "application/octet-stream", _fileResultProcessor.GetFileName()); // returns a FileStreamR
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
        public async Task<IEnumerable<string>> Resolve([FromQuery] ResolverArgs args)
        {
            await _resolver.ResolveConjecture(args, _resultProcessor);
            return await _resultProcessor.GetResults(args.StartInterval, args.EndInterval);
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
