using System;
using System.IO;

namespace SF_8._6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки");
            string path = string.Format(@"{0}", Console.ReadLine());
            Console.WriteLine("Размер папки {0} байт",GetFiles(path, 0));

            Console.ReadKey();
        }

        static long GetFiles(string path, long size)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] dirArray = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                    size += file.Length;
                foreach (DirectoryInfo subFile in dirArray)
                    GetFiles(subFile.FullName, size);
                return size;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
