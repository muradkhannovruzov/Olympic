using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using ServiceStack.Text;

namespace AdminApp.Service
{
    public class CsvReader<T> : IFileReader<T> where T : class
    {
        public IEnumerable<T> ReadFile(string path)
        {
            return CsvSerializer.DeserializeFromString<List<T>>(File.ReadAllText(path));
        }
    }
}
