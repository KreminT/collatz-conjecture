using System.Text;
using CollatzConjecture.Math.IO.Args;

namespace CollatzConjecture.Math.IO
{
    public class FileResultProcessor : IFileResultProcessor
    {
        private string _fileName;
        public FileResultProcessor()
        {
            if (!Directory.Exists("result"))
                Directory.CreateDirectory("result");
            _fileName = Path.Combine("result", Guid.NewGuid() + ".txt");
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public async Task<Stream> GetStream(IFileResultProcessingArgs args)
        {
            MemoryStream memoryStream = new MemoryStream();
            await using Stream stream = File.Open(_fileName, FileMode.Open);
            using StreamReader reader = new StreamReader(stream);
            int index = 0;
            bool readFullFile = args.StartInterval is > 0 || args.EndInterval is > 0;
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                bool writeLine = !string.IsNullOrEmpty(line) && (readFullFile || (index >= (args.StartInterval ?? -1) &&
                                                                               (index <= (args.EndInterval ?? index + 1) || args.EndInterval == 0)));
                if (writeLine)
                {
                    await memoryStream.WriteAsync(Encoding.UTF8.GetBytes(line));
                    await memoryStream.WriteAsync(Encoding.UTF8.GetBytes(Environment.NewLine));
                    if (args.AddEmptyLine)
                        await memoryStream.WriteAsync(Encoding.UTF8.GetBytes(Environment.NewLine));
                }
                index++;
            }

            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task Write(string result)
        {
            using (StreamWriter sw = File.AppendText(_fileName))
            {
                await sw.WriteLineAsync(result);
            }
        }

        public async Task<IEnumerable<string>> GetResults(IResultProcessingArgs args)
        {
            return (await File.ReadAllLinesAsync(_fileName)).GetBetween(args.StartInterval, args.EndInterval);
        }
    }
}
