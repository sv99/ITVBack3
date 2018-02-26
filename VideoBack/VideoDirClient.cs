using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace VideoBack
{
    public class Version
    {
        public string version { get; set; }
    }

    public class Token
    {
        public string token { get; set; }
    }

    public class UserCredentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class FilePath
    {
        public string[] path { get; set; }
    }

    public class FileSize
    {
        public long size { get; set; }
    }

    public class VideoDirClient
    {
        private readonly string url;
        private string[] volumes = null;
        private string token;
        private string errorMessage;

        public VideoDirClient(string url)
        {
            this.url = url;

            // allow self signed certificats
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public string GetErrorMessage()
        {
            return this.errorMessage;
        }

        private void PrepRequest(ref HttpWebRequest request, string method = "GET", bool isAuth = false)
        {
            request.AllowAutoRedirect = false;
            request.Timeout = 3000;
            request.Method = method;
            if (method == "POST")
                request.ContentType = "application/json; charset=utf-8";
            if (isAuth)
                request.Headers.Add("Authorization", "Bearer " + this.token);
        }

        private void SendJson<T>(ref HttpWebRequest request, T value)
        {
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = value.ToJson();
                streamWriter.Write(json);
                streamWriter.Flush();
            }
        }

        private T ReadJsonResponse<T>(ref HttpWebRequest request)
        {
            using (var response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    return json.FromJson<T>();
                }
            }
        }

        public bool Ping()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url);
                PrepRequest(ref request);
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException e)
            {
                this.errorMessage = e.Message;
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/login");

                PrepRequest(ref request, "POST");
                SendJson(ref request, new UserCredentials { username = username, password = password });

                Token token = ReadJsonResponse<Token>(ref request);
                this.token = token.token;
                return true;
            }
            catch (WebException e)
            {
                this.errorMessage = e.Message;
            }
            return false;
        }

        public string GetVersion()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/version");
                PrepRequest(ref request, "GET", true);
                Version ver = ReadJsonResponse<Version>(ref request);
                return ver.version;
            }
            catch (WebException e)
            {
                this.errorMessage = e.Message;
            }
            return "";
        }

        public string[] GetVolumes()
        {
            if (this.volumes == null)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/volumes");
                    PrepRequest(ref request, "GET", true);
                    this.volumes = ReadJsonResponse<string[]>(ref request);
                }
                catch (WebException e)
                {
                    this.errorMessage = e.Message;
                }
            }
            return this.volumes;
        }

        public static string[] SplitPath(string path)
        {
            String[] pathSeparators = new String[] { "\\" };
            return path.Split(pathSeparators, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] GetList(string path)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/list");
                PrepRequest(ref request, "POST", true);
                SendJson(ref request, new FilePath { path = SplitPath(path) });
                var items = ReadJsonResponse<string[]>(ref request);
                return items;
            }
            catch (WebException e)
            {
                this.errorMessage = e.Message;
                return new string[] { };
            }
        }

        public long GetFile(string path, string destFolder)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/file");
                PrepRequest(ref request, "POST", true);

                SendJson(ref request, new FilePath { path = SplitPath(path) });

                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        long fileSize = 0L;
                        // Create the local file
                        var destPath = Path.Combine(destFolder, path);
                        using (var localStream = File.Create(destPath))
                        {
                            int bytesRead = 0;
                            // Allocate a 1k buffer
                            byte[] buffer = new byte[64 * 1024];
                            // Simple do/while loop to read from stream until no bytes are returned
                            do
                            {
                                // Read data (up to 64k) from the stream
                                bytesRead = responseStream.Read(buffer, 0, buffer.Length);

                                // Write the data to the local file
                                localStream.Write(buffer, 0, bytesRead);

                                // Increment total bytes processed
                                fileSize += bytesRead;
                            } while (bytesRead > 0);
                        }
                        if (fileSize == 0)
                            File.Delete(destPath);
                        return fileSize;
                    }
                }
            }
            catch (WebException e)
            {
                this.errorMessage = e.Message;
                return 0L;
            }
        }

        public long GetFileSize(string path)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/filesize");
                PrepRequest(ref request, "POST", true);

                SendJson(ref request, new FilePath { path = SplitPath(path) });
                var size = ReadJsonResponse<FileSize>(ref request);
                return size.size;
            }
            catch (WebException e)
            {
                this.errorMessage = e.Message;
                return 0L;
            }
        }
    }
}
