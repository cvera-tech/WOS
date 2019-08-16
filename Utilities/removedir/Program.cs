using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removedir
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("USAGE: removedir <directory name>");
            }
            else
            {
                string directoryName = args[0];
                if (!Directory.Exists(directoryName))
                {
                    if (File.Exists(directoryName))
                    {
                        Console.Error.WriteLine($"removedir: {directoryName}: not a directory");
                    }
                    else
                    {
                        Console.Error.WriteLine($"removedir: {directoryName}: directory does not exist");
                    }
                }
                else
                {
                    var directoryFiles = Directory.EnumerateFileSystemEntries(directoryName);
                    if (directoryFiles.Count() != 0)
                    {
                        Console.Error.WriteLine($"removedir: {directoryName}: directory not empty");
                    }
                    else
                    {
                        Directory.Delete(directoryName);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
