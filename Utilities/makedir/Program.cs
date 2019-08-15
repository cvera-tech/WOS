using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makedir
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("USAGE: makedir <directory name>");
            }
            else
            {
                string directoryName = args[0];
                if (Directory.Exists(directoryName))
                {
                    Console.Error.WriteLine("makedir: docs: Directory exists");
                }
                else
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
