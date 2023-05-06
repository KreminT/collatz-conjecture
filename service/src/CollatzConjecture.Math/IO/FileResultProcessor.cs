using System.Text;

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

        public async Task<Stream> GetStream(int? startIndex, int? endIndex)
        {
            if (startIndex is > -1 || endIndex is > 0)
            {
                MemoryStream memoryStream = new MemoryStream();
                await using Stream stream = File.Open(_fileName, FileMode.Open);
                using StreamReader reader = new StreamReader(stream);
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (index >= (startIndex ?? -1) && index <= (endIndex ?? index + 1) && !string.IsNullOrEmpty(line))
                    {
                        await memoryStream.WriteAsync(Encoding.UTF8.GetBytes(line));
                        await memoryStream.WriteAsync(Encoding.UTF8.GetBytes(Environment.NewLine));
                    }
                    index++;
                }

                memoryStream.Position = 0;
                return memoryStream;
            }
            else
                return System.IO.File.OpenRead(_fileName);
        }

        public async Task Write(string result)
        {
            using (StreamWriter sw = File.AppendText(_fileName))
            {
                await sw.WriteLineAsync(result);
            }
        }

        public async Task<IEnumerable<string>> GetResults(int? startIndex, int? endIndex)
        {
            return (await File.ReadAllLinesAsync(_fileName)).GetBetween(startIndex, endIndex);
        }
    }
}
