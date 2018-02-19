using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ITVBack
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        // Properties
        public string DestFolder
        {
            get
            {
                return this.laDestFolder.Text;
            }
            set
            {
                this.laDestFolder.Text = value;
                if (Directory.Exists(value))
                {
                    this.buCopy.Enabled = true;
                    this.buCheck.Enabled = true;
                    this.LastCopiedDate = ItvDirectoryCollection.GetFolderLastDate(value);
                }
                else 
                {
                    this.buCopy.Enabled = false;
                    this.buCheck.Enabled = false;                    
                }
            }
        }

        public DateTime LastCopiedDate
        {
            get
            {
                return this.dtLastCopiedDate.Value;
            }
            set
            {
                this.dtLastCopiedDate.Value = value;
            }
        }

        public int[] Cams
        {
            get
            {
                string t = this.laCamsArray.Text;
                if (t.IndexOf(',') <= 0)
                {
                    //одна камера
                    int[] res1 = new int[1];
                    res1[0] = Convert.ToInt32(t);
                    return res1;
                }

                string[] cams = t.Split(',');
                int[] res = new int[cams.Length];
                for (int i = 0; i < cams.Length; i++)
                {
                    res[i] = Convert.ToInt32(cams[i]);
                }
                return res;
            }
        }

        // сохранение и восстановление состояния в user.config - Local Settings/Application Data/...
        private void fmMain_Load(object sender, EventArgs e)
        {
            this.addLog("--------------------------------------------------");
            this.addLog("Запуск программы");

            Program.LoadSettings();
            InitSettings();
        }

        private void InitSettings()
        {
            this.laCamsArray.Text = Program.profile.Cams;
            this.lbSources.Items.Clear();
            if (Program.profile.IsLocalScan)
            {
                this.lbSources.Items.Add("Локальные диски");
            }
            else
            {
                foreach (string item in Program.profile.SourceFolders)
                    this.lbSources.Items.Add(item);
            }
            this.DestFolder = Program.profile.DestFolder;
        }

        #region Buttons Events

        // Кнопки управления
        // Проверка последовательности записанных данных в папке назначения
        private void buCheck_Click(object sender, EventArgs e)
        {
            checkDestSequence(this.DestFolder);
        }

        private void buClearLog_Click(object sender, EventArgs e)
        {
            this.lbLog.Items.Clear();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buCopy_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.DestFolder))
            {
                this.addLog("Каталог не существует: " + this.DestFolder);
                return;
            }
            this.addLog("Старт копирования");
            ItvDirectoryCollection source = null;
            if (Program.profile.IsLocalScan)
            {
                source = this.scanDrives();
            }
            else
            {
                source = new ItvDirectoryCollection();
                foreach (string dir in Program.profile.SourceFolders)
                {
                    if (Directory.Exists(dir))
                    {
                        source.AddDirectories(dir);
                    }
                }
            }
            source.SortByDate();;
            
            source.RemoveTo(this.LastCopiedDate.AddDays(-1.0));
            source.RemoveFrom(DateTime.Now);
            //this.saveState();
            if (source.Count <= 0) return;
            //start coping data
            this.toolStripProgressBar1.Maximum = source.CountDays();
            this.toolStripProgressBar1.Value = 0;
            setCopyState(true);
            this.backgroundWorker1.RunWorkerAsync(source);
        }

        private void buCancel_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
            this.buCancel.Enabled = false;
        }

        private void buProfile_Click(object sender, EventArgs e)
        {
            // show fmProfile - for select Working cams
            fmProfile fm = new fmProfile(Program.profile);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                Program.profile = fm.Profile;
                Program.SaveSettings();
                InitSettings();
            }
        }
        
        #endregion

        private void setCopyState(bool coping)
        {
            this.buCopy.Enabled = !coping;
            this.buCancel.Enabled = coping;
            this.buProfile.Enabled = !coping;
        }

        private ItvDirectoryCollection scanDrives()
        {
            var list = new ItvDirectoryCollection();
            foreach (char ch in "cdefghijklmnopqrstuvwxyz".Where(ch => list.AddDriveData(ch) > 0))
            {
                this.addLog("Найдены видео данные на диске: " + ch + @":\", false);
            }
            list.SortByDate();
            return list;
        }

        #region BackgroundWorker

        // Асинхронный цикл копирования файлов
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) throw new ArgumentNullException("BackgroundWorker is null");

            ItvDirectoryCollection source = (e.Argument as ItvDirectoryCollection) ?? new ItvDirectoryCollection();
            int[] cams = this.Cams;
            int dayCount = 0;
            //int folderCounter = 0;
            for (int i = 0; source.Count > 0; i = source.Count)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    worker.ReportProgress(100, "Копирование прервано, необработано: " + (source.Count - i));
                    break;
                }
                DateTime date = source.GetFirstDate();
                long lFolderSize = source.GetDayDataSize(date, cams);
                if (lFolderSize > 0L)
                {
                    DateTime start = DateTime.Now;
                    worker.ReportProgress(dayCount,
                        "Найдены данные " + Utils.ArrayToStringGeneric<int>(cams, ",") + 
                        " за " + date.ToShortDateString() + " размер: " + getSizeMb(lFolderSize));
                    if (!this.checkDestSpace(lFolderSize))
                    {
                        worker.ReportProgress(100, "Не хватает места для копирования данных за: " 
                            + date.ToShortDateString());
                        worker.ReportProgress(100, "Осталось: " + getSizeMb(getDestSpace()));
                        break;
                    }
                    long num5 = copyData(source, date, cams);
                    TimeSpan elapsed = DateTime.Now.Subtract(start);
                    worker.ReportProgress(dayCount,
                        " Скопировано " + getSizeMb(num5) + " " + getTimeMinSek(elapsed) + " сек");
                }
                source.RemoveTo(date);
                dayCount++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string userState = e.UserState as string;
            if (userState != null)
            {
                this.addLog(userState);
            }
            this.toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripProgressBar1.Maximum = 100;
            this.toolStripProgressBar1.Value = 100;
            this.setCopyState(false);
            this.addLog("Копирование завершено");
        }

        // copy data from many cams 
        private long copyData(ItvDirectoryCollection source, DateTime date, IEnumerable<int> cams)
        {
            long num = 0L;
            foreach (var cam in cams)
            {
                num += copyData(source, date, cam);
            }
            return num;
        }

        //copy data from single cam
        private long copyData(ItvDirectoryCollection source, DateTime date, int camera)
        {
            long num = 0L;
            foreach (string strRecord in source.GetDayData(date, camera))
            {
                Debug.Assert(strRecord != null, "filePath != null");
                var fileName = Path.GetFileName(Path.GetDirectoryName(strRecord)) ?? "";
                string path = Path.Combine(this.DestFolder, fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                fileName = Path.GetFileName(strRecord) ?? "";
                string strRecordDest = Path.Combine(path, fileName);
                if (File.Exists(strRecordDest)) continue;
                num += new FileInfo(strRecord).Length;
                File.Copy(strRecord, strRecordDest);
            }
            return num;
        }

        #endregion

        private bool checkDestSpace(long size)
        {
            DriveInfo info = new DriveInfo(this.DestFolder);
            return (info.IsReady && (info.TotalFreeSpace > size));
        }

        private long getDestSpace()
        {
            long val = 0L;
            DriveInfo info = new DriveInfo(this.DestFolder);
            if (info.IsReady)
                val = info.TotalFreeSpace;
            return val;
        }

        public static int getPercent(int value, int count)
        {
            return (int)((((float)value) / ((float)count)) * 100f);
        }

        public static string getSizeMb(long value)
        {
            long num = (value / 0x400L) / 0x400L;
            return (num.ToString("#,##0") + " Mb");
        }

        public static string getTimeMinSek(TimeSpan span)
        {
            if (span.Minutes > 0)
                return string.Format("{0}:{1}.{2}", span.Minutes, span.Seconds, span.Milliseconds);
            return string.Format("{0}.{1}", span.Seconds, span.Milliseconds);
        }

        private void addLog(string sMessage, bool bAddDate = true)
        {
            int num = this.lbLog.Items.Add(sMessage);
            this.lbLog.SelectedIndex = num;
            if (bAddDate)
                sMessage = DateTime.Now.ToString(CultureInfo.InvariantCulture) + ' ' + sMessage;
            File.AppendAllText(Path.ChangeExtension(Application.ExecutablePath, ".log"), sMessage + "\r\n");
        }

        private void checkDestSequence(string folder)
        {
            ItvDirectoryCollection source = new ItvDirectoryCollection(folder);
            this.addLog("Проверка последовательности скопированных данных: start");
            this.addLog("Количество видео папок в каталоге назначения: " + source.Count);
            if (source.Count == 0) return;

            DateTime dt = source.GetFirstDate();
            string mes = dt.ToShortDateString();
            foreach (string f in source)
            {
                if (dt != Utils.getFolderDate(f))
                {
                    this.addLog(mes, false);
                    dt = Utils.getFolderDate(f);
                    mes = dt.ToShortDateString();
                }
                mes = mes + " " + Utils.getFolderHour(f);
            }
            this.addLog(mes, false);
            this.addLog("Проверка последовательности скопированных данных: end");
        }
 
    }
}
