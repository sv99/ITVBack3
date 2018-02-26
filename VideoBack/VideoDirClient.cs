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

    public class SONGHISTORY
    {
        public string PLAYEDAT { get; set; }
        public string TITLE { get; set; }
        public string ARTIST { get; set; }
        public int? ARTISTID { get; set; }
        public string SONG { get; set; }
        public int? SONGID { get; set; }
    }

    public class VideoDirClient
    {
        private readonly string url;
        private string[] volumes = null;
        private string token;

        public VideoDirClient(string url)
        {
            this.url = url;

            // allow self signed certificats
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }

        public bool Ping()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url);
            try
            { 
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Timeout = 3000;
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/login");
            try
            {
                request.AllowAutoRedirect = false;
                request.Timeout = 3000;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = new UserCredentials { username = username, password = password }.ToJson();
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                using (var response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        var json = reader.ReadToEnd();
                        Token token = json.FromJson<Token>();
                        this.token = token.token;
                        return true;
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public string GetVersion()
        {
            string res = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/version");
            try
            {
                request.AllowAutoRedirect = false;
                request.Timeout = 3000;
                request.Method = "GET";
                request.Headers.Add("Authorization", "Bearer " + this.token);
                request.ContentType = "application/json; charset=utf-8";

                using (var response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        var json = reader.ReadToEnd();
                        Version ver = json.FromJson<Version>();
                        res = ver.version;
                    }
                }
            }
            catch
            {
            }
            return res;
        }

        public string[] GetVolumes()
        {
            if (this.volumes == null)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/volumes");
                try
                {
                    request.AllowAutoRedirect = false;
                    request.Timeout = 3000;
                    request.Method = "GET";
                    request.Headers.Add("Authorization", "Bearer " + this.token);
                    request.ContentType = "application/json; charset=utf-8";

                    using (var response = request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                            var json = reader.ReadToEnd();
                            this.volumes = json.FromJson<string[]>();
                        }
                    }
                }
                catch
                {
                    //return new string[] { };
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
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/list");
            try
            {
                request.AllowAutoRedirect = false;
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bearer " + this.token);
                request.ContentType = "application/json; charset=utf-8";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = new FilePath { path = SplitPath(path) }.ToJson();

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                using (var response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        var json = reader.ReadToEnd();
                        var items = json.FromJson<string[]>();
                        return items;
                    }
                }
            }
            catch (Exception e)
            {
                if (e == null)
                {
                }
                return new string[] { };
            }
        }

        public long GetFile(string path, string destFolder)
        {
            WebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.url + "/api/v1/file");
                request.AllowAutoRedirect = false;
                request.Method = "POST";
                request.Headers.Add("Authorization", "Bearer " + this.token);
                request.ContentType = "application/json; charset=utf-8";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = new FilePath { path = SplitPath(path) }.ToJson();

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                using (response = request.GetResponse())
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
            catch
            {
                 return 0L;
            }
        }
    }
}
