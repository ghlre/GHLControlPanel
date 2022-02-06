using GHLCP.FileManager;
using System.Net;

namespace GHLCP
{
    public class FtpGamedirFactory : GamedirFactory
    {
        private readonly string path;

        private readonly ICredentials credentials;

        public FtpGamedirFactory(string path, ICredentials credentials)
        {
            this.path = path;
            this.credentials = credentials;
        }

        public FtpGamedirFactory(string path, string username, string password)
            : this(path, new NetworkCredential(username, password))
        {
        }

        public override Gamedir Get()
        {
            return Get(path, new FtpFileManager(credentials), '/');
        }
    }
}
