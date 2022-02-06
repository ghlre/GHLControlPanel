using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GHLCP.FileManager
{
    public class RemoteFileInfo
    {
        public string Name { get; }

        public string Permissions { get; }

        public int Inode { get; }

        public string Owner { get; }

        public string Group { get; }

        public long Size { get; }

        public DateTime LastModified { get; }

        public RemoteFileInfo(string details)
        {
            string pattern = @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
            Regex regex = new Regex(pattern);
            string[] dateTimeFormats =
                new string[] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm" };
            string[] dateFormats =
                new string[] { "MMM dd yyyy", "MMM d yyyy" };

            Match match = regex.Match(details);
            Permissions = match.Groups[1].Value;
            Inode = int.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
            Owner = match.Groups[3].Value;
            Group = match.Groups[4].Value;
            Size = long.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);
            string lastModified = Regex.Replace(match.Groups[6].Value, @"\s+", " ");

            string[] formats = (lastModified.IndexOf(':') >= 0) ? dateTimeFormats : dateFormats;
            LastModified = DateTime.ParseExact(lastModified, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            Name = match.Groups[7].Value;
        }

        public bool IsDirectory
        {
            get
            {
                return Permissions[0] == 'd';
            }
        }

        public bool IsCurrentDirectory
        {
            get
            {
                return Name == ".";
            }
        }

        public bool IsParentDirectory
        {
            get
            {
                return Name == "..";
            }
        }
    }
}
