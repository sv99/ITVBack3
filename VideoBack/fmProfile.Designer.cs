namespace VideoBack
{
    partial class fmProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbVideoSource = new System.Windows.Forms.GroupBox();
            this.buRemoveSource = new System.Windows.Forms.Button();
            this.buAddSource = new System.Windows.Forms.Button();
            this.lbSources = new System.Windows.Forms.ListBox();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.rbLocalDisk = new System.Windows.Forms.RadioButton();
            this.paButton = new System.Windows.Forms.Panel();
            this.buOk = new System.Windows.Forms.Button();
            this.buCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDestFolder = new System.Windows.Forms.TextBox();
            this.gbCams = new System.Windows.Forms.GroupBox();
            this.chb32 = new System.Windows.Forms.CheckBox();
            this.chb31 = new System.Windows.Forms.CheckBox();
            this.chb30 = new System.Windows.Forms.CheckBox();
            this.chb29 = new System.Windows.Forms.CheckBox();
            this.chb28 = new System.Windows.Forms.CheckBox();
            this.chb27 = new System.Windows.Forms.CheckBox();
            this.chb26 = new System.Windows.Forms.CheckBox();
            this.chb25 = new System.Windows.Forms.CheckBox();
            this.chb24 = new System.Windows.Forms.CheckBox();
            this.chb23 = new System.Windows.Forms.CheckBox();
            this.chb22 = new System.Windows.Forms.CheckBox();
            this.chb21 = new System.Windows.Forms.CheckBox();
            this.chb20 = new System.Windows.Forms.CheckBox();
            this.chb19 = new System.Windows.Forms.CheckBox();
            this.chb18 = new System.Windows.Forms.CheckBox();
            this.chb17 = new System.Windows.Forms.CheckBox();
            this.chb16 = new System.Windows.Forms.CheckBox();
            this.chb15 = new System.Windows.Forms.CheckBox();
            this.chb14 = new System.Windows.Forms.CheckBox();
            this.chb13 = new System.Windows.Forms.CheckBox();
            this.chb12 = new System.Windows.Forms.CheckBox();
            this.chb11 = new System.Windows.Forms.CheckBox();
            this.chb10 = new System.Windows.Forms.CheckBox();
            this.chb9 = new System.Windows.Forms.CheckBox();
            this.chb8 = new System.Windows.Forms.CheckBox();
            this.chb7 = new System.Windows.Forms.CheckBox();
            this.chb6 = new System.Windows.Forms.CheckBox();
            this.chb5 = new System.Windows.Forms.CheckBox();
            this.chb4 = new System.Windows.Forms.CheckBox();
            this.chb3 = new System.Windows.Forms.CheckBox();
            this.chb2 = new System.Windows.Forms.CheckBox();
            this.chb1 = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gbVideoSource.SuspendLayout();
            this.paButton.SuspendLayout();
            this.gbCams.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVideoSource
            // 
            this.gbVideoSource.Controls.Add(this.buRemoveSource);
            this.gbVideoSource.Controls.Add(this.buAddSource);
            this.gbVideoSource.Controls.Add(this.lbSources);
            this.gbVideoSource.Controls.Add(this.rbList);
            this.gbVideoSource.Controls.Add(this.rbLocalDisk);
            this.gbVideoSource.Location = new System.Drawing.Point(12, 12);
            this.gbVideoSource.Name = "gbVideoSource";
            this.gbVideoSource.Size = new System.Drawing.Size(412, 183);
            this.gbVideoSource.TabIndex = 0;
            this.gbVideoSource.TabStop = false;
            this.gbVideoSource.Text = "Источник";
            // 
            // buRemoveSource
            // 
            this.buRemoveSource.Enabled = false;
            this.buRemoveSource.Location = new System.Drawing.Point(132, 150);
            this.buRemoveSource.Name = "buRemoveSource";
            this.buRemoveSource.Size = new System.Drawing.Size(93, 23);
            this.buRemoveSource.TabIndex = 4;
            this.buRemoveSource.Text = "Удалить папку";
            this.buRemoveSource.UseVisualStyleBackColor = true;
            this.buRemoveSource.Click += new System.EventHandler(this.buRemoveSource_Click);
            // 
            // buAddSource
            // 
            this.buAddSource.Enabled = false;
            this.buAddSource.Location = new System.Drawing.Point(18, 150);
            this.buAddSource.Name = "buAddSource";
            this.buAddSource.Size = new System.Drawing.Size(107, 23);
            this.buAddSource.TabIndex = 3;
            this.buAddSource.Text = "Добавить папку";
            this.buAddSource.UseVisualStyleBackColor = true;
            this.buAddSource.Click += new System.EventHandler(this.buAddSource_Click);
            // 
            // lbSources
            // 
            this.lbSources.Enabled = false;
            this.lbSources.FormattingEnabled = true;
            this.lbSources.Location = new System.Drawing.Point(15, 65);
            this.lbSources.Name = "lbSources";
            this.lbSources.Size = new System.Drawing.Size(381, 82);
            this.lbSources.TabIndex = 2;
            this.lbSources.DoubleClick += new System.EventHandler(this.lbSources_DoubleClick);
            // 
            // rbList
            // 
            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(15, 42);
            this.rbList.Name = "rbList";
            this.rbList.Size = new System.Drawing.Size(95, 17);
            this.rbList.TabIndex = 1;
            this.rbList.Text = "Список папок";
            this.rbList.UseVisualStyleBackColor = true;
            this.rbList.CheckedChanged += new System.EventHandler(this.rbLocalDisk_CheckedChanged);
            // 
            // rbLocalDisk
            // 
            this.rbLocalDisk.AutoSize = true;
            this.rbLocalDisk.Checked = true;
            this.rbLocalDisk.Location = new System.Drawing.Point(15, 19);
            this.rbLocalDisk.Name = "rbLocalDisk";
            this.rbLocalDisk.Size = new System.Drawing.Size(183, 17);
            this.rbLocalDisk.TabIndex = 0;
            this.rbLocalDisk.TabStop = true;
            this.rbLocalDisk.Text = "Сканировать локальные диски";
            this.rbLocalDisk.UseVisualStyleBackColor = true;
            this.rbLocalDisk.CheckedChanged += new System.EventHandler(this.rbLocalDisk_CheckedChanged);
            // 
            // paButton
            // 
            this.paButton.Controls.Add(this.buOk);
            this.paButton.Controls.Add(this.buCancel);
            this.paButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.paButton.Location = new System.Drawing.Point(430, 0);
            this.paButton.Name = "paButton";
            this.paButton.Size = new System.Drawing.Size(102, 366);
            this.paButton.TabIndex = 1;
            // 
            // buOk
            // 
            this.buOk.Location = new System.Drawing.Point(5, 12);
            this.buOk.Name = "buOk";
            this.buOk.Size = new System.Drawing.Size(85, 24);
            this.buOk.TabIndex = 35;
            this.buOk.Text = "Ok";
            this.buOk.UseVisualStyleBackColor = true;
            this.buOk.Click += new System.EventHandler(this.buOk_Click);
            // 
            // buCancel
            // 
            this.buCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buCancel.Location = new System.Drawing.Point(5, 42);
            this.buCancel.Name = "buCancel";
            this.buCancel.Size = new System.Drawing.Size(85, 24);
            this.buCancel.TabIndex = 34;
            this.buCancel.Text = "Отмена";
            this.buCancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Папка назначения";
            // 
            // tbDestFolder
            // 
            this.tbDestFolder.Location = new System.Drawing.Point(118, 214);
            this.tbDestFolder.Name = "tbDestFolder";
            this.tbDestFolder.Size = new System.Drawing.Size(276, 20);
            this.tbDestFolder.TabIndex = 3;
            // 
            // gbCams
            // 
            this.gbCams.Controls.Add(this.chb32);
            this.gbCams.Controls.Add(this.chb31);
            this.gbCams.Controls.Add(this.chb30);
            this.gbCams.Controls.Add(this.chb29);
            this.gbCams.Controls.Add(this.chb28);
            this.gbCams.Controls.Add(this.chb27);
            this.gbCams.Controls.Add(this.chb26);
            this.gbCams.Controls.Add(this.chb25);
            this.gbCams.Controls.Add(this.chb24);
            this.gbCams.Controls.Add(this.chb23);
            this.gbCams.Controls.Add(this.chb22);
            this.gbCams.Controls.Add(this.chb21);
            this.gbCams.Controls.Add(this.chb20);
            this.gbCams.Controls.Add(this.chb19);
            this.gbCams.Controls.Add(this.chb18);
            this.gbCams.Controls.Add(this.chb17);
            this.gbCams.Controls.Add(this.chb16);
            this.gbCams.Controls.Add(this.chb15);
            this.gbCams.Controls.Add(this.chb14);
            this.gbCams.Controls.Add(this.chb13);
            this.gbCams.Controls.Add(this.chb12);
            this.gbCams.Controls.Add(this.chb11);
            this.gbCams.Controls.Add(this.chb10);
            this.gbCams.Controls.Add(this.chb9);
            this.gbCams.Controls.Add(this.chb8);
            this.gbCams.Controls.Add(this.chb7);
            this.gbCams.Controls.Add(this.chb6);
            this.gbCams.Controls.Add(this.chb5);
            this.gbCams.Controls.Add(this.chb4);
            this.gbCams.Controls.Add(this.chb3);
            this.gbCams.Controls.Add(this.chb2);
            this.gbCams.Controls.Add(this.chb1);
            this.gbCams.Location = new System.Drawing.Point(14, 240);
            this.gbCams.Name = "gbCams";
            this.gbCams.Size = new System.Drawing.Size(328, 117);
            this.gbCams.TabIndex = 6;
            this.gbCams.TabStop = false;
            this.gbCams.Text = "Камеры";
            // 
            // chb32
            // 
            this.chb32.AutoSize = true;
            this.chb32.Location = new System.Drawing.Point(281, 88);
            this.chb32.Name = "chb32";
            this.chb32.Size = new System.Drawing.Size(38, 17);
            this.chb32.TabIndex = 63;
            this.chb32.Text = "32";
            this.chb32.UseVisualStyleBackColor = true;
            // 
            // chb31
            // 
            this.chb31.AutoSize = true;
            this.chb31.Location = new System.Drawing.Point(243, 88);
            this.chb31.Name = "chb31";
            this.chb31.Size = new System.Drawing.Size(38, 17);
            this.chb31.TabIndex = 62;
            this.chb31.Text = "31";
            this.chb31.UseVisualStyleBackColor = true;
            // 
            // chb30
            // 
            this.chb30.AutoSize = true;
            this.chb30.Location = new System.Drawing.Point(205, 89);
            this.chb30.Name = "chb30";
            this.chb30.Size = new System.Drawing.Size(38, 17);
            this.chb30.TabIndex = 61;
            this.chb30.Text = "30";
            this.chb30.UseVisualStyleBackColor = true;
            // 
            // chb29
            // 
            this.chb29.AutoSize = true;
            this.chb29.Location = new System.Drawing.Point(167, 89);
            this.chb29.Name = "chb29";
            this.chb29.Size = new System.Drawing.Size(38, 17);
            this.chb29.TabIndex = 60;
            this.chb29.Text = "29";
            this.chb29.UseVisualStyleBackColor = true;
            // 
            // chb28
            // 
            this.chb28.AutoSize = true;
            this.chb28.Location = new System.Drawing.Point(129, 89);
            this.chb28.Name = "chb28";
            this.chb28.Size = new System.Drawing.Size(38, 17);
            this.chb28.TabIndex = 59;
            this.chb28.Text = "28";
            this.chb28.UseVisualStyleBackColor = true;
            // 
            // chb27
            // 
            this.chb27.AutoSize = true;
            this.chb27.Location = new System.Drawing.Point(91, 89);
            this.chb27.Name = "chb27";
            this.chb27.Size = new System.Drawing.Size(38, 17);
            this.chb27.TabIndex = 58;
            this.chb27.Text = "27";
            this.chb27.UseVisualStyleBackColor = true;
            // 
            // chb26
            // 
            this.chb26.AutoSize = true;
            this.chb26.Location = new System.Drawing.Point(53, 88);
            this.chb26.Name = "chb26";
            this.chb26.Size = new System.Drawing.Size(38, 17);
            this.chb26.TabIndex = 57;
            this.chb26.Text = "26";
            this.chb26.UseVisualStyleBackColor = true;
            // 
            // chb25
            // 
            this.chb25.AutoSize = true;
            this.chb25.Location = new System.Drawing.Point(15, 88);
            this.chb25.Name = "chb25";
            this.chb25.Size = new System.Drawing.Size(38, 17);
            this.chb25.TabIndex = 56;
            this.chb25.Text = "25";
            this.chb25.UseVisualStyleBackColor = true;
            // 
            // chb24
            // 
            this.chb24.AutoSize = true;
            this.chb24.Location = new System.Drawing.Point(281, 65);
            this.chb24.Name = "chb24";
            this.chb24.Size = new System.Drawing.Size(38, 17);
            this.chb24.TabIndex = 55;
            this.chb24.Text = "24";
            this.chb24.UseVisualStyleBackColor = true;
            // 
            // chb23
            // 
            this.chb23.AutoSize = true;
            this.chb23.Location = new System.Drawing.Point(243, 66);
            this.chb23.Name = "chb23";
            this.chb23.Size = new System.Drawing.Size(38, 17);
            this.chb23.TabIndex = 54;
            this.chb23.Text = "23";
            this.chb23.UseVisualStyleBackColor = true;
            // 
            // chb22
            // 
            this.chb22.AutoSize = true;
            this.chb22.Location = new System.Drawing.Point(205, 66);
            this.chb22.Name = "chb22";
            this.chb22.Size = new System.Drawing.Size(38, 17);
            this.chb22.TabIndex = 53;
            this.chb22.Text = "22";
            this.chb22.UseVisualStyleBackColor = true;
            // 
            // chb21
            // 
            this.chb21.AutoSize = true;
            this.chb21.Location = new System.Drawing.Point(167, 66);
            this.chb21.Name = "chb21";
            this.chb21.Size = new System.Drawing.Size(38, 17);
            this.chb21.TabIndex = 52;
            this.chb21.Text = "21";
            this.chb21.UseVisualStyleBackColor = true;
            // 
            // chb20
            // 
            this.chb20.AutoSize = true;
            this.chb20.Location = new System.Drawing.Point(129, 65);
            this.chb20.Name = "chb20";
            this.chb20.Size = new System.Drawing.Size(38, 17);
            this.chb20.TabIndex = 51;
            this.chb20.Text = "20";
            this.chb20.UseVisualStyleBackColor = true;
            // 
            // chb19
            // 
            this.chb19.AutoSize = true;
            this.chb19.Location = new System.Drawing.Point(91, 66);
            this.chb19.Name = "chb19";
            this.chb19.Size = new System.Drawing.Size(38, 17);
            this.chb19.TabIndex = 50;
            this.chb19.Text = "19";
            this.chb19.UseVisualStyleBackColor = true;
            // 
            // chb18
            // 
            this.chb18.AutoSize = true;
            this.chb18.Location = new System.Drawing.Point(53, 65);
            this.chb18.Name = "chb18";
            this.chb18.Size = new System.Drawing.Size(38, 17);
            this.chb18.TabIndex = 49;
            this.chb18.Text = "18";
            this.chb18.UseVisualStyleBackColor = true;
            // 
            // chb17
            // 
            this.chb17.AutoSize = true;
            this.chb17.Location = new System.Drawing.Point(15, 65);
            this.chb17.Name = "chb17";
            this.chb17.Size = new System.Drawing.Size(38, 17);
            this.chb17.TabIndex = 48;
            this.chb17.Text = "17";
            this.chb17.UseVisualStyleBackColor = true;
            // 
            // chb16
            // 
            this.chb16.AutoSize = true;
            this.chb16.Location = new System.Drawing.Point(281, 43);
            this.chb16.Name = "chb16";
            this.chb16.Size = new System.Drawing.Size(38, 17);
            this.chb16.TabIndex = 47;
            this.chb16.Text = "16";
            this.chb16.UseVisualStyleBackColor = true;
            // 
            // chb15
            // 
            this.chb15.AutoSize = true;
            this.chb15.Location = new System.Drawing.Point(243, 42);
            this.chb15.Name = "chb15";
            this.chb15.Size = new System.Drawing.Size(38, 17);
            this.chb15.TabIndex = 46;
            this.chb15.Text = "15";
            this.chb15.UseVisualStyleBackColor = true;
            // 
            // chb14
            // 
            this.chb14.AutoSize = true;
            this.chb14.Location = new System.Drawing.Point(205, 42);
            this.chb14.Name = "chb14";
            this.chb14.Size = new System.Drawing.Size(38, 17);
            this.chb14.TabIndex = 45;
            this.chb14.Text = "14";
            this.chb14.UseVisualStyleBackColor = true;
            // 
            // chb13
            // 
            this.chb13.AutoSize = true;
            this.chb13.Location = new System.Drawing.Point(167, 43);
            this.chb13.Name = "chb13";
            this.chb13.Size = new System.Drawing.Size(38, 17);
            this.chb13.TabIndex = 44;
            this.chb13.Text = "13";
            this.chb13.UseVisualStyleBackColor = true;
            // 
            // chb12
            // 
            this.chb12.AutoSize = true;
            this.chb12.Location = new System.Drawing.Point(129, 43);
            this.chb12.Name = "chb12";
            this.chb12.Size = new System.Drawing.Size(38, 17);
            this.chb12.TabIndex = 43;
            this.chb12.Text = "12";
            this.chb12.UseVisualStyleBackColor = true;
            // 
            // chb11
            // 
            this.chb11.AutoSize = true;
            this.chb11.Location = new System.Drawing.Point(91, 42);
            this.chb11.Name = "chb11";
            this.chb11.Size = new System.Drawing.Size(38, 17);
            this.chb11.TabIndex = 42;
            this.chb11.Text = "11";
            this.chb11.UseVisualStyleBackColor = true;
            // 
            // chb10
            // 
            this.chb10.AutoSize = true;
            this.chb10.Location = new System.Drawing.Point(53, 42);
            this.chb10.Name = "chb10";
            this.chb10.Size = new System.Drawing.Size(38, 17);
            this.chb10.TabIndex = 41;
            this.chb10.Text = "10";
            this.chb10.UseVisualStyleBackColor = true;
            // 
            // chb9
            // 
            this.chb9.AutoSize = true;
            this.chb9.Location = new System.Drawing.Point(15, 43);
            this.chb9.Name = "chb9";
            this.chb9.Size = new System.Drawing.Size(32, 17);
            this.chb9.TabIndex = 40;
            this.chb9.Text = "9";
            this.chb9.UseVisualStyleBackColor = true;
            // 
            // chb8
            // 
            this.chb8.AutoSize = true;
            this.chb8.Location = new System.Drawing.Point(281, 20);
            this.chb8.Name = "chb8";
            this.chb8.Size = new System.Drawing.Size(32, 17);
            this.chb8.TabIndex = 39;
            this.chb8.Text = "8";
            this.chb8.UseVisualStyleBackColor = true;
            // 
            // chb7
            // 
            this.chb7.AutoSize = true;
            this.chb7.Location = new System.Drawing.Point(243, 20);
            this.chb7.Name = "chb7";
            this.chb7.Size = new System.Drawing.Size(32, 17);
            this.chb7.TabIndex = 38;
            this.chb7.Text = "7";
            this.chb7.UseVisualStyleBackColor = true;
            // 
            // chb6
            // 
            this.chb6.AutoSize = true;
            this.chb6.Location = new System.Drawing.Point(205, 19);
            this.chb6.Name = "chb6";
            this.chb6.Size = new System.Drawing.Size(32, 17);
            this.chb6.TabIndex = 37;
            this.chb6.Text = "6";
            this.chb6.UseVisualStyleBackColor = true;
            // 
            // chb5
            // 
            this.chb5.AutoSize = true;
            this.chb5.Location = new System.Drawing.Point(167, 20);
            this.chb5.Name = "chb5";
            this.chb5.Size = new System.Drawing.Size(32, 17);
            this.chb5.TabIndex = 36;
            this.chb5.Text = "5";
            this.chb5.UseVisualStyleBackColor = true;
            // 
            // chb4
            // 
            this.chb4.AutoSize = true;
            this.chb4.Location = new System.Drawing.Point(129, 20);
            this.chb4.Name = "chb4";
            this.chb4.Size = new System.Drawing.Size(32, 17);
            this.chb4.TabIndex = 35;
            this.chb4.Text = "4";
            this.chb4.UseVisualStyleBackColor = true;
            // 
            // chb3
            // 
            this.chb3.AutoSize = true;
            this.chb3.Location = new System.Drawing.Point(91, 20);
            this.chb3.Name = "chb3";
            this.chb3.Size = new System.Drawing.Size(32, 17);
            this.chb3.TabIndex = 34;
            this.chb3.Text = "3";
            this.chb3.UseVisualStyleBackColor = true;
            // 
            // chb2
            // 
            this.chb2.AutoSize = true;
            this.chb2.Location = new System.Drawing.Point(53, 19);
            this.chb2.Name = "chb2";
            this.chb2.Size = new System.Drawing.Size(32, 17);
            this.chb2.TabIndex = 33;
            this.chb2.Text = "2";
            this.chb2.UseVisualStyleBackColor = true;
            // 
            // chb1
            // 
            this.chb1.AutoSize = true;
            this.chb1.Location = new System.Drawing.Point(15, 20);
            this.chb1.Name = "chb1";
            this.chb1.Size = new System.Drawing.Size(32, 17);
            this.chb1.TabIndex = 32;
            this.chb1.Text = "1";
            this.chb1.UseVisualStyleBackColor = true;
            // 
            // fmProfile
            // 
            this.AcceptButton = this.buOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 366);
            this.Controls.Add(this.gbCams);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDestFolder);
            this.Controls.Add(this.paButton);
            this.Controls.Add(this.gbVideoSource);
            this.MinimumSize = new System.Drawing.Size(540, 360);
            this.Name = "fmProfile";
            this.Text = "Свойства";
            this.gbVideoSource.ResumeLayout(false);
            this.gbVideoSource.PerformLayout();
            this.paButton.ResumeLayout(false);
            this.gbCams.ResumeLayout(false);
            this.gbCams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVideoSource;
        private System.Windows.Forms.Panel paButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDestFolder;
        private System.Windows.Forms.GroupBox gbCams;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.RadioButton rbLocalDisk;
        private System.Windows.Forms.CheckBox chb32;
        private System.Windows.Forms.CheckBox chb31;
        private System.Windows.Forms.CheckBox chb30;
        private System.Windows.Forms.CheckBox chb29;
        private System.Windows.Forms.CheckBox chb28;
        private System.Windows.Forms.CheckBox chb27;
        private System.Windows.Forms.CheckBox chb26;
        private System.Windows.Forms.CheckBox chb25;
        private System.Windows.Forms.CheckBox chb24;
        private System.Windows.Forms.CheckBox chb23;
        private System.Windows.Forms.CheckBox chb22;
        private System.Windows.Forms.CheckBox chb21;
        private System.Windows.Forms.CheckBox chb20;
        private System.Windows.Forms.CheckBox chb19;
        private System.Windows.Forms.CheckBox chb18;
        private System.Windows.Forms.CheckBox chb17;
        private System.Windows.Forms.CheckBox chb16;
        private System.Windows.Forms.CheckBox chb15;
        private System.Windows.Forms.CheckBox chb14;
        private System.Windows.Forms.CheckBox chb13;
        private System.Windows.Forms.CheckBox chb12;
        private System.Windows.Forms.CheckBox chb11;
        private System.Windows.Forms.CheckBox chb10;
        private System.Windows.Forms.CheckBox chb9;
        private System.Windows.Forms.CheckBox chb8;
        private System.Windows.Forms.CheckBox chb7;
        private System.Windows.Forms.CheckBox chb6;
        private System.Windows.Forms.CheckBox chb5;
        private System.Windows.Forms.CheckBox chb4;
        private System.Windows.Forms.CheckBox chb3;
        private System.Windows.Forms.CheckBox chb2;
        private System.Windows.Forms.CheckBox chb1;
        private System.Windows.Forms.Button buOk;
        private System.Windows.Forms.Button buCancel;
        private System.Windows.Forms.Button buRemoveSource;
        private System.Windows.Forms.Button buAddSource;
        private System.Windows.Forms.ListBox lbSources;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}