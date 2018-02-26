using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VideoBack
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        #region Properties

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
                    this.LastCopiedDate = ItvDirectoryCollection.GetFolderLastDate(value);
                }
                else 
                {
                    this.buCopy.Enabled = false;
                }
            }
        }

        public string SourceUrl
        {
            get
            {
                return this.laSourceUrl.Text;
            }
            set
            {
                this.laSourceUrl.Text = value;
                this.buPing.Enabled = value != "";
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

        private void SetType(bool isIntellect)
        {
            this.laType.Text = Program.profile.IsIntellect ? "Intellect" : "Geovision";
        }

        #endregion

        private void AddLog(string sMessage, bool bAddDate = true)
        {
            int num = this.lbLog.Items.Add(sMessage);
            this.lbLog.SelectedIndex = num;
            if (bAddDate)
                sMessage = DateTime.Now.ToString(CultureInfo.InvariantCulture) + ' ' + sMessage;
            File.AppendAllText(Path.ChangeExtension(Application.ExecutablePath, ".log"), sMessage + "\r\n");
        }

        // сохранение и восстановление состояния в user.config
        private void fmMain_Load(object sender, EventArgs e)
        {
            this.AddLog("--------------------------------------------------");
            this.AddLog("Запуск программы");

            Program.LoadSettings();
            InitSettings();
        }

        private void InitSettings()
        {
            this.laCamsArray.Text = Program.profile.Cams;
            this.SourceUrl = Program.profile.SourceUrl;
            this.DestFolder = Program.profile.DestFolder;
            this.SetType(Program.profile.IsIntellect); 
        }

        #region Buttons Events

        // Кнопки управления
        private void buClearLog_Click(object sender, EventArgs e)
        {
            this.lbLog.Items.Clear();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buPing_Click(object sender, EventArgs e)
        {
            VideoDirClient client = new VideoDirClient(this.SourceUrl);
            if (client.Ping())
            {
                this.AddLog("Сервер доступен");
                if (!client.Login(Program.profile.Username, Program.profile.Password))
                {
                    this.AddLog("Invalid credetials");
                    return;
                }
                this.AddLog("Сервер version: " + client.GetVersion());
            }
            else
                this.AddLog("Сервер не доступен");
        }

        private void buCopy_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.DestFolder))
            {
                this.AddLog("Каталог не существует: " + this.DestFolder);
                return;
            }
            SetCopyState(true);
            this.AddLog("Старт копирования");
            if (Program.profile.IsIntellect)
                this.bwIntellect.RunWorkerAsync();
            else
                this.bwGeovision.RunWorkerAsync();
        }

        private void buCancel_Click(object sender, EventArgs e)
        {
            if (this.bwIntellect.IsBusy)
                this.bwIntellect.CancelAsync();
            if (this.bwGeovision.IsBusy)
                this.bwGeovision.CancelAsync();
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

        private void SetCopyState(bool coping)
        {
            this.buCopy.Enabled = !coping;
            this.buCancel.Enabled = coping;
            this.buProfile.Enabled = !coping;
        }

        private ItvDirectoryCollection ScanDrives()
        {
            var list = new ItvDirectoryCollection();
            foreach (char ch in "cdefghijklmnopqrstuvwxyz".Where(ch => list.AddDriveData(ch) > 0))
            {
                this.AddLog("Найдены видео данные на диске: " + ch + @":\", false);
            }
            list.SortByDate();
            return list;
        }

        #region BackgroundWorker

        // Асинхронный цикл копирования файлов
        private void bwIntellect_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) throw new ArgumentNullException("BackgroundWorker is null");

            //ItvDirectoryCollection source = (e.Argument as ItvDirectoryCollection) ?? new ItvDirectoryCollection();
            ItvDirectoryCollection source = new ItvDirectoryCollection(new VideoDirClient(this.SourceUrl));
            if (!source.Login(Program.profile.Username, Program.profile.Password))
            {
                this.Invoke(new Action(() => this.AddLog("Invalid credetials")));
                return;
            }
            source.FillFromRemote();

            // filter source by date interval
            source.RemoveTo(this.LastCopiedDate.AddDays(-1.0));
            source.RemoveFrom(DateTime.Now);
            if (source.Count <= 0) return;

            // start coping data
            // set progress bar from worker thread
            this.Invoke(new Action(() => {
                this.toolStripProgressBar1.Maximum = source.Count;
                this.toolStripProgressBar1.Value = 0;
            }));
            this.Invoke(new Action(() => this.AddLog("Найдено каталогов с данными: " + source.Count)));

            int folderCounter = 0;
            foreach (string path in source)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    this.Invoke(new Action(() => this.AddLog("Копирование прервано, необработано: " + (source.Count - folderCounter))));
                    return;
                }
                long num5 = 0L;
                DateTime start = DateTime.Now;
                foreach (int cam in this.Cams)
                { 
                    num5 += source.CopyRemoteData(path, cam, this.DestFolder);
                }
                folderCounter++;
                this.Invoke(new Action(() => {
                    this.toolStripProgressBar1.Value = folderCounter;
                    if (num5 > 0)
                    {
                        TimeSpan elapsed = DateTime.Now.Subtract(start);
                        this.AddLog(" Скопировано из " + path + " размер: " + GetSizeMb(num5)
                            + " " + GetTimeMinSek(elapsed) + " сек");
                    }
                }));
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripProgressBar1.Value = this.toolStripProgressBar1.Maximum;
            this.SetCopyState(false);
            this.AddLog("Копирование завершено");
        }

        private void bwGeovision_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker == null) throw new ArgumentNullException("BackgroundWorker is null");

            VideoDirClient client = new VideoDirClient(this.SourceUrl);
            if (!client.Login(Program.profile.Username, Program.profile.Password))
            {
                this.Invoke(new Action(() => this.AddLog("Invalid credetials: " + client.GetErrorMessage())));
                return;
            }

            // каждую камеру обрабатывае отдельно
            foreach (int cam in this.Cams)
            {
                var source = new GeovisionDirectoryCollection(cam, this.LastCopiedDate);
                source.FillFromServer(client);

                // start coping data
                // set progress bar from worker thread
                this.Invoke(new Action(() =>
                {
                    this.toolStripProgressBar1.Maximum = source.Count;
                    this.toolStripProgressBar1.Value = 0;
                }));
                this.Invoke(new Action(() => this.AddLog("Камера " + cam + " найдено каталогов с данными: " + source.Count)));

                //int dayCount = 0;
                int folderCounter = 0;
                foreach (string path in source)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        this.Invoke(new Action(() => this.AddLog("Копирование прервано, необработано: " + (source.Count - folderCounter))));
                        return;
                    }
                    DateTime start = DateTime.Now;
                    var num5 = source.CopyRemoteData(client, path, this.DestFolder);

                    folderCounter++;
                    this.Invoke(new Action(() =>
                    {
                        this.toolStripProgressBar1.Value = folderCounter;
                        if (num5 > 0)
                        {
                            TimeSpan elapsed = DateTime.Now.Subtract(start);
                            this.AddLog(" Скопировано из " + path + " размер: " + GetSizeMb(num5)
                                + " " + GetTimeMinSek(elapsed) + " сек");
                        }
                    }));
                }
            }
        }

        #endregion

        private bool CheckDestSpace(long size)
        {
            DriveInfo info = new DriveInfo(this.DestFolder);
            return (info.IsReady && (info.TotalFreeSpace > size));
        }

        private long GetDestSpace()
        {
            long val = 0L;
            DriveInfo info = new DriveInfo(this.DestFolder);
            if (info.IsReady)
                val = info.TotalFreeSpace;
            return val;
        }

        public static int GetPercent(int value, int count)
        {
            return (int)((((float)value) / ((float)count)) * 100f);
        }

        public static string GetSizeMb(long value)
        {
            long num = (value / 0x400L) / 0x400L;
            return (num.ToString("#,##0") + " Mb");
        }

        public static string GetTimeMinSek(TimeSpan span)
        {
            if (span.Minutes > 0)
                return string.Format("{0}:{1}.{2}", span.Minutes, span.Seconds, span.Milliseconds);
            return string.Format("{0}.{1}", span.Seconds, span.Milliseconds);
        }

    }
}
