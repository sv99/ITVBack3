using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITVBack
{
    public partial class fmProfile : Form
    {
        public Profile Profile { get; private set; }

        public fmProfile(Profile profile)
        {
            InitializeComponent();
            this.Profile = profile;
            InitCams();
            if (this.Profile.IsLocalScan)
            {
                this.rbLocalDisk.Checked = true;
            }
            else
            {
                this.rbList.Checked = true;
            }
            this.tbDestFolder.Text = this.Profile.DestFolder;
            this.lbSources.Items.Clear();
            if (this.rbList.Checked)
            {
                foreach (string item in this.Profile.SourceFolders)
                    this.lbSources.Items.Add(item);
            }
        }

        public fmProfile()
        {
            InitializeComponent();
        }

        private void InitCams()
        {
            if (String.IsNullOrEmpty(this.Profile.Cams))
                return;
            if (this.Profile.Cams.IndexOf(',') <= 0)
            {
                //одна камера
                CheckBox cb = (CheckBox)this.gbCams.Controls.Find("chb" + this.Profile.Cams.Trim(), false)[0];
                cb.Checked = true;
            }
            else
            {
                foreach (var cam in this.Profile.Cams.Split(','))
                {
                    CheckBox cb = (CheckBox)this.gbCams.Controls.Find("chb" + cam.Trim(), false)[0];
                    cb.Checked = true;
                }
            }
        }

        private void UpdateCams()
        {
            string res = "";
            bool not_first = false;
            for (int i = 1; i <= 32; i++)
            {
                CheckBox cb = (CheckBox)this.gbCams.Controls.Find(
                    "chb" + i.ToString(CultureInfo.InvariantCulture), false)[0];

                if (cb.Checked)
                {
                    if (not_first) res += ',';
                    res += i.ToString(CultureInfo.InvariantCulture);
                    not_first = true;
                }
            }
            this.Profile.Cams = res;
        }

        private void buAddSource_Click(object sender, EventArgs e)
        {
            if (this.lbSources.SelectedIndex >= 0)
                this.folderBrowserDialog1.SelectedPath = (string)this.lbSources.SelectedItem;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
             {
                // Добавляем только если нет в списке
                string path = this.folderBrowserDialog1.SelectedPath;
                this.lbSources.Items.Add(path);
                if (this.lbSources.Items.IndexOf(path) < 0)
                {
                    this.lbSources.Items.Add(path);
                }
                else
                {
                    MessageBox.Show("Папка уже есть в списке источников!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buRemoveSource_Click(object sender, EventArgs e)
        {
            if (this.lbSources.SelectedIndex >= 0)
                this.lbSources.Items.RemoveAt(this.lbSources.SelectedIndex);
        }

        private void lbSources_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbSources.SelectedIndex < 0) return;
            fmSourceEdit fm = new fmSourceEdit((string)this.lbSources.SelectedItem);
            fm.Location = Cursor.Position;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                this.lbSources.Items[this.lbSources.SelectedIndex] = fm.Source;
            }
        }
        
        private void buOk_Click(object sender, EventArgs e)
        {
            UpdateCams();
            if (Profile.Cams == "")
            {
                MessageBox.Show("Нужно выделить хотя бы одну камеру!", "Внимание",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
                return;
            }
            //this.laCamsArray.Text = fm.Cams;
            this.Profile.IsLocalScan = this.rbLocalDisk.Checked;
            this.Profile.DestFolder = this.tbDestFolder.Text;
            this.Profile.SourceFolders.Clear();
            if (this.rbList.Checked)
            {
                this.Profile.SourceFolders.Clear();
                foreach (string item in this.lbSources.Items)
                    this.Profile.SourceFolders.Add(item);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void rbLocalDisk_CheckedChanged(object sender, EventArgs e)
        {
            bool bList = this.rbList.Checked;
            this.lbSources.Enabled = bList;
            this.buAddSource.Enabled = bList;
            this.buRemoveSource.Enabled = bList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.tbDestFolder.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tbDestFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

 
    }
}
