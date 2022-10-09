using GHLCP.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace GHLCP.FileManager
{
    public class FtpFileManager : IFileManager
    {
        public ICredentials Credentials { get; }

        public FtpFileManager(ICredentials credentials)
        {
            Credentials = credentials;
        }

        public FtpFileManager(string username, string password) : this(new NetworkCredential(username, password))
        {
        }

        public void CreateDirectory(string path)
        {
            if (path.EndsWith("/"))
            {
                path = path.TrimEnd('/');
            }

            string[] directories = path.Split('/');
            string parent = string.Join("/", directories, 0, directories.Length - 1);

            if (!DirectoryExists(parent))
            {
                // Recursively create parent directory
                CreateDirectory(parent);
            }

            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.MakeDirectory);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Logger.Instance.Trace(request, response);
            }
        }

        public IEnumerable<string> GetDirectories(string path)
        {
            if (!path.EndsWith("/"))
            {
                path = string.Concat(path, "/");
            }

            return GetRemoteFileInfos(path)
                .Where(info => info.IsDirectory && !info.IsCurrentDirectory && !info.IsParentDirectory)
                .Select(dir => string.Concat(path, dir.Name));
        }

        public IEnumerable<string> GetFiles(string path)
        {
            if (!path.EndsWith("/"))
            {
                path = string.Concat(path, "/");
            }

            return GetRemoteFileInfos(path)
                .Where(info => !info.IsDirectory)
                .Select(file => string.Concat(path, file.Name));
        }

        public Stream OpenRead(string path)
        {
            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.DownloadFile);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Logger.Instance.Trace(request, response);
            return response.GetResponseStream();
        }

        public Stream OpenWrite(string path)
        {
            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.UploadFile);
            return new FtpRequestStream(request);
        }

        public void Copy(string source, string dest)
        {
            using (Stream sourceStream = OpenRead(source))
            {
                using (Stream destStream = OpenWrite(dest))
                {
                    sourceStream.CopyTo(destStream);
                }
            }
        }

        public void Move(string source, string dest)
        {
            FtpWebRequest request = CreateFtpRequest(source, WebRequestMethods.Ftp.Rename);

            if (Uri.TryCreate(dest, UriKind.Absolute, out var uri))
            {
                request.RenameTo = uri.LocalPath;
            }
            else
            {
                request.RenameTo = dest;
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Logger.Instance.Trace(request, response);
            }
        }

        public void Delete(string path)
        {
            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.DeleteFile);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Logger.Instance.Trace(request, response);
            }
        }

        public bool FileExists(string path)
        {
            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.DownloadFile);

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Logger.Instance.Trace(request, response);
                    return true;
                }
            }
            catch (WebException ex)
            {
                using (FtpWebResponse response = (FtpWebResponse)ex.Response)
                {
                    Logger.Instance.Trace(request, response);
                }
            }

            return false;
        }

        public bool DirectoryExists(string path)
        {
            if (!path.EndsWith("/"))
            {
                path = string.Concat(path, "/");
            }

            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.ListDirectoryDetails);

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Logger.Instance.Trace(request, response);
                    return true;
                }
            }
            catch (WebException ex)
            {
                using (FtpWebResponse response = (FtpWebResponse)ex.Response)
                {
                    Logger.Instance.Trace(request, response);
                }
            }

            return false;
        }

        protected virtual FtpWebRequest CreateFtpRequest(string path, string method)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Credentials = Credentials;
            request.Method = method;
            return request;
        }

        protected IEnumerable<RemoteFileInfo> GetRemoteFileInfos(string path)
        {
            FtpWebRequest request = CreateFtpRequest(path, WebRequestMethods.Ftp.ListDirectoryDetails);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Logger.Instance.Trace(request, response);

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        yield return new RemoteFileInfo(reader.ReadLine());
                    }
                }
            }
        }
    }
}
