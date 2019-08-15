﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("USAGE: touch <file name>");
            }
            else
            {
                string fileName = args[0];
                if (File.Exists(fileName))
                {
                    var fileInfo = new FileInfo(fileName);
                    fileInfo.LastWriteTime = DateTime.Now;
                }
                else
                {
                    using (File.Create(fileName)) {}
                }
            }
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
