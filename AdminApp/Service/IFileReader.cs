using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Service
{
    public interface IFileReader<T> where T : class
    {
        IEnumerable<T> ReadFile(string path);
    }
}
