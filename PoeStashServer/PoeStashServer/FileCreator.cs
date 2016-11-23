using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeStashServer
{
    class FileCreator
    {
        public static void CreateFileAndWriteContent(string path, string content)
        {
            using (StreamWriter writetext = new StreamWriter(path))
            {
                writetext.WriteLine(content);
            }
        }
    }
}
