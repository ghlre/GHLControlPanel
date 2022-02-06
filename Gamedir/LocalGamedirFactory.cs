using GHLCP.FileManager;
using System.IO;

namespace GHLCP
{
    public class LocalGamedirFactory : GamedirFactory
    {
        private readonly string path;

        public LocalGamedirFactory(string path)
        {
            this.path = path;
        }

        public override Gamedir Get()
        {
            return Get(path, new LocalFileManager(), Path.DirectorySeparatorChar);
        }
    }
}
