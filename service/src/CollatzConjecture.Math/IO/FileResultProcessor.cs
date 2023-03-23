using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture.Math.IO
{
    public class FileResultProcessor : IResultProcessor
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

        public void Write(string result)
        {
            using (StreamWriter sw = File.AppendText(_fileName))
            {
                sw.WriteLine(result);
            }
        }
    }
}
