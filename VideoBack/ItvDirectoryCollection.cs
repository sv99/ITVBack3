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
    internal class ItvDirectoryCollection : List<string>
    {
        private const string FOLDER_PATTERN = "??-??-?? ??";
        private const string CAMERA_EXT_PATTERN = "*._";
        private readonly VideoDirClient client;

        public VideoDirClient GetClient()
        {
            return client;
        }

        public ItvDirectoryCollection(VideoDirClient client = null)
        {
            this.client = client;
        }

        // for folder version 
        public ItvDirectoryCollection(string path)
        {
            List<string> source = Directory.GetDirectories(path, FOLDER_PATTERN).ToList();
            if (source.Count <= 0) return;
            this.AddRange(source);
            this.SortByDate();
        }

        // for remote version
        public bool Login(string username, string password)
        {
            return this.client.Login(username, password);
        }

        // for remote version
        public void FillFromRemote()
        {
            var volumes = this.client.GetVolumes();
            var dirs = this.client.GetList("");
            this.AddDirectories(dirs);
            this.SortByDate();
        }

        // for ITV specific FOLDER_PATTERN = "??-??-?? HH"
        public static string GetFolderHour(string folder)
        {
            string fileName = Path.GetFileName(folder);
            Debug.Assert(fileName != null, "fileName != null");
            return fileName.Substring(9, 2);
        }

        // for ITV specific FOLDER_PATTERN = "DD-MM-YY ??"
        public static DateTime GetFolderDate(string folder)
        {
            string fileName = Path.GetFileName(folder);
            Debug.Assert(fileName != null, "fileName != null");
            return new DateTime(2000 + Int32.Parse(fileName.Substring(6, 2)),
                Int32.Parse(fileName.Substring(3, 2)), Int32.Parse(fileName.Substring(0, 2)));
        }

        // Формат даты в папке dd-mm-yy hh - hh это час начиная с 0-23 
        public static string GetNormalFolderName(string folder)
        {
            string fileName = Path.GetFileName(folder);
            Debug.Assert(fileName != null, "fileName != null");
            return fileName.Substring(6, 2) + '-' + fileName.Substring(3, 2) + '-'
              + fileName.Substring(0, 2) + ' ' + fileName.Substring(9, 2);
        }

        public void SortByDate()
        {
            if (Count > 0)
            {
                Sort(CompareByDate);
            }
        }

        public int AddDriveData(char driveLetter)
        {
            int res = 0;
            DriveInfo info = new DriveInfo(driveLetter.ToString(CultureInfo.InvariantCulture));
            string path = Path.Combine(info.RootDirectory.ToString(), "video");
            if ((info.IsReady && ((info.DriveType == DriveType.Removable) || (info.DriveType == DriveType.Fixed)))
                && Directory.Exists(path))
            {
                res = this.AddDirectories(path);
            }
            return res;
        }

        public int AddDirectories(string path)
        {
            string[] directories = Directory.GetDirectories(path, FOLDER_PATTERN);
            return AddDirectories(directories);
        }

        public int AddDirectories(string[] directories)
        {
            var myRegex = new Regex(@"^\d\d-\d\d-\d\d \d\d$");
            var filtered = Array.FindAll(directories, d => myRegex.IsMatch(d));
            this.AddRange(filtered);
            return filtered.Count();
        }

        private static int CompareByDate(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            var fileNameX = Path.GetFileName(x);
            if (fileNameX == null) throw new ArgumentNullException("fileNameX is null");
            var fileNameY = Path.GetFileName(x);
            if (fileNameY == null) throw new ArgumentNullException("fileNameY is null");

            int xfolderLen = fileNameX.Length;
            int yfolderLen = fileNameY.Length;
            if ((xfolderLen == yfolderLen) && (xfolderLen == FOLDER_PATTERN.Length))
            {
                string normx = GetNormalFolderName(x);
                string normy = GetNormalFolderName(y);
                return String.Compare(normx, normy, StringComparison.Ordinal);
            }

            return String.Compare(x, y, StringComparison.Ordinal);
        }

        // For proper working must by sorted!
        public DateTime GetFirstDate()
        {
            //project start 1.1.2012
            DateTime time = new DateTime(2012,1,1);
            if (Count > 0)
                time = GetFolderDate(this.First());
            return time;
        }

        public DateTime GetLastDate()
        {
            // For proper working must by sorted!
            DateTime time = DateTime.Now;
            if (Count > 0)
                time = GetFolderDate(this.Last());
            return time;
        }

        public int CountDays()
        {
            // For proper working must by sorted!
            if (Count == 0)
                return 0;
            // Есть хотя бы один день
            DateTime day = this.GetFirstDate();
            int count = 1;
            foreach (var item in this)
            {
                DateTime current = GetFolderDate(item);
                if (current != day)
                {
                    day = current;
                    count++;
                }
            }
            return count;
        }

        // Remove folders from start. 
        // For proper working must by sorted!
        public void RemoveTo(DateTime date)
        {
            while (Count > 0)
            {
                string folder = this.First();
                if (GetFolderDate(folder) > date)
                {
                    break;
                }
                Remove(folder);
            }
        }

        // Remove folders from start. 
        // For proper working must by sorted!
        public void RemoveFrom(DateTime date)
        {
            for (int i = 0; i<Count; i++)
            {
                if (GetFolderDate(this[i]) == date)
                {
                    while (i != Count)
                        Remove(this.Last());
                }
            }
        }

        public static DateTime GetFolderLastDate(string folder)
        {
            DateTime time = DateTime.Now;
            if (Directory.Exists(folder))
            {
                ItvDirectoryCollection source = new ItvDirectoryCollection(folder);
                if (source.Count > 0)
                {
                    time = GetFolderDate(source.Last());
                }
            }
            return time;
        }

        public long GetDayDataSize(DateTime date, int camera)
        {
            long num = 0L;
            foreach (string str in GetDayData(date, camera))
            {
                num += new FileInfo(str).Length;
            }
            return num;
        }

        public long GetDayDataSize(DateTime date, IEnumerable<int> cams)
        {
            long num = 0L;
            foreach (var cam in cams)
            {
                num += GetDayDataSize(date, cam);
            }
            return num;
        }

        public IEnumerable<string> GetDayData(DateTime date, int camera)
        {
            string searchPattern = "*._" + camera.ToString("D2");
            return this.Where(strItem =>
                              GetFolderDate(strItem) == date
                              ).Select(strItem =>
                                       Directory.GetFiles(strItem, searchPattern)
                                       ).SelectMany(files => files);
        }

        public IEnumerable<string> GetRemoteVideoData(string path, int camera)
        {
            var files = this.client.GetList(path);
            var myRegex = new Regex("._" + camera.ToString("D2"));
            var filtered = Array.FindAll(files, f => myRegex.IsMatch(f));
            return filtered;
        }

        //copy data for single cam from server
        public long CopyRemoteData(string path, int camera, string destFolder)
        {
            long bytesProcessed = 0L;
            foreach (string eventName in this.GetRemoteVideoData(path, camera))
            {
                Debug.Assert(eventName != null, "filePath != null");
                string destPath = Path.Combine(destFolder, path);
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                var eventPath = Path.Combine(destPath, eventName);
                var queryPath = Path.Combine(path, eventName);
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
