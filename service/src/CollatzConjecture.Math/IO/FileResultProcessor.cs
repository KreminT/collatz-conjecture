namespace CollatzConjecture.Math.IO
{
    public class FileResultProcessor : IFileResultProcessor
    {
        private string _fileName;
        public FileResultProcessor()
        {
            if (!Directory.Exists("result"))
                Directory.CreateDirectory("result");
            _fileName = Path.Combine("result", Guid.NewGuid().ToString() + ".txt");
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public async Task Write(string result)
        {
            using (StreamWriter sw = File.AppendText(_fileName))
            {
                await sw.WriteLineAsync(result);
            }
        }

        public async Task<IEnumerable<string>> GetResults()
        {
            return await File.ReadAllLinesAsync(_fileName);
        }
    }
}
