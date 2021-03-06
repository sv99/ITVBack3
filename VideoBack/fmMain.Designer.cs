﻿namespace VideoBack
{
    partial class fmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.paButton = new System.Windows.Forms.Panel();
            this.buPing = new System.Windows.Forms.Button();
            this.buProfile = new System.Windows.Forms.Button();
            this.buClose = new System.Windows.Forms.Button();
            this.buClearLog = new System.Windows.Forms.Button();
            this.buCopy = new System.Windows.Forms.Button();
            this.buCancel = new System.Windows.Forms.Button();
            this.paParam = new System.Windows.Forms.Panel();
            this.laType = new System.Windows.Forms.Label();
            this.laSourceUrl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.laDestFolder = new System.Windows.Forms.Label();
            this.laCamsArray = new System.Windows.Forms.Label();
            this.dtLastCopiedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bwIntellect = new System.ComponentModel.BackgroundWorker();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bwGeovision = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.paButton.SuspendLayout();
            this.paParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(550, 16);
            this.toolStripProgressBar1.Step = 5;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // paButton
            // 
            this.paButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paButton.Controls.Add(this.buPing);
            this.paButton.Controls.Add(this.buProfile);
            this.paButton.Controls.Add(this.buClose);
            this.paButton.Controls.Add(this.buClearLog);
            this.paButton.Controls.Add(this.buCopy);
            this.paButton.Controls.Add(this.buCancel);
            this.paButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.paButton.Location = new System.Drawing.Point(529, 0);
            this.paButton.Name = "paButton";
            this.paButton.Size = new System.Drawing.Size(113, 404);
            this.paButton.TabIndex = 10;
            // 
            // buPing
            // 
            this.buPing.Enabled = false;
            this.buPing.Location = new System.Drawing.Point(15, 99);
            this.buPing.Name = "buPing";
            this.buPing.Size = new System.Drawing.Size(85, 24);
            this.buPing.TabIndex = 10;
            this.buPing.Text = "Ping";
            this.toolTip1.SetToolTip(this.buPing, "Проверка последовательности скопированных данных");
            this.buPing.UseVisualStyleBackColor = true;
            this.buPing.Click += new System.EventHandler(this.buPing_Click);
            // 
            // buProfile
            // 
            this.buProfile.Location = new System.Drawing.Point(15, 129);
            this.buProfile.Name = "buProfile";
            this.buProfile.Size = new System.Drawing.Size(85, 24);
            this.buProfile.TabIndex = 9;
            this.buProfile.Text = "Свойства";
            this.toolTip1.SetToolTip(this.buProfile, "Настройка свойств копирования");
            this.buProfile.UseVisualStyleBackColor = true;
            this.buProfile.Click += new System.EventHandler(this.buProfile_Click);
            // 
            // buClose
            // 
            this.buClose.Location = new System.Drawing.Point(15, 189);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(85, 24);
            this.buClose.TabIndex = 7;
            this.buClose.Text = "Закрыть";
            this.toolTip1.SetToolTip(this.buClose, "Закрыть");
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // buClearLog
            // 
            this.buClearLog.Location = new System.Drawing.Point(15, 159);
            this.buClearLog.Name = "buClearLog";
            this.buClearLog.Size = new System.Drawing.Size(85, 24);
            this.buClearLog.TabIndex = 6;
            this.buClearLog.Text = "Очистить лог";
            this.toolTip1.SetToolTip(this.buClearLog, "Очистка окна с сообщениями");
            this.buClearLog.UseVisualStyleBackColor = true;
            this.buClearLog.Click += new System.EventHandler(this.buClearLog_Click);
            // 
            // buCopy
            // 
            this.buCopy.Enabled = false;
            this.buCopy.Location = new System.Drawing.Point(15, 9);
            this.buCopy.Name = "buCopy";
            this.buCopy.Size = new System.Drawing.Size(85, 24);
            this.buCopy.TabIndex = 5;
            this.buCopy.Text = "Копировать";
            this.toolTip1.SetToolTip(this.buCopy, "Старт копирования данных");
            this.buCopy.UseVisualStyleBackColor = true;
            this.buCopy.Click += new System.EventHandler(this.buCopy_Click);
            // 
            // buCancel
            // 
            this.buCancel.Enabled = false;
            this.buCancel.Location = new System.Drawing.Point(15, 39);
            this.buCancel.Name = "buCancel";
            this.buCancel.Size = new System.Drawing.Size(85, 24);
            this.buCancel.TabIndex = 4;
            this.buCancel.Text = "Отмена";
            this.toolTip1.SetToolTip(this.buCancel, "Остановка копировния данных");
            this.buCancel.UseVisualStyleBackColor = true;
            this.buCancel.Click += new System.EventHandler(this.buCancel_Click);
            // 
            // paParam
            // 
            this.paParam.Controls.Add(this.laType);
            this.paParam.Controls.Add(this.laSourceUrl);
            this.paParam.Controls.Add(this.label4);
            this.paParam.Controls.Add(this.laDestFolder);
            this.paParam.Controls.Add(this.laCamsArray);
            this.paParam.Controls.Add(this.dtLastCopiedDate);
            this.paParam.Controls.Add(this.label3);
            this.paParam.Controls.Add(this.label2);
            this.paParam.Controls.Add(this.label1);
            this.paParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.paParam.Location = new System.Drawing.Point(0, 0);
            this.paParam.Name = "paParam";
            this.paParam.Size = new System.Drawing.Size(529, 114);
            this.paParam.TabIndex = 12;
            // 
            // laType
            // 
            this.laType.AutoSize = true;
            this.laType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laType.Location = new System.Drawing.Point(420, 37);
            this.laType.Name = "laType";
            this.laType.Size = new System.Drawing.Size(0, 13);
            this.laType.TabIndex = 12;
            // 
            // laSourceUrl
            // 
            this.laSourceUrl.AutoSize = true;
            this.laSourceUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laSourceUrl.Location = new System.Drawing.Point(116, 34);
            this.laSourceUrl.Name = "laSourceUrl";
            this.laSourceUrl.Size = new System.Drawing.Size(63, 13);
            this.laSourceUrl.TabIndex = 11;
            this.laSourceUrl.Text = "Источник";
            this.toolTip1.SetToolTip(this.laSourceUrl, " ");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Источник";
            // 
            // laDestFolder
            // 
            this.laDestFolder.AutoSize = true;
            this.laDestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laDestFolder.Location = new System.Drawing.Point(116, 59);
            this.laDestFolder.Name = "laDestFolder";
            this.laDestFolder.Size = new System.Drawing.Size(96, 13);
            this.laDestFolder.TabIndex = 8;
            this.laDestFolder.Text = "Куда копируем";
            this.toolTip1.SetToolTip(this.laDestFolder, " ");
            // 
            // laCamsArray
            // 
            this.laCamsArray.AutoSize = true;
            this.laCamsArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laCamsArray.Location = new System.Drawing.Point(116, 9);
            this.laCamsArray.Name = "laCamsArray";
            this.laCamsArray.Size = new System.Drawing.Size(52, 13);
            this.laCamsArray.TabIndex = 7;
            this.laCamsArray.Text = "Камера";
            this.toolTip1.SetToolTip(this.laCamsArray, " Щелкнуть если нужно изменить список камер для копирования");
            // 
            // dtLastCopiedDate
            // 
            this.dtLastCopiedDate.Location = new System.Drawing.Point(119, 82);
            this.dtLastCopiedDate.Name = "dtLastCopiedDate";
            this.dtLastCopiedDate.Size = new System.Drawing.Size(125, 20);
            this.dtLastCopiedDate.TabIndex = 6;
            this.toolTip1.SetToolTip(this.dtLastCopiedDate, "Дата начиная с которой будут просканированы папки с видеоданными.\r\nНужно выставит" +
        "ь после выбора каталога назначения");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Копировать с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Камера";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Папка назначения";
            // 
            // bwIntellect
            // 
            this.bwIntellect.WorkerReportsProgress = true;
            this.bwIntellect.WorkerSupportsCancellation = true;
            this.bwIntellect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwIntellect_DoWork);
            this.bwIntellect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // lbLog
            // 
            this.lbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(0, 114);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(529, 290);
            this.lbLog.TabIndex = 13;
            // 
            // bwGeovision
            // 
            this.bwGeovision.WorkerReportsProgress = true;
            this.bwGeovision.WorkerSupportsCancellation = true;
            this.bwGeovision.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGeovision_DoWork);
            this.bwGeovision.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // fmMain
            // 
            this.AcceptButton = this.buCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 426);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.paParam);
            this.Controls.Add(this.paButton);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 460);
            this.Name = "fmMain";
            this.Text = "VideoBack";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.paButton.ResumeLayout(false);
            this.paParam.ResumeLayout(false);
            this.paParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel paButton;
        private System.Windows.Forms.Panel paParam;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bwIntellect;
        private System.Windows.Forms.Button buCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtLastCopiedDate;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Button buClearLog;
        private System.Windows.Forms.Button buCopy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label laCamsArray;
        private System.Windows.Forms.Button buProfile;
        private System.Windows.Forms.Label laDestFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label laSourceUrl;
        private System.Windows.Forms.Button buPing;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label laType;
        private System.ComponentModel.BackgroundWorker bwGeovision;
    }
}

