using GHLCP.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GHLCP
{
    public abstract class GamedirFactory
    {
        public abstract Gamedir Get();

        protected Gamedir Get(string path, IFileManager fileManager, char dirSeparator)
        {
            List<string> filenames = path.Split(dirSeparator).ToList();
            string filename = filenames[filenames.Count - 1];

            switch (filename)
            {
                case "GHLive.rpx":
                    filenames.Remove(filename);
                    filenames.Remove("code");
                    filenames.Add("content");
                    return new Gamedir(string.Join("/", filenames), Platform.WiiU, fileManager);

                case "EBOOT.BIN":
                    filenames.Remove(filename);
                    return new Gamedir(string.Join("/", filenames), Platform.PS3, fileManager);

                case "default.xex":
                    filenames.Remove(filename);
                    return new Gamedir(string.Join("/", filenames), Platform.X360, fileManager);

                case "GHLive":
                    filenames.Remove(filename);
                    return new Gamedir(string.Join("/", filenames), Platform.IOS, fileManager);

                default:
                    throw new ArgumentException("The path received as a parameter is not a supported Guitar Hero Live executable");
            }
        }
    }
}
