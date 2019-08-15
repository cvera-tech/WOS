using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default
            // Long

            // Files
            // Directories

            // -l
            bool longFlag = false;
            if (args.Length > 0 && args[0] == "-l")
            {
                longFlag = true;
            }

            var filesAndDirectories = Directory.EnumerateFileSystemEntries(".");

            PrintEnumerable(filesAndDirectories, longFlag);

#if DEBUG
            Console.ReadKey();
#endif
        }

        private static void PrintEnumerable(IEnumerable<string> items, bool longFlag)
        {
            if (!longFlag)
            {
                foreach (var item in items)
                {
                    string display = item.Substring(2);

                    if (Directory.Exists(item))
                    {
                        display += "/";
                    }

                    Console.WriteLine(display);
                }
            }
            else
            {
                Console.WriteLine("SIZE\t\tCREATED\t\tMODIFIED");
                foreach (var item in items)
                {
                    string display = "";
                    string name = item.Substring(2);
                    const string dateTimeFormat = "MMM dd HH:mm";

                    if (Directory.Exists(item))
                    {
                        display += "\t\t";
                        DirectoryInfo directoryInfo = new DirectoryInfo(item);
                        display += directoryInfo.CreationTime.ToString(dateTimeFormat) + "\t";
                        display += directoryInfo.LastWriteTime.ToString(dateTimeFormat) + "\t";
                        display += name + "/";
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        display += fileInfo.Length.ToString().PadLeft(14) + "\t";
                        display += fileInfo.CreationTime.ToString(dateTimeFormat) + "\t";
                        display += fileInfo.LastWriteTime.ToString(dateTimeFormat) + "\t";
                        display += name;
                    }

                    Console.WriteLine(display);
                }
            }


            Console.WriteLine();
        }
    }
}
