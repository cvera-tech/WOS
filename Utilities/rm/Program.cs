using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rm
{
    class Program
    {
        static void Main(string[] args)
        {
            bool recursiveFlag = false;
            string fileName = String.Empty;
            if ((args.Length < 1 || args.Length > 2) || (args.Length == 1 && args[0] == "-r"))
            {
                Console.Error.WriteLine("USAGE: rm [-r] <path>");
            }
            else
            {
                if (args.Length == 1)
                {
                    fileName = args[0];
                }
                else if (args[0] == "-r")
                {
                    fileName = args[1];
                    recursiveFlag = true;
                }
                DeleteFile(fileName, recursiveFlag);
            }
#if DEBUG
            Console.ReadKey();
#endif
        }

        static void DeleteFile(string fileName, bool recursiveFlag)
        {
            bool isDirectory = Directory.Exists(fileName);
            bool fileExists = File.Exists(fileName);
            if (recursiveFlag)
            {
                if (!fileExists && !isDirectory)
                {
                    Console.Error.WriteLine($"rm: {fileName}: file or directory does not exist");
                }
                else if (isDirectory)
                {
                    Directory.Delete(fileName, true);
                }
                else if (fileExists)
                {
                    File.Delete(fileName);
                }
            }
            else
            {
                if (isDirectory)
                {
                    Console.Error.WriteLine($"rm: {fileName}: is a directory");
                }
                else if (!fileExists)
                {
                    Console.Error.WriteLine($"rm: {fileName}: file does not exist");
                }
                else
                {
                    File.Delete(fileName);
                }
            }
        }
    }
}
