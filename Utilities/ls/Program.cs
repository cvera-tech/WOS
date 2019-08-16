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
            const int columnWidth = 14;
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
                string header = "SIZE".PadRight(columnWidth);
                header += "CREATED".PadRight(columnWidth);
                header += "MODIFIED".PadRight(columnWidth);
                Console.WriteLine(header);
                foreach (var item in items)
                {
                    string display = String.Empty;
                    string name = item.Substring(2);
                    const string dateTimeFormat = "MMM dd HH:mm";

                    if (Directory.Exists(item))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(item);
                        display += String.Empty.PadRight(columnWidth);
                        display += directoryInfo.CreationTime.ToString(dateTimeFormat).PadRight(columnWidth);
                        display += directoryInfo.LastWriteTime.ToString(dateTimeFormat).PadRight(columnWidth);
                        display += name + "/";
                    }
                    else
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        display += fileInfo.Length.ToString().PadLeft(12).PadRight(columnWidth);
                        display += fileInfo.CreationTime.ToString(dateTimeFormat).PadRight(columnWidth);
                        display += fileInfo.LastWriteTime.ToString(dateTimeFormat).PadRight(columnWidth);
                        display += name;
                    }

                    Console.WriteLine(display);
                }
            }


            Console.WriteLine();
        }
    }
}
