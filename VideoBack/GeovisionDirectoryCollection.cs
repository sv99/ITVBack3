using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VideoBack
{
    /*
    Структура каталогов Geovision
    -----------------------------

        VIDEO
        ├── cam01
        │   ├── 0101
        │   │   ├── Event20180101102142001
        │   │   ├── Event20180101122042001
        │   │   ├── Event20180101182042001
        │   │   └── Event20180101222042001
        │   ├── 0102
        │   │   ├── Event20180102102142001
        │   │   ├── Event20180102122042001
        │   │   ├── Event20180102182042001
        │   │   └── Event20180102222042001
        │   ├── 1230
        │   │   ├── Event20171230102142001
        │   │   ├── Event20171230122042001
        │   │   └── Event20171230182042001
        │   └── 1231
        │       ├── Event20171231102142001
        │       ├── Event20171231122042001
        │       └── Event20171231182042001
        ├── aud01
        │   └── 0101
        │       ├── Event20180101102142001
        │       ├── Event20180101122042001
        │       ├── Event20180101182042001
        │       └── Event20180101222042001
        └── aud02
            └── 0102
                ├── Event20180101102142001
                ├── Event20180101122042001
                ├── Event20180101182042001
                └── Event20180101222042001

    Структура каталога VIDEO двухуровневая сначала папки по камерам
    и микрофонам и внутри них папки по месяцам и дням.
    События - EventXXX непосредственно в папках для каждого дня.
    */

    internal class GeovisionDirectoryCollection : List<string>
    {
        private const string FOLDER_PATTERN = "??-??-?? ??";
        private const string CAMERA_EXT_PATTERN = "*._";

        public int Camera { get; }
        private readonly DateTime from;

        public GeovisionDirectoryCollection(int camera, DateTime from)
        {
            this.Camera = camera;
            this.from = from; 
        }

        public static string GetCamFolderName(int cam)
        {
            return String.Format("cam{0:00}", cam);
        }

        private string[] FilterEvents(string[] events)
        {
            var filtered = Array.FindAll(events, f => {
                var date = GetEventDate(f);
                return date >= this.from; 
            });
            return filtered;
        }

        // for Geovision specific EVENT_PATTERN = "EventYYYYMMDDHHmmssXXX"
        public static DateTime GetEventDate(string filename)
        {
            string eventName = Path.GetFileName(filename);
            Debug.Assert(eventName != null, "fileName != null");
            var year = Int32.Parse(eventName.Substring(5, 4));
            var month = Int32.Parse(eventName.Substring(9, 2));
            var day = Int32.Parse(eventName.Substring(11, 2));
            return new DateTime(Int32.Parse(eventName.Substring(5, 4)),
                Int32.Parse(eventName.Substring(9, 2)),
                Int32.Parse(eventName.Substring(11, 2)));
        }

        public void FillFromServer(VideoDirClient client)
        {
            var dirs = client.GetList(GetCamFolderName(this.Camera));
            var myRegex = new Regex(@"^\d\d\d\d$");
            var filtered = Array.FindAll(dirs, d => myRegex.IsMatch(d));
            this.AddRange(filtered);
        }

        public IEnumerable<string> GetRemoteVideoData(VideoDirClient client, string path)
        {
            var files = client.GetList(Path.Combine(GetCamFolderName(this.Camera), path));
            return FilterEvents(files);
        }

        //copy data for single cam from server
        public long CopyRemoteData(VideoDirClient client, string path, string destFolder)
        {
            long bytesProcessed = 0L;
            foreach (string eventName in this.GetRemoteVideoData(client, path))
            {
                Debug.Assert(eventName != null, "eventFile != null");
                string destPath = Path.Combine(destFolder, GetCamFolderName(this.Camera), path);
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                var eventPath = Path.Combine(destPath, eventName);
                var queryPath = Path.Combine(GetCamFolderName(this.Camera), path, eventName);
                if (File.Exists(eventPath))
                {
                    // check file size
                    var destSize = new FileInfo(eventPath).Length;

                    var remSize = client.GetFileSize(queryPath);
                    if (destSize == remSize)
                        continue;
                }
                // get file from server
                bytesProcessed += client.GetFile(queryPath, destFolder);
            }
            return bytesProcessed;
        }
    }
}
