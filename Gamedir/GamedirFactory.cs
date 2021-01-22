using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GHLCP
{
    public static class GamedirFactory
    {
        public static Gamedir Get(string path)
        {
            List<string> filenames = path.Split(Path.DirectorySeparatorChar).ToList();
            string filename = filenames[filenames.Count - 1];

            switch (filename)
            {
                case "GHLive.rpx":
                    filenames.Remove(filename);
                    filenames.Remove("code");
                    filenames.Add("content");
                    return new Gamedir(String.Join("/", filenames), Platform.WiiU);

                case "EBOOT.BIN":
                    filenames.Remove(filename);
                    return new Gamedir(String.Join("/", filenames), Platform.PS3);

                case "default.xex":
                    filenames.Remove(filename);
                    return new Gamedir(String.Join("/", filenames), Platform.X360);

                case "GHLive":
                    filenames.Remove(filename);
                    return new Gamedir(String.Join("/", filenames), Platform.IOS);

                default:
                    throw new ArgumentException("The path received as a parameter is not a supported Guitar Hero Live executable");
            }
        }
    }
}
