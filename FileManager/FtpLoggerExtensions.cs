using GHLCP.Diagnostics;
using System.Net;

namespace GHLCP.FileManager
{
    public static class FtpLoggerExtensions
    {
        public static void Error(this ILogger logger, FtpWebRequest req, FtpWebResponse res)
        {
            logger.Error(GetFtpMessage(req, res));
        }

        public static void Warning(this ILogger logger, FtpWebRequest req, FtpWebResponse res)
        {
            logger.Warning(GetFtpMessage(req, res));
        }

        public static void Debug(this ILogger logger, FtpWebRequest req, FtpWebResponse res)
        {
            logger.Debug(GetFtpMessage(req, res));
        }

        public static void Trace(this ILogger logger, FtpWebRequest req, FtpWebResponse res)
        {
            logger.Trace(GetFtpMessage(req, res));
        }

        public static string GetFtpMessage(FtpWebRequest req, FtpWebResponse res)
        {
            switch (req.Method)
            {
                case WebRequestMethods.Ftp.Rename:
                    return string.Format("{0} {1} {2} {3}", req.Method, req.RequestUri, req.RenameTo, res.StatusDescription);
                default:
                    return string.Format("{0} {1} {2}", req.Method, req.RequestUri, res.StatusDescription);
            }
        }
    }
}
