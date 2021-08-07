using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApp.Service
{
    class CopySercive : ICopyService
    {
        public string CreateNewFile(string oldPath,string folderName, string fileName)
        {
            string newPath = "";
            try
            {
                var directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent("aasas")
                   .ToString()).ToString()).ToString()).ToString()).ToString() + "\\Olympic"
                   + "\\OlympicApp\\"+"Image\\";


                if (!Directory.Exists($@"{directory}\{folderName}"))
                {
                    Directory.CreateDirectory($@"{directory}\{folderName}");
                }
                var extention = Path.GetExtension(oldPath);
                newPath = $@"{directory}\{folderName}\{fileName}{extention}";
                File.Copy(oldPath, newPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return newPath;
        }
    }
}
