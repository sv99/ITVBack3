using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ITVBack
{
    internal class ItvDirectoryCollection : List<string>
    {
        private const string FOLDER_PATTERN = "??-??-?? ??";
        private const string CAMERA_EXT_PATTERN = "*._";

        public ItvDirectoryCollection()
        {
        }

        public ItvDirectoryCollection(string path)
        {
            List<string> source = Directory.GetDirectories(path, FOLDER_PATTERN).ToList();
            if (source.Count <= 0) return;
            this.AddRange(source);
            this.SortByDate();
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
            this.AddRange(directories);
            return directories.Count();
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
                string normx = Utils.getNormalFolderName(x);
                string normy = Utils.getNormalFolderName(y);
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
                time = Utils.getFolderDate(this.First());
            return time;
        }

        public DateTime GetLastDate()
        {
            // For proper working must by sorted!
            DateTime time = DateTime.Now;
            if (Count > 0)
                time = Utils.getFolderDate(this.Last());
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
                DateTime current = Utils.getFolderDate(item);
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
                if (Utils.getFolderDate(folder) > date)
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
                if (Utils.getFolderDate(this[i]) == date)
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
                    time = Utils.getFolderDate(source.Last());
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
                              Utils.getFolderDate(strItem) == date
                              ).Select(strItem =>
                                       Directory.GetFiles(strItem, searchPattern)
                                       ).SelectMany(files => files);
        }
    }
}
