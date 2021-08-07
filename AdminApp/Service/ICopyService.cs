using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Service
{
    interface ICopyService
    {
        string CreateNewFile(string oldPath, string folderName, string fileName);
    }
}
