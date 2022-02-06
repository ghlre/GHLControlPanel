using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GHLCP.FileManager
{
    public interface IFileManager
    {
        void CreateDirectory(string path);

        IEnumerable<string> GetDirectories(string path);

        IEnumerable<string> GetFiles(string path);

        Stream OpenRead(string path);

        Stream OpenWrite(string path);

        void Copy(string source, string dest);

        void Move(string source, string dest);

        void Delete(string path);

        bool FileExists(string path);

        bool DirectoryExists(string path);
    }

    public static class IFileManagerExtensions
    {
        public static IEnumerable<string> ReadAllLines(this IFileManager fileManager, string path)
        {
            using (Stream stream = fileManager.OpenRead(path))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        yield return reader.ReadLine();
                    }
                }
            }
        }

        public static void WriteAllLines(this IFileManager fileManager, string path, IEnumerable<string> lines)
        {
            using (Stream stream = fileManager.OpenWrite(path))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
